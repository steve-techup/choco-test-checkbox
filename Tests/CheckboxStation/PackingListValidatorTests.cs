using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Kernel;
using Caretag_Class.Configuration;
using Caretag_Class.Model;
using Caretag_Class.Repositories;
using CheckboxStation.Configuration;
using CheckboxStation.Services;
using DevExpress.Utils.Extensions;
using Main.Model.PackingList.Validation;
using Moq;
using Xunit;

namespace Tests.CheckboxStation
{
    /**
     * Cases to be covered:
     *
     * -> Without packlist validation (Done)
     * 1. 0 Tray, n instrumentsInPacklist, no duplicates
     * 2. 0 Tray, n instrumentsInPacklist, duplicates
     * 3. 2 Trays, 2 instrumentsInPacklist
     * 4. 0 Tray, 0 instrumentsInPacklist
     *
     * -> With packlist validation
     * 5. 1 Tray, n instrumentsInPacklist, no duplicates, OK (Done)
     * 6. 1 Tray, n instrumentsInPacklist, duplicates, OK (Done)
     * 7. 1 Tray, n+m instrumentsInPacklist, no duplicates, error (Done)
     * 8. 1 Tray, n+m instrumentsInPacklist, duplicates, error  (Done)
     * 9. 1 Tray, n-m instrumentsInPacklist, no duplicates, error (Done)
     * 10. 1 Tray, n-m instrumentsInPacklist, duplicates, error (Done)
     *
     */
    public class PackingListValidatorTests : BaseTest
    {
        public PackingListValidatorTests()
        {
            // supply as many parameters as possible
            _fixture.Customize<PackingListValidationService>(c => c.FromFactory(
                new MethodInvoker(
                    new GreedyConstructorQuery()))); 
        }

        private List<Instrument_RFID> CreateInstruments(List<string> tags, bool shouldHaveCommonDescriptionId = false)
        {
            var commonId = _fixture.Create<string>();
            var instruments = tags.Select(t =>
            {
                var instrumentDescription = _fixture.Create<Instrument_Description>();
                instrumentDescription.Description_ID = shouldHaveCommonDescriptionId ? commonId : _fixture.Create<string>();
                return new Instrument_RFID
                {
                    Description_ID = instrumentDescription.Description_ID,
                    Description_Text = _fixture.Create<string>(),
                    InstrumentDescription = instrumentDescription,
                    EPC_Nr = t
                };
            }).ToList();
            return instruments;
        }

        private List<Instrument_RFID> CreateInstrumentsWithHalfDuplicates(List<string> tags)
        {
            int n = tags.Count;
            var instruments = CreateInstruments(tags.Take(n / 2).ToList(), false)
                .Append(CreateInstruments(tags.Skip(n / 2).Take(n / 2).ToList(), true)).ToList();

            return instruments;
        }

        private void SetupInstrumentServiceWithInstruments(List<Instrument_RFID> instruments, List<string> tags)
        {
            var instrumentServiceMock = new Mock<InstrumentService>();

            instrumentServiceMock.Setup(i => i.GetByTagsWithOperationAndDescriptionAndPopulateServiceRequests(tags))
                .Returns(instruments);

            _fixture.Register(() => instrumentServiceMock.Object);
            _fixture.Register(() => instrumentServiceMock);
        }

        private void SetupEmptyCheckBoxService(int trayCount)
        {
            var checkboxServiceMock = new Mock<CheckboxService>();
            var trays = Enumerable.Range(0, trayCount).Select(_ => _fixture.Create<Tray_Packed>()).ToList();

            checkboxServiceMock.Setup(c => c.GetTrays(It.IsAny<List<string>>()))
                .Returns(trays);

            _fixture.Register(() => checkboxServiceMock.Object);
        }
        

