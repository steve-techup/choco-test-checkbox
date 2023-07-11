using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using Caretag_Class.Model;
using Caretag_Class.ReactiveUI;
using CheckboxStation.Services;
using CheckboxStation.ViewModels;
using CheckboxStation.Views;
using FluentAssertions;
using Main.Model.PackingList.Validation;
using Main.ReactiveUI.Interactions;
using Microsoft.Reactive.Testing;
using Moq;
using NodaTime;
using ReactiveUI;
using ReactiveUI.Testing;
using RFIDAbstractionLayer;
using RFIDAbstractionLayer.Readers;
using Surgical_Admin.Interactions;
using Xunit;
using Tests.CheckboxStation;
using Xunit.Abstractions;
using CheckboxStation.Services.Bridge;
using CheckboxStation.Configuration;
using Caretag_Class.Configuration;

namespace Tests.CheckboxStation
{
    public class ConsoleWriter : StringWriter
    {
        private ITestOutputHelper output;
        public ConsoleWriter(ITestOutputHelper output)
        {
            this.output = output;
        }

        public override void WriteLine(string m)
        {
            output.WriteLine(m);
        }
    }

    public class CheckboxViewModelTest : BaseTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public CheckboxViewModelTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            Console.SetOut(new ConsoleWriter(testOutputHelper));
            
            var service = new Mock<CheckboxService>();
            service.Setup(s => s.GetOperations(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<bool>()))
                .Returns(() => new List<Operation>());