        private Tray_Packed SetupTrayWithPacklistCheckboxService(List<Instrument_RFID> instrumentsInPacklist)
        {
            var checkboxServiceMock = new Mock<CheckboxService>();
            var packingListService = new Mock<PackingListRepository>();
            var tray = _fixture.Create<Tray_Packed>();
            tray.Description_ID = tray.TrayDescription.Description_ID.ToString();
            checkboxServiceMock.Setup(c => c.GetTrays(It.IsAny<List<string>>())).Returns(new List<Tray_Packed>()
            {
                tray
            });

            var packingListRows = instrumentsInPacklist.GroupBy(i => i.Description_ID).Select(g =>
                new PackedInstrumentWithManualQuantity
                    {DescriptionId = g.Key , Quantity = g.Count() , QuantityPackedManually = 0}).ToList();
            
            packingListService.Setup(c => c.GetPackingListAsPackedFast(It.IsAny<string>()))
                .Returns(packingListRows);
            
            _fixture.Register(() => checkboxServiceMock.Object);
            _fixture.Register(() => packingListService.Object);
            return tray;
        }
        
        private List<T> GetRandomSubset<T>(List<T> list, int n)
        {
            var random = new Random();
            var result = new List<T>();
            var listCopy = new List<T>(list);
            for (int i = 0; i < n; i++)
            {
                var index = random.Next(listCopy.Count);
                result.Add(listCopy[index]);
                listCopy.RemoveAt(index);
            }
            return result;
        }

        // validate addition of packinglistresult
        [Fact]
        public void Validate_Addition_Of_PackingListResult()
        {
            var tags = GetTags(10);
            var firstHalf = tags.Take(5).ToList();
            var secondHalf = tags.Skip(5).ToList();

            var firstHalfInstruments = CreateInstruments(firstHalf);
            var secondHalfInstruments = CreateInstruments(secondHalf);

            var appSettings = _fixture.Create<AppSettingsBase>();
            appSettings.UseApi = false;
            _fixture.Inject(appSettings);

            var checkboxSettings = _fixture.Create<CheckboxStationAppSettings>();
            checkboxSettings.Features.VerificationEnabled = false;
            _fixture.Inject(checkboxSettings);

            SetupInstrumentServiceWithInstruments(firstHalfInstruments.ToList(), firstHalf);

            SetupTrayWithPacklistCheckboxService(firstHalfInstruments.Concat(secondHalfInstruments).ToList());

            _fixture.Create<Mock<InstrumentService>>().Setup(i => 
                    i.GetByTagsWithOperationAndDescriptionAndPopulateServiceRequests(secondHalf))
                .Returns(secondHalfInstruments);
            _fixture.Create<Mock<InstrumentService>>().Setup(i =>
                    i.GetByTagsWithOperationAndDescriptionAndPopulateServiceRequests(tags))
                .Returns(firstHalfInstruments.Concat(secondHalfInstruments).ToList());
            
            _fixture.Create<Mock<InstrumentService>>().Setup(i =>
                    i.GetByTagsWithOperationAndDescriptionAndPopulateServiceRequests(It.Is((List<string> l)=> l.Count == 11)))
                .Returns(firstHalfInstruments.Concat(secondHalfInstruments).ToList());

            var validator = _fixture.Create<PackingListValidationService>();
            
            var result = validator.ValidatePackingList(firstHalf, null);
            
            var result2 = validator.ValidatePackingList(secondHalf, null);
            var sum = validator.ValidatePackingList(result.Tags.Concat( result2.Tags).ToList(), null);
            
            Assert.Equal(10, result.Lines.Count); //Total instruments
            Assert.Equal(6, result.Tags.Count);
            Assert.Equal(10, result2.Lines.Count);
            Assert.Equal(6, result2.Tags.Count);
            Assert.Equal(10, sum.Lines.Count);
            Assert.Equal(11, sum.Tags.Count);

        }