            _fixture.Register(() => service.Object);
            _fixture.Register(() => service);
            var scanEventService = new Mock<ScanEventService>();
            _fixture.Register(() => scanEventService.Object);
            _fixture.Register(() => scanEventService);


        }

        private CheckboxViewModel SetupWithSelectedOperation(bool confirmOutputValue, IScheduler scheduler)
        {
            var commonInteractionsFactoryMock = new Mock<CommonInteractionsFactory>();
            var commonInteractionsMock = new Mock<CommonInteractions>();
            var interactionsMock = new Mock<CheckboxInteractions>();
            commonInteractionsFactoryMock.Setup(f => f.Create(It.IsAny<IScheduler>())).Returns(commonInteractionsMock.Object);

            commonInteractionsMock.Object.Clear();
            commonInteractionsMock.Object.Confirm.RegisterHandler(interaction =>
                interaction.SetOutput(confirmOutputValue ? CaretagMessageBoxResult.Ok : CaretagMessageBoxResult.Cancel));
            _fixture.Register(() => interactionsMock.Object);
            _fixture.Register(() => commonInteractionsFactoryMock.Object);
            _fixture.Register(() => commonInteractionsMock.Object);
            
            interactionsMock.Object.CheckIn.RegisterHandler(interaction => { interaction.SetOutput(Unit.Default); });

            var op = _fixture.Create<Mock<OperationViewModel>>();
            var viewModel = _fixture.Create<CheckboxViewModel>();
            viewModel.Features.VerificationEnabled = false;
            viewModel.Scheduler = scheduler;
            viewModel.SelectedOperation = op.Object;
            return viewModel;
        }
        
        private void SetupReaderCollectionWithInstrumentsScanned(List<string> tags, bool checkedIn = false)
        {
            var readerMock = new Mock<RFIDReaderCollection>();
            readerMock.Setup(r => r.SubscribeAll(It.IsAny<Action<ReadingResult[]>>())).Callback(
                (Action<ReadingResult[]> callback) =>
                {
                callback( // Create a list of ReadingResults with unique identifiers
                        tags
                            .Select(epc => ReadingResult.MakeRFIDSimReading(epc, "MordorReader"))
                            .ToArray());
            });
            
            _fixture.Register(() => readerMock.Object);
            _fixture.Register(() => readerMock);

            var lineItems = tags.Select(tag => new ValidatedPackingListLineItem
            {

                Actual = 1,
                Expected = 0,
                InstrumentDescription = _fixture.Create<Instrument_Description>(),
                DescriptionId = _fixture.Create<string>(),
                Description = _fixture.Create<string>(),

                Instruments =
                    new List<Instrument_RFID>()
                    {
                        new Instrument_RFID()
                        {
                            EPC_Nr = tag, OperationInstruments = new List<OperationInstrument>
                            {
                                new OperationInstrument() {ActiveLink = checkedIn}

                            }
                        }

                    }
            }).ToList();

            var bridgeMock = new Mock<IScanService>();
            bridgeMock.Setup(p => p.SaveValidatedPackingList(It.IsAny<ValidatedPackingList>()));
            
            bridgeMock.Setup(p => p.ValidatePackingList(tags, It.IsAny<ValidatedPackingList?>()))
                .Returns<List<string>, ValidatedPackingList>((t, old) =>
                {
                    
                    if (old == null)
                    {
                        return Task.FromResult(new ValidatedPackingList
                        {
                            Result = ValidatedPackingList.PackingListState.NoTray,
                            Lines = lineItems
                        });
                    }
                    else
                    {
                        return Task.FromResult(new ValidatedPackingList
                        {
                            Result = ValidatedPackingList.PackingListState.NoTray,
                            Lines = lineItems.Select(item => new ValidatedPackingListLineItem
                            {
                                Actual = item.Actual,
                                Expected = item.Expected,
                                InstrumentDescription = item.InstrumentDescription,
                                DescriptionId = item.DescriptionId,
                                Description = item.Description,
                                PackedManually = old.Lines.FirstOrDefault(l => l.DescriptionId == item.DescriptionId)?.PackedManually ?? false,
                                Instruments = item.Instruments.Select(instrument => new Instrument_RFID
                                {
                                    EPC_Nr = instrument.EPC_Nr,
                                    OperationInstruments = instrument.OperationInstruments.Select(operationInstrument => new OperationInstrument
                                    {
                                        ActiveLink = operationInstrument.ActiveLink
                                    }).ToList()
                                }).ToList()
                            }).ToList()
                        });
                    }
                });

            bridgeMock.Setup(i => i.GetInstruments(It.IsAny<List<string>>())).ReturnsAsync(() => tags.Select(t => new Instrument_RFID()
            {
                EPC_Nr = t,
                OperationInstruments = new List<OperationInstrument>(),
                Description_Text = _fixture.Create<string>()
            }).ToList());



            _fixture.Register(() => bridgeMock.Object);
            _fixture.Register(() => bridgeMock);

            var instrumentServiceMock = new Mock<InstrumentService>();
            instrumentServiceMock.Setup(i => i.GetByTagsWithOperationAndDescriptionAndPopulateServiceRequests(It.IsAny<List<string>>())).Returns(() => tags.Select(t => new Instrument_RFID()
            {
                EPC_Nr = t,
                OperationInstruments = new List<OperationInstrument>(),
                Description_Text = _fixture.Create<string>()
            }).ToList());
            
            _fixture.Register(() => instrumentServiceMock.Object);
            _fixture.Register(() => instrumentServiceMock);

            _fixture.Create<Mock<ScanEventService>>().Setup(x => x.Save(tags)).Verifiable();
        }

        [Fact]
        public void CheckIn_One_Instrument()
        {
            var checkInService = new Mock<CheckStateService>();
            checkInService.Setup(s =>
                s.CheckInstrumentsIn((It.IsAny<ICollection<Instrument_RFID>>()), It.IsAny<Operation>()));
            checkInService.Setup(s => s.GetOperations(It.IsAny<OperationState>())).Returns(() => new List<Operation>());
            _fixture.Register(() => checkInService.Object);
            _fixture.Register(() => checkInService);
            SetupReaderCollectionWithInstrumentsScanned(GetTags(1));

            var bridgeValidator = _fixture.Create<Mock<IScanService>>();
            _fixture.Register(() => bridgeValidator.Object);
            _fixture.Register(() => bridgeValidator);


            new TestScheduler().With(s =>
            {
                var viewModel = SetupWithSelectedOperation(true,s);
                viewModel.SelectedOperation = null;

                viewModel.CheckIn.Execute().Subscribe(_ =>
                {
                    bridgeValidator.Verify(p => p.ValidatePackingList(It.IsAny<List<string>>(), null), Times.Once);

                });
                s.Start();
            });
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(50)]
        public void CheckOut_Instruments(int instrumentCount)
        {
            var tags = GetTags(instrumentCount);
            SetupReaderCollectionWithInstrumentsScanned(tags, true);

            var bridgeValidator = _fixture.Create<Mock<IScanService>>();
            _fixture.Register(() => bridgeValidator.Object);
            _fixture.Register(() => bridgeValidator);

            var checkStateService = new Mock<CheckStateService>();
            _fixture.Register(() => checkStateService.Object);
            

            new TestScheduler().With(s =>
            {
                var viewModel = SetupWithSelectedOperation(true, s);
                viewModel.SelectedOperation = null;
                viewModel.CheckOut.Execute().Subscribe(_ =>
                {
                    bridgeValidator.Verify(p => p.ValidatePackingList(It.IsAny<List<string>>(), null), Times.Once);
                    
                    // verify that checkStateService.CheckInstrumentsOut was called once
                    checkStateService.Verify(s => s.CheckInstrumentsOut(It.IsAny<IEnumerable<Instrument_RFID>>()), Times.Once);

                });
                s.Start();
            });
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(100)]
        public void SingleScan_Instruments(int instrumentCount)
        {
            new TestScheduler().With(s =>
            {
                var appSettings = _fixture.Create<AppSettingsBase>();
                appSettings.UseApi = false;
                _fixture.Inject(appSettings);

                var checkboxSettings = _fixture.Create<CheckboxStationAppSettings>();
                checkboxSettings.Features.VerificationEnabled = false;
                _fixture.Inject(checkboxSettings);

                SetupReaderCollectionWithInstrumentsScanned(GetTags(instrumentCount));
                var viewModel = SetupWithSelectedOperation(true,s);
                
                viewModel.ScanDelay = Duration.FromSeconds(1);
                viewModel.SelectedOperation = null;
                
                viewModel.SingleScan.Execute(new Tuple<int, int>(1,1)).ObserveOn(s).Subscribe(result =>
                {
                    _testOutputHelper.WriteLine("In Subscribe");
                    Assert.Equal(ValidatedPackingList.PackingListState.NoTray, result.Result);
                    Assert.Equal(instrumentCount, result.Lines.Count);
                });
                
                s.Start();
                s.AdvanceBy(TimeSpan.FromMilliseconds(1000).Ticks);
            });
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(100)]
        public void MultiScan_Instruments_No_Rescan(int instrumentCount)
        {
            new TestScheduler().With(s =>
            {
                var appSettings = _fixture.Create<AppSettingsBase>();
                appSettings.UseApi = false;
                _fixture.Inject(appSettings);

                var checkboxSettings = _fixture.Create<CheckboxStationAppSettings>();
                checkboxSettings.Features.VerificationEnabled = false;
                _fixture.Inject(checkboxSettings);

                SetupReaderCollectionWithInstrumentsScanned(GetTags(instrumentCount));
                var viewModel = SetupWithSelectedOperation(false, s);

                viewModel.ScanDelay = Duration.FromSeconds(1);
                viewModel.SelectedOperation = null;
                
                viewModel.Scan.Execute().ObserveOn(s).Subscribe(_ =>
                {
                    _testOutputHelper.WriteLine("In Subscribe");
                    Assert.Equal(ValidatedPackingList.PackingListState.NoTray, viewModel.ValidatedPackingList.Result);
                    Assert.Equal(instrumentCount, viewModel.ValidatedPackingList.Lines.Count);

                    var bridgeMock = _fixture.Create<Mock<IScanService>>();
                    _fixture.Register(() => bridgeMock.Object);
                    _fixture.Register(() => bridgeMock);

                    bridgeMock.Verify();
                    bridgeMock.Verify(p => p.SaveValidatedPackingList(It.IsAny<ValidatedPackingList>()), Times.Exactly(1));
                    bridgeMock.Verify(x => x.SaveScanLog(It.IsAny<List<string>>()), Times.Exactly(1));
                });

                s.Start();
                s.AdvanceBy(TimeSpan.FromMilliseconds(1000).Ticks);
            });
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(100)]
        public void MultiScan_Instruments_With_Rescan(int instrumentCount)
        {
            new TestScheduler().With(s =>
            {
                var appSettings = _fixture.Create<AppSettingsBase>();
                appSettings.UseApi = false;
                _fixture.Inject(appSettings);

                var checkboxSettings = _fixture.Create<CheckboxStationAppSettings>();
                checkboxSettings.Features.VerificationEnabled = false;
                _fixture.Inject(checkboxSettings);

                SetupReaderCollectionWithInstrumentsScanned(GetTags(instrumentCount));
                var viewModel = SetupWithSelectedOperation(true, s);

                viewModel.ScanDelay = Duration.FromSeconds(1);
                viewModel.SelectedOperation = null;

                viewModel.Scan.Execute().ObserveOn(s).Subscribe(_ =>
                {
                    _testOutputHelper.WriteLine("In Subscribe");
                    Assert.Equal(ValidatedPackingList.PackingListState.NoTray, viewModel.ValidatedPackingList.Result);
                    Assert.Equal(instrumentCount, viewModel.ValidatedPackingList.Tags.Count); 
                    Assert.Equal(instrumentCount, viewModel.ValidatedPackingList.Lines.Count);

                    var bridgeMock = _fixture.Create<Mock<IScanService>>();
                    bridgeMock.Verify(p => p.SaveValidatedPackingList(It.IsAny<ValidatedPackingList>()), Times.Once);
                    bridgeMock.Verify(x => x.SaveScanLog(It.IsAny<List<string>>()), Times.Once);
                });

                s.Start();
                s.AdvanceBy(TimeSpan.FromMilliseconds(1000).Ticks);
            });
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        public void ScanLifecycle_Instruments(int instrumentCount)
        {
            new TestScheduler().With(s =>
            {
                var tags = GetTags(instrumentCount);
                SetupReaderCollectionWithInstrumentsScanned(tags);
                var viewModel = SetupWithSelectedOperation(true, s);

                viewModel.ScanDelay = Duration.FromSeconds(1);
                viewModel.SelectedOperation = null;
                
                viewModel.Scan.Execute().ObserveOn(s).Subscribe(_ =>
                {
                    _testOutputHelper.WriteLine("In Subscribe");

                    var bridgeMock = _fixture.Create<Mock<IScanService>>();
                    _fixture.Register(() => bridgeMock.Object);
                    _fixture.Register(() => bridgeMock);
                    bridgeMock.Verify(x => x.SaveScanLog(It.IsAny<List<string>>()), Times.Once);

                    Assert.Equal(tags, viewModel.InstrumentLifecycleRfids.Select(i => i.EPC_Nr));
                });

                s.Start();
                s.AdvanceBy(TimeSpan.FromMilliseconds(1000).Ticks);
            });
        }


        [Fact]
        public void NewOperation_CreateSuccess()
        {
            new TestScheduler().With(s =>
            {
                var vm = new NewOperationViewModel
                {
                    CreateSuccess = true,
                    Id = _fixture.Create<string>(),
                    ORName = _fixture.Create<string>(),
                    ShowForm = false
                };
                var interactionsMock = new Mock<CheckboxInteractions>();
                interactionsMock.Object.NewOperation.RegisterHandler(interaction =>
                    interaction.SetOutput(vm));
                _fixture.Register(() => interactionsMock.Object);

                var serviceMock = _fixture.Create<Mock<CheckboxService>>();
                serviceMock.Setup(s => s.NewOperation(It.Is<Operation>(o => o.OperationId == vm.Id && o.OperatingRoom == vm.ORName))).Verifiable();

                var viewModel = _fixture.Create<CheckboxViewModel>();
                viewModel.Scheduler = s;

                viewModel.NewOperation.Execute().Subscribe(_ =>
                {
                    serviceMock.Verify();
                });

                s.Start();
            });
        }

        [Fact]
        public void NewOperation_CreateCancelled()
        {
            new TestScheduler().With(s =>
            {
                var vm = new NewOperationViewModel
                {
                    CreateSuccess = false,
                    Id = _fixture.Create<string>(),
                    ORName = _fixture.Create<string>(),
                    ShowForm = false
                };
                var interactionsMock = new Mock<CheckboxInteractions>();
                interactionsMock.Object.NewOperation.RegisterHandler(interaction =>
                    interaction.SetOutput(vm));
                _fixture.Register(() => interactionsMock.Object);

                var serviceMock = _fixture.Create<Mock<CheckboxService>>();

                var viewModel = _fixture.Create<CheckboxViewModel>();
                viewModel.Scheduler = s;

                viewModel.NewOperation.Execute().Subscribe(_ =>
                {
                    serviceMock.Verify(s => s.NewOperation(It.IsAny<Operation>()), Times.Never);
                });

                s.Start();
            });
        }


        [Fact]
        public void FinishOperation_With_Active_Instruments_Decline_Finish()
        {
            new TestScheduler().With(s =>
            {
                var viewModel = SetupWithSelectedOperation(false, s);
                viewModel.SelectedOperation.Operation.OperationInstruments.Add(new OperationInstrument() { ActiveLink = true });
                viewModel.FinishOperation.Execute().Subscribe(_ =>
                {
                    Assert.NotNull(viewModel.SelectedOperation);
                    Assert.NotEqual(OperationState.FINISHED.ToString(), viewModel.SelectedOperation.State);
                    _fixture.Create<Mock<CheckboxService>>().Verify(s => s.Update(It.IsAny<Operation>()), Times.Never);
                });

                s.Start();
            });
        }

        [Fact]
        public void FinishOperation_With_Active_Instruments_Accept_Finish()
        {
            new TestScheduler().With(s =>
            {
                var viewModel = SetupWithSelectedOperation(true,s);
                viewModel.SelectedOperation.Operation.OperationInstruments.Add(new OperationInstrument { ActiveLink = true });
                viewModel.FinishOperation.Execute().Subscribe(_ =>
                {
                    Assert.NotNull(viewModel.SelectedOperation);
                    Assert.Equal(OperationState.FINISHED.ToString(), viewModel.SelectedOperation.State);
                    _fixture.Create<Mock<CheckboxService>>().Verify(s => s.Update(It.IsAny<Operation>()), Times.Once);
                });

                s.Start();
            });
        }


        [Fact]
        public void FinishOperation_With_No_Active_Instruments_Accept_Finish()
        {
            new TestScheduler().With(s =>
            {
                var viewModel = SetupWithSelectedOperation(true,s);
                viewModel.FinishOperation.Execute().Subscribe(_ =>
                {
                    Assert.NotNull(viewModel.SelectedOperation);
                    Assert.Equal(OperationState.FINISHED.ToString(), viewModel.SelectedOperation.State);
                    _fixture.Create<Mock<CheckboxService>>().Verify(s => s.Update(It.IsAny<Operation>()), Times.Once);
                });

                s.Start();
            });
        }

        [Fact]
        public void FinishOperation_With_No_Active_Instruments_Decline_Finish()
        {

            new TestScheduler().With(s =>
            {
                var viewModel = SetupWithSelectedOperation(false,s);
                viewModel.FinishOperation.Execute().Subscribe(_ =>
                {
                    Assert.NotNull(viewModel.SelectedOperation);
                    Assert.NotEqual(OperationState.FINISHED.ToString(), viewModel.SelectedOperation.State);
                    _fixture.Create<Mock<CheckboxService>>().Verify(s => s.Update(It.IsAny<Operation>()), Times.Never);
                });

                s.Start();
            });
        }


        [Fact]
        public void StartOperation_Without_Selected_Operation()
        {
            new TestScheduler().With(s =>
            {
                var viewModel = SetupWithSelectedOperation(true,s);
                viewModel.SelectedOperation = null;

                viewModel.StartOperation.CanExecute.ObserveOn(s).Subscribe(_ =>
                {
                    Assert.Null(viewModel.SelectedOperation);
                    _fixture.Create<Mock<CheckboxService>>()
                        .Verify(s => s.Update(It.IsAny<Operation>()), Times.Never);
                });
                s.Start();
            });

        }

        [Fact]
        public void StartOperation_With_Selected_Operation()
        {
            new TestScheduler().With(s =>
            {
                var viewModel = SetupWithSelectedOperation(true, s);

                viewModel.StartOperation.Execute().Subscribe(_ =>
                {
                    Assert.NotNull(viewModel.SelectedOperation);
                    Assert.Equal(OperationState.ACTIVE.ToString(), viewModel.SelectedOperation.State);
                    _fixture.Create<Mock<CheckboxService>>()
                        .Verify(s => s.Update(It.IsAny<Operation>()), Times.Once);
                });
                s.Start();
            });
        }
    }
}