        [Theory]
        [InlineData(6, 6)]
        [InlineData(6, 4)]
        [InlineData(20, 10)]
        [InlineData(100, 10)]
        public void Validate_Tray_With_Duplicates_Missing_Instruments_Error(int n, int m)
        {
            var totalTags = GetTags(n);
            var tagsScanned = GetRandomSubset(totalTags, n-m);
            var singleInstruments = CreateInstruments(totalTags.Take(n-m).ToList());
            var duplicatedInstruments = CreateInstruments(totalTags.Skip(n-m).ToList());

            var appSettings = _fixture.Create<AppSettingsBase>();
            appSettings.UseApi = false;
            _fixture.Inject(appSettings);

            var checkboxSettings = _fixture.Create<CheckboxStationAppSettings>();
            checkboxSettings.Features.VerificationEnabled = false;
            _fixture.Inject(checkboxSettings);

            var totalInstruments = singleInstruments.Append(duplicatedInstruments).ToList();
            var instrumentsScanned = totalInstruments.Where(i => tagsScanned.Contains(i.EPC_Nr));

            SetupInstrumentServiceWithInstruments(instrumentsScanned.ToList(), tagsScanned);
            var tray = SetupTrayWithPacklistCheckboxService(totalInstruments);

            var packingListValidator = _fixture.Create<PackingListValidationService>();
            var result = packingListValidator.ValidatePackingList(tagsScanned, null);

            Assert.NotNull(result.Tray);
            Assert.Equal(tray.Description_ID, result.Tray.Description_ID.ToString());
            Assert.Equal(n, result.Lines.Count);
            Assert.Equal(ValidatedPackingList.PackingListState.NotOk, result.Result);

            var singleInstrumentRows = result.Lines.Where(r =>
                singleInstruments.Select(i => i.Description_ID).Contains(r.DescriptionId));
            var scannedSingleInstrumentRows = singleInstrumentRows.Where(r =>
                instrumentsScanned.Select(i => i.Description_ID).Contains(r.DescriptionId));

            Assert.True(singleInstrumentRows.All(r => r.Expected == 1));
            Assert.True(scannedSingleInstrumentRows.All(r => r.Actual == 1));

            var instrumentTypes = totalInstruments.Select(i => i.Description_ID).Distinct().ToList();
            var resultTypes = result.Lines.Select(r => r.DescriptionId).ToList();
            Assert.Equal(instrumentTypes, resultTypes);
        }

        [Theory]
        [InlineData(5, 5)]
        [InlineData(5, 1)]
        [InlineData(5, 10)]
        [InlineData(100, 10)]
        public void Validate_Tray_Without_Duplicates_Missing_Instruments_Error(int n, int m)
        {
            var totalTags = GetTags(n);
            var tagsScanned = totalTags.Take(n - m).ToList();
            var totalInstruments = CreateInstruments(totalTags.ToList());
            var instrumentsScanned = totalInstruments.Take(n - m).ToList();

            var checkboxSettings = _fixture.Create<CheckboxStationAppSettings>();
            checkboxSettings.Features.VerificationEnabled = false;
            _fixture.Inject(checkboxSettings);

            var appSettings = _fixture.Create<AppSettingsBase>();
            appSettings.UseApi = false;
            _fixture.Inject(appSettings);

            SetupInstrumentServiceWithInstruments(instrumentsScanned.ToList(), tagsScanned);
            var tray = SetupTrayWithPacklistCheckboxService(totalInstruments);

            var packingListValidator = _fixture.Create<PackingListValidationService>();
            var result = packingListValidator.ValidatePackingList(tagsScanned, null);

            Assert.NotNull(result.Tray);
            Assert.Equal(tray.Description_ID, result.Tray.Description_ID.ToString());
            Assert.Equal(n, result.Lines.Count);
            Assert.Equal(ValidatedPackingList.PackingListState.NotOk, result.Result);
            Assert.True(result.Lines.All(r => r.Expected == 1));
            Assert.True(result.Lines.Where(r => instrumentsScanned.Select(i => i.Description_ID).Contains(r.DescriptionId)).All(r => r.Actual == 1));
            Assert.True(result.Lines.Where(r => !instrumentsScanned.Select(i => i.Description_ID).Contains(r.DescriptionId)).All(r => r.Actual == 0));

            var instrumentTypes = totalInstruments.Select(i => i.Description_ID).Distinct().ToList();
            var resultTypes = result.Lines.Select(r => r.DescriptionId).ToList();
            Assert.Equal(instrumentTypes, resultTypes);
        }


        [Theory]
        [InlineData(1, 1)]
        [InlineData(5, 1)]
        [InlineData(5, 10)]
        [InlineData(100, 10)]
        public void Validate_Tray_With_Duplicates_Extra_Instruments_Error(int n, int m)
        {
            var tags = GetTags(n + m);
            var instruments = CreateInstruments(tags.Take(n).ToList());
            var excesssInstruments = CreateInstruments(tags.Skip(n).Take(m).ToList());
            SetupInstrumentServiceWithInstruments(instruments.Append(excesssInstruments).ToList(), tags);
            var tray = SetupTrayWithPacklistCheckboxService(instruments);

            var checkboxSettings = _fixture.Create<CheckboxStationAppSettings>();
            checkboxSettings.Features.VerificationEnabled = false;
            _fixture.Inject(checkboxSettings);

            var packingListValidator = _fixture.Create<PackingListValidationService>();
            var result = packingListValidator.ValidatePackingList(tags, null);

            Assert.NotNull(result.Tray);
            Assert.Equal(tray.Description_ID, result.Tray.Description_ID.ToString());
            Assert.Equal(n + m, result.Lines.Count);
            Assert.Equal(ValidatedPackingList.PackingListState.NotOk, result.Result);
            Assert.True(result.Lines.Where(r => instruments.Select(i => i.Description_ID)
                .Contains(r.DescriptionId)).All(r => r.Expected == 1));
            Assert.True(result.Lines.Where(r => excesssInstruments.Select(i => i.Description_ID)
                .Contains(r.DescriptionId)).All(r => r.Expected == 0));

            Assert.True(result.Lines.All(r => r.Actual == 1));

            var instrumentTypes = instruments.Append(excesssInstruments).Select(i => i.Description_ID).Distinct().ToList();
            var resultTypes = result.Lines.Select(r => r.DescriptionId).ToList();
            Assert.Equal(instrumentTypes, resultTypes);
        }

        [Theory]
        [InlineData(2, 2)]
        [InlineData(6, 2)]
        [InlineData(6, 10)]
        [InlineData(100, 10)]
        public void Validate_Tray_Without_Duplicates_Extra_Instruments_Error(int n, int m)
        {

            var appSettings = _fixture.Create<AppSettingsBase>();
            appSettings.UseApi = false;
            _fixture.Inject(appSettings);

            var checkboxSettings = _fixture.Create<CheckboxStationAppSettings>();
            checkboxSettings.Features.VerificationEnabled = false;
            _fixture.Inject(checkboxSettings);

            var tags = GetTags(n+m);
            var instruments = CreateInstrumentsWithHalfDuplicates(tags.Take(n).ToList());
            var excesssInstruments = CreateInstrumentsWithHalfDuplicates(tags.Skip(n).Take(m).ToList());            
            SetupInstrumentServiceWithInstruments(instruments.Append(excesssInstruments).ToList(), tags);
            var tray = SetupTrayWithPacklistCheckboxService(instruments);

            var packingListValidator = _fixture.Create<PackingListValidationService>();
            var result = packingListValidator.ValidatePackingList(tags, null);

            Assert.NotNull(result.Tray);
            Assert.Equal(tray.Description_ID, result.Tray.Description_ID.ToString());
            Assert.Equal(n / 2 + 1+ m / 2 + 1, result.Lines.Count);
            Assert.Equal(ValidatedPackingList.PackingListState.NotOk, result.Result);
            var instrumentRows = result.Lines.Where(r => instruments.Select(i => i.Description_ID)
                .Contains(r.DescriptionId));
            var excessInstrumentRows = result.Lines.Where(r => excesssInstruments.Select(i => i.Description_ID)
                .Contains(r.DescriptionId));

            Assert.True(instrumentRows.All(r => r.Expected == 1 || r.Expected == n/2));
            Assert.True(excessInstrumentRows.All(r => r.Expected == 0));

            Assert.True(instrumentRows.All(r => r.Actual == 1 || r.Actual == n/2));

            var instrumentTypes = instruments.Append(excesssInstruments).Select(i => i.Description_ID).Distinct().ToList();
            var resultTypes = result.Lines.Select(r => r.DescriptionId).ToList();
            Assert.Equal(instrumentTypes, resultTypes);
        }        


        [Theory]
        [InlineData(2)]
        [InlineData(6)]
        [InlineData(100)]
        public void Validate_Tray_With_Duplicates_OK(int n)
        {
            var appSettings = _fixture.Create<AppSettingsBase>();
            appSettings.UseApi = false;
            _fixture.Inject(appSettings);

            var checkboxSettings = _fixture.Create<CheckboxStationAppSettings>();
            checkboxSettings.Features.VerificationEnabled = false;
            _fixture.Inject(checkboxSettings);

            var tags = GetTags(n);
            var instruments = CreateInstrumentsWithHalfDuplicates(tags);
            SetupInstrumentServiceWithInstruments(instruments, tags);
            var tray = SetupTrayWithPacklistCheckboxService(instruments);

            var packingListValidator = _fixture.Create<PackingListValidationService>();
            var result = packingListValidator.ValidatePackingList(tags, null);

            Assert.NotNull(result.Tray);
            Assert.Equal(tray.Description_ID, result.Tray.Description_ID.ToString());
            Assert.Equal(n / 2 + 1, result.Lines.Count);
            Assert.Equal(ValidatedPackingList.PackingListState.Ok, result.Result);
            Assert.True(result.Lines.All(r => r.Expected == 1 || r.Expected == n/2));
            Assert.True(result.Lines.All(r => r.Actual == 1 || r.Expected == n/2));

            var instrumentTypes = instruments.Select(i => i.Description_ID).Distinct().ToList();
            var resultTypes = result.Lines.Select(r => r.DescriptionId).ToList();
            Assert.Equal(instrumentTypes, resultTypes);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(100)]
        public void Validate_Tray_Without_Duplicates_OK(int n)
        {

            var tags = GetTags(n);
            var instruments = CreateInstruments(tags);
            SetupInstrumentServiceWithInstruments(instruments, tags);
            var tray = SetupTrayWithPacklistCheckboxService(instruments);

            var checkboxSettings = _fixture.Create<CheckboxStationAppSettings>();
            checkboxSettings.Features.VerificationEnabled = false;
            _fixture.Inject(checkboxSettings);

            var packingListValidator = _fixture.Create<PackingListValidationService>();
            var result = packingListValidator.ValidatePackingList(tags, null);

            Assert.NotNull(result.Tray);
            Assert.Equal(tray.Description_ID, result.Tray.Description_ID.ToString());
            Assert.Equal(n, result.Lines.Count);
            Assert.Equal(ValidatedPackingList.PackingListState.Ok, result.Result);
            Assert.True(result.Lines.All(r => r.Expected == 1));
            Assert.True(result.Lines.All(r => r.Actual == 1));
            var instrumentTypes = instruments.Select(i => i.Description_ID).ToList();
            var resultTypes = result.Lines.Select(r => r.DescriptionId).ToList();
            Assert.Equal(instrumentTypes, resultTypes);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(100)]
        public void Validate_Instruments_No_Duplicates_No_Tray(int n)
        {
            var tags = GetTags(n);
            var instruments = CreateInstruments(tags, false);
            SetupInstrumentServiceWithInstruments(instruments, tags);
            SetupEmptyCheckBoxService(0);

            var checkboxSettings = _fixture.Create<CheckboxStationAppSettings>();
            checkboxSettings.Features.VerificationEnabled = false;
            _fixture.Inject(checkboxSettings);

            var packingListValidator = _fixture.Create<PackingListValidationService>();
            var result = packingListValidator.ValidatePackingList(tags, null);
            
            Assert.Null(result.Tray);
            Assert.Equal(n, result.Lines.Count);
            Assert.Equal(ValidatedPackingList.PackingListState.NoTray, result.Result);
            Assert.True(result.Lines.All(r => r.Expected == 0));
            Assert.True(result.Lines.All(r => r.Actual == 1));
        }

        [Theory]
        [InlineData(4)]
        [InlineData(100)]
        public void Validate_Instruments_With_Duplicates_No_Tray(int n)
        {
            var tags = GetTags(n);
            var instruments = CreateInstrumentsWithHalfDuplicates(tags);
            SetupInstrumentServiceWithInstruments(instruments, tags);
            SetupEmptyCheckBoxService(0);

            var checkboxSettings = _fixture.Create<CheckboxStationAppSettings>();
            checkboxSettings.Features.VerificationEnabled = false;
            _fixture.Inject(checkboxSettings);

            var packingListValidator = _fixture.Create<PackingListValidationService>();
            var result = packingListValidator.ValidatePackingList(tags, null);

            Assert.Null(result.Tray);
            Assert.Equal(n / 2 + 1, result.Lines.Count);
            Assert.Equal(ValidatedPackingList.PackingListState.NoTray, result.Result);
            Assert.True(result.Lines.All(r => r.Expected == 0));
            Assert.True(result.Lines.All(r => r.Actual == 1 || r.Actual == n/2));
        }


        [Theory]
        [InlineData(4)]
        [InlineData(100)]
        public void Validate_Location_Set_Correctly(int n)
        {
            var tags = GetTags(n);
            var instruments = CreateInstrumentsWithHalfDuplicates(tags);
            SetupInstrumentServiceWithInstruments(instruments, tags);
            SetupEmptyCheckBoxService(0);

            //set up mock AppSettingsBase with Location set to random value
            var appSettings = _fixture.Create<AppSettingsBase>();
            _fixture.Inject(appSettings); //Singletonify appSettings

            var checkboxSettings = _fixture.Create<CheckboxStationAppSettings>();
            checkboxSettings.Features.VerificationEnabled = false;
            _fixture.Inject(checkboxSettings);

            var packingListValidator = _fixture.Create<PackingListValidationService>();
            var result = packingListValidator.ValidatePackingList(tags, null);

            Assert.Equal(appSettings.StationUniqueID, result.Location);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(100)]
        public void Validate_Two_Trays_N_Instruments(int n)
        {
            var tags = GetTags(n);
            var instruments = CreateInstruments(tags, false);
            SetupInstrumentServiceWithInstruments(instruments, tags);
            SetupEmptyCheckBoxService(2);

            var checkboxSettings = _fixture.Create<CheckboxStationAppSettings>();
            checkboxSettings.Features.VerificationEnabled = false;
            _fixture.Inject(checkboxSettings);

            var packingListValidator = _fixture.Create<PackingListValidationService>();
            var result = packingListValidator.ValidatePackingList(tags, null);

            Assert.Null(result.Tray);
            Assert.Equal(n, result.Lines.Count);
            Assert.Equal(ValidatedPackingList.PackingListState.MoreThanOneTray, result.Result);
            Assert.True(result.Lines.All(r => r.Expected == 0));
            Assert.True(result.Lines.All(r => r.Actual == 1));
        }
    }
}
