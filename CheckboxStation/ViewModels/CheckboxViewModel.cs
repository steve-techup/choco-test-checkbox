using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using global::System.Resources;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using Caretag_Class.Logging;
using Caretag_Class.Model;
using Caretag_Class.Model.Service;
using Caretag_Class.ReactiveUI;
using Caretag_Class.ReactiveUI.ViewModels;
using CheckboxStation.Configuration;
using CheckboxStation.Infrastructure;
using CheckboxStation.Services;
using CheckboxStation.Views;
using DynamicData.Binding;
using Main.Model.PackingList.Validation;
using Main.ReactiveUI.Interactions;
using NodaTime;
using ReactiveUI;
using RFIDAbstractionLayer;
using RFIDAbstractionLayer.ReactiveExtension;
using RFIDAbstractionLayer.Readers;
using Serilog;
using Surgical_Admin.Interactions;
using static CheckboxStation.Views.ViewHelpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Main.Model.PackingList.Validation.ValidatedPackingList;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using CheckboxStation.Reporting;
using CheckboxStation.Verification;
using System.Diagnostics.Metrics;
using RFIDAbstractionLayer.TagEncoding;

namespace CheckboxStation.ViewModels
{

    public enum CheckState
    {
        CanCheckIn,
        CanCheckOut,
        Mix,
        NoInstruments
    }

    public class CheckboxViewModel : ReactiveObject
    {
        private readonly CheckInViewModelFactory _checkInViewModelFactory;
        private readonly PackingListValidationService _packingListValidationService;
        private readonly CommonInteractions _commonInteractions;
        private readonly CheckStateService _checkStateService;
        private readonly ISet<string> _uniqueScannedTags = new HashSet<string>();
        private ResourceManager Local_RM = new ResourceManager("CheckBoxStation.WinFormStrings", typeof(CheckboxViewModel).Assembly);
        private Guid? _currentScanningSession;
        private readonly VerboseLogger _verboseLogger;
        private List<UnpackedItem> _unpackedItems = new List<UnpackedItem>();
        private string _currentTrayEpc = string.Empty;
        private Tray_Description _currentTray;
        private readonly ReportingService _reportingService;
        private bool _updateReportSessionNumber = true;
        private List<VerificationReportItem> _verificationReportItems;
        private List<string> _verificationSessionTags;

        public Duration ScanDelay { get; set; } = Duration.FromSeconds(6);


        public IScheduler Scheduler { get; set; }

        public CheckboxViewModel(CheckboxService checkboxService,
            InstrumentService instrumentService,
            ScanEventService scanEventService,
            CheckboxStationAppSettings appSettings,
            RFIDReaderCollection rfidReaderCollection,
            CheckInViewModelFactory checkInViewModelFactory,
            CheckboxInteractions checkboxInteractions,
            CommonInteractionsFactory commonInteractionsFactory,
            PackingListValidationService packingListValidationService,
            CheckStateService checkStateService, ILogger logger,
            VerboseLogger verboseLogger,
            ReportingService reportingService,
            IScheduler? scheduler = null)
        {
            PackingListViewModel = new TouchscreenPackingListViewModel
            {
                PackingListMode = TouchscreenPackingListViewModel.Mode.Checkbox
            };
            _commonInteractions = commonInteractionsFactory.Create(RxApp.MainThreadScheduler);
            _checkInViewModelFactory = checkInViewModelFactory;
            _packingListValidationService = packingListValidationService;
            _checkStateService = checkStateService;
            var interactions1 = checkboxInteractions;
            Features = appSettings.Features;
            Scheduler = scheduler ?? RxApp.MainThreadScheduler; //UI thread is standard
            _verboseLogger = verboseLogger;
            _reportingService = reportingService;

            var checkboxService1 = checkboxService;
            var instrumentService1 = instrumentService;
            var scanEventService1 = scanEventService;

            //Log application info
            _verboseLogger.LogDatabaseSettings(appSettings.ConnectionStrings.SQLServer);
            _verboseLogger.LogApplicationVersion(Application.ProductVersion);

            if (Features.VerificationEnabled)
            {
                _verificationReportItems = new List<VerificationReportItem>();
                _verificationSessionTags = new List<string>();
            }

            var scanNotInProgress = this.WhenAnyValue(vm => vm.ScanProgress, progress => progress == 100);

            this.ObservableForProperty(vm => vm.ValidatedPackingList).Subscribe(async _ =>
            {
                if (ValidatedPackingList == null)
                    return;

                ViewHelpers.CheckState checkState = ViewHelpers.CheckState.CheckedOut;
                var rows = ValidatedPackingList.Lines.Select(row =>
                {
                    var links = row.Instruments.SelectMany(i => i.OperationInstruments).Where(oi => oi.ActiveLink)
                        .ToList();
                    checkState = links.Any() ? ViewHelpers.CheckState.CheckedIn : ViewHelpers.CheckState.CheckedOut;

                    Tray_PackList unpackedItem = null;


                    if (_unpackedItems.Any())
                    {
                        var existingRow = PackingListViewModel.PackingListRowsCollection.Where(r => r.DescriptionId == row.InstrumentDescription?.Description_ID).FirstOrDefault();
                        unpackedItem = _unpackedItems.FirstOrDefault(ui => ui.Instrument_Descrip_ID == row.InstrumentDescription?.Description_ID);

                        if (existingRow != null)
                        {
                            foreach (var instrument in existingRow.PackedInstruments)
                            {
                                if (!row.Instruments.Any(i => i.EPC_Nr == instrument.EPC_Nr))
                                    row.Instruments.Add(instrument);
                            }
                        }

                    }

                    return new TouchscreenPackingListViewModel.PackingListRowViewModel
                    {
                        Quantity = unpackedItem != null ? (int)unpackedItem.Number : row.Expected,
                        PackedInstruments = row.Instruments,
                        InstrumentDescription = row.Description,
                        QuantityPackedManually = row.PackedManually ? row.Actual : 0,
                        Status = checkState == ViewHelpers.CheckState.CheckedIn ? "C.In" : "C.Out",
                        CanPackManually = row.PackedManually || appSettings.Features.VerificationEnabled,
                        DescriptionId = row.DescriptionId,
                        NotPacked = unpackedItem != null,
                        InstrumentVendor = row.InstrumentDescription?.Instrument_Company
                    };
                }).ToList();

                if (_unpackedItems.Any())
                {
                    foreach (var item in _unpackedItems)
                    {
                        var existingRow = PackingListViewModel.PackingListRowsCollection.Where(r => r.DescriptionId == item.Instrument_Descrip_ID).FirstOrDefault();

                        if (existingRow != null)
                        {
                            existingRow.NotPacked = true;
                            existingRow.Quantity = (int)item.Number;
                        }
                        else
                        {
                            if (!rows.Any(r => r.DescriptionId == item.Instrument_Descrip_ID))
                            {
                                rows.Add(new TouchscreenPackingListViewModel.PackingListRowViewModel
                                {
                                    Quantity = (int)item.Number,
                                    PackedInstruments = new List<Instrument_RFID>(),
                                    InstrumentDescription = item.InstrumentDescription.GetFullDescription(),
                                    QuantityPackedManually = 0,
                                    Status = checkState == ViewHelpers.CheckState.CheckedIn ? "C.In" : "C.Out",
                                    CanPackManually = item.InstrumentDescription.RfidUntaggable || appSettings.Features.VerificationEnabled,
                                    DescriptionId = item.Instrument_Descrip_ID,
                                    NotPacked = true,
                                    InstrumentVendor = item.InstrumentDescription?.Instrument_Company
                                });
                            }
                        }
                    }
                }

                PackingListViewModel.UpsertPackingListRows(rows);

            });

            SingleScan = ReactiveCommand.CreateFromObservable<Tuple<int, int>, ValidatedPackingList>(param =>
            {
                // call _uniqueScannedTags.Clear to clear the list of scanned tags

                var scanNumber = param.Item1;
                var totalScan = param.Item2;

                if (scanNumber == 1)
                {
                    _uniqueScannedTags.Clear();
                    TotalTagsScanned = 0;
                }
                // Start reading
                var unSubscribe = rfidReaderCollection.SubscribeAsObservable(Scheduler).Subscribe(results =>
                    {
                        lock (_uniqueScannedTags)
                        {
                            foreach (var readingResult in results)
                            {
                                _uniqueScannedTags.Add(readingResult);
                                TotalTagsScanned = _uniqueScannedTags.Count;

                                if (Features.VerificationEnabled && !_verificationSessionTags.Contains(readingResult))
                                    _verificationSessionTags.Add(readingResult);
                            }
                        }
                    });

                var elapsedProgress = (int)Math.Round((double)(param.Item1 - 1) * 100 / param.Item2);

                // Delay for the specified amount of time
                return RfidExtension.DelayAndReport(ScanDelay, x =>
                    {
                        ScanProgress = elapsedProgress + x / param.Item2;
                    }, Scheduler)
                    .ObserveOn(Scheduler)
                    .LastAsync() //Wait until sequence is complete before continuing
                    .Select(_ =>
                    {
                        var tags = _uniqueScannedTags.ToList();

                        InstrumentLifecycleRfids = instrumentService1.GetByTagsWithOperationAndDescriptionAndPopulateServiceRequests(tags);
                        SelectedInstrumentLifecycleRfid = null;

                        var result = packingListValidationService.ValidatePackingList(tags, null);

                        //Log only if it is the last scan to prevent duplicates
                        if (scanNumber == totalScan)
                        {
                            _verboseLogger.LogScanResult(InstrumentLifecycleRfids, result, tags);
                        }

                        return result;
                    })
                    .Finally(() =>
                    {
                        // Stop reading
                        unSubscribe.Dispose();
                        if (scanNumber == totalScan)
                        {
                            _uniqueScannedTags.Clear();
                        }
                    });
            }, null, Scheduler);

            Scan = ReactiveCommand.CreateFromObservable(() =>
            {
                _currentTray = null;
                _currentTrayEpc = null;
                _unpackedItems = new List<UnpackedItem>();
                _currentScanningSession = Guid.NewGuid();
                _verboseLogger.Log($"Clicked on \"Scan\" with session {_currentScanningSession}");

                if (Features.VerificationEnabled)
                {
                    _updateReportSessionNumber = true;
                    _verificationReportItems.Clear();
                    _verificationSessionTags.Clear();
                }

                ValidatedPackingList = null;
                PackingListViewModel.Clear();
                ScanProgress = 0;
                var totalScans = 2;
                var param = new Tuple<int, int>(1 // scan number
                    , totalScans //total
                    );

                return SingleScan.Execute(param).Select(result =>
                    {
                        var validationResult = packingListValidationService.ValidatePackingList(result.Tags, null);

                        if (validationResult.TrayEPC != null && _currentTrayEpc != validationResult.TrayEPC)
                        {
                            _currentTrayEpc = validationResult.TrayEPC;
                            _currentTray = validationResult.Tray;
                        }

                        if (appSettings.Features.VerificationEnabled && _currentTray != null)
                        {
                            _unpackedItems = packingListValidationService.GetUnpackedPacklistItems(_currentTray, _currentTrayEpc)
                                                                         .Select(ui => UnpackedItem.FromTrayPacklistItem(ui)).ToList();
                        }

                        ValidatedPackingList = validationResult;

                        return Unit.Default;

                    }).SelectMany(_ => ScanExtra.Execute(new Tuple<bool, int, int, bool>(true, 2, totalScans, false))).Delay(TimeSpan.FromSeconds(1), Scheduler)
                        .Finally(() =>
                            ScanProgress = 100);
            }, scanNotInProgress, Scheduler);

            ScanExtra = ReactiveCommand.CreateFromObservable<Tuple<bool, int, int, bool>, Unit>(param =>
            {
                //If it is an actual button click
                if (param.Item4)
                {
                    _verboseLogger.Log($"Clicked on \"Scan extra\" with session {_currentScanningSession}");

                    if (Features.VerificationEnabled)
                        _updateReportSessionNumber = false;
                }
                var rememberTray = param.Item1;
                var scanNumber = param.Item2;
                var totalScan = param.Item3;

                if (scanNumber == 1)
                    ScanProgress = 0;

                return SingleScan.Execute(new Tuple<int, int>(scanNumber, totalScan)).Select(result =>
                {
                    if (rememberTray && string.IsNullOrWhiteSpace(result.TrayEPC))
                        result.TrayEPC = ValidatedPackingList?.TrayEPC;

                    var tempValidationresult = new ValidatedPackingList();

                    if (ValidatedPackingList != null && ValidatedPackingList.TrayEPC == result.TrayEPC)
                    {
                        tempValidationresult = packingListValidationService.ValidatePackingList(ValidatedPackingList.Tags.Concat(result.Tags).Distinct().ToList(), ValidatedPackingList);
                    }

                    else
                        tempValidationresult = packingListValidationService.ValidatePackingList(result.Tags, null);


                    if (tempValidationresult.TrayEPC != null && _currentTrayEpc != tempValidationresult.TrayEPC)
                    {
                        _currentTrayEpc = tempValidationresult.TrayEPC;
                        _currentTray = tempValidationresult.Tray;
                    }

                    if (appSettings.Features.VerificationEnabled && _currentTray != null)
                    {
                        _unpackedItems = packingListValidationService.GetUnpackedPacklistItems(_currentTray, _currentTrayEpc)
                                                                     .Select(ui => UnpackedItem.FromTrayPacklistItem(ui)).ToList();
                    }

                    ValidatedPackingList = new ValidatedPackingList(); // force update
                    ValidatedPackingList = tempValidationresult;



                    if (scanNumber == totalScan)
                    {
                        packingListValidationService.Save(ValidatedPackingList);
                        scanEventService1.Save(result.Tags);
                    }
                    return Unit.Default;
                }).Finally(async () =>
                {
                    if (scanNumber == totalScan) //Direct call
                    {
                        ScanProgress = 100;

                        if (Features.VerificationEnabled)
                            await GenerateReport.Execute();
                    }
                });
            }, scanNotInProgress, Scheduler);

            SingleScan.ThrownExceptions.Merge(Scan.ThrownExceptions)
                .Throttle(TimeSpan.FromMilliseconds(250), RxApp.MainThreadScheduler)
                .Subscribe(error =>
                {
                    logger.Error(error, "Exception in viewModel while scanning. ");
                    _commonInteractions.ExceptionInteraction.Handle(error).Subscribe();
                });

            var checkState = this.WhenAnyValue(vm => vm.ValidatedPackingList, validatedPackingList =>
            {
                if (validatedPackingList == null || validatedPackingList.Lines.Count == 0)
                    return CheckState.NoInstruments;
                var operationInstruments = validatedPackingList.Lines
                    .SelectMany(row => row.Instruments.Select(i => i.OperationInstruments.ToList())).ToList();

                if (operationInstruments.All(oi => oi.Any(o => o.ActiveLink)))
                    return CheckState.CanCheckOut;
                if (operationInstruments.All(oi => oi.All(o => !o.ActiveLink)))
                    return CheckState.CanCheckIn;
                return CheckState.CanCheckIn;
            });

            checkState.Subscribe(x =>
            {
                if (x == CheckState.Mix)
                    _commonInteractions.Confirm.Handle(new CaretagMessageBoxArguments
                    {
                        Options = CaretagMessageBoxOptions.Ok,
                        IsWarning = true,
                        Message =
                            Local_RM.GetString("Instrument mix"),
                        Title = Local_RM.GetString("Mix of check-in/check-out")
                    });
            });

            CheckIn = ReactiveCommand.CreateFromObservable(() =>
            {
                var model = _checkInViewModelFactory.Get(ValidatedPackingList);
                model.TrayName = TrayStatus;
                return interactions1.CheckIn.Handle(model).Select(_ =>
                {
                    //reload instruments
                    ValidatedPackingList = packingListValidationService.ValidatePackingList(_uniqueScannedTags.ToList(), null);
                    return new Unit();
                });
            }, checkState.Select(c => c == CheckState.CanCheckIn), Scheduler);

            CheckOut = ReactiveCommand.CreateFromObservable(() =>
            {
                return Observable.Start(() =>
                {
                    _checkStateService.CheckInstrumentsOut(InstrumentLifecycleRfids);
                }, Scheduler).SelectMany((_, _) =>
                    _commonInteractions.Confirm.Handle(new CaretagMessageBoxArguments
                    {
                        Options = CaretagMessageBoxOptions.Ok,
                        IsWarning = false,
                        Message = Local_RM.GetString("Instrument check out"),
                        Title = Local_RM.GetString("Success")
                    })
                        .Select(
                            m =>
                            {
                                ValidatedPackingList = packingListValidationService.ValidatePackingList(_uniqueScannedTags.ToList(), null);
                                return new Unit();
                            })
                );

            }, checkState.Select(c => c == CheckState.CanCheckOut), Scheduler);

            // canBeSentToService is an observable which is true when SelectedInstrumentLifecycleRfid.ServiceRequest does not contain any active or external service requests
            var canBeSentToService = this.WhenAnyValue(vm => vm.SelectedInstrumentLifecycleRfid.ServiceRequests, vm => vm.UpdateCounter, (sr, _) =>
            {
                return sr.All(s => s.State == ServiceState.RESOLVED.ToString());
            });

            SendInstrumentToService = ReactiveCommand.CreateFromObservable(() =>
            {
                var sr = instrumentService1.SendToService(SelectedInstrumentLifecycleRfid.EPC_Nr,
                    SelectedInstrumentLifecycleRfid.Instrument_ID);
                if (sr != null)
                {
                    SelectedInstrumentLifecycleRfid.ServiceRequests.Add(sr);

                    var interaction = _commonInteractions.Confirm.Message(Local_RM.GetString("Success"),
                        Local_RM.GetString("Instruments sent to service"));

                    interaction.ObserveOn(Scheduler).Subscribe();
                    UpdateCounter++;

                }
                return Observable.Return(Unit.Default);
            }, canBeSentToService, Scheduler);

            var canStartOperation = this.WhenAnyValue(vm => vm.SelectedOperation.State,
                (state) => state == OperationState.NEW.ToString());


            var canFinishOperation = this.WhenAnyValue(vm => vm.SelectedOperation.State,
                (state) => state == OperationState.ACTIVE.ToString());

            StartOperation = ReactiveCommand.Create(() =>
                {
                    SelectedOperation.State = OperationState.ACTIVE.ToString();
                    checkboxService.Update(SelectedOperation.Operation);
                }, canStartOperation
            );

            FinishOperation = ReactiveCommand.CreateFromObservable(() =>
            {
                var result = SelectedOperation.Operation.OperationInstruments.Count(i => i.ActiveLink) > 0
                    ? _commonInteractions.Confirm.Handle(new CaretagMessageBoxArguments
                    {
                        Options = CaretagMessageBoxOptions.OkCancel,
                        IsWarning = true,
                        Message =
                            Local_RM.GetString("Not all checked out"),
                        Title = Local_RM.GetString("Finish operation")
                    })
                    : _commonInteractions.Confirm.Handle(new CaretagMessageBoxArguments
                    {
                        Options = CaretagMessageBoxOptions.OkCancel,
                        IsWarning = false,
                        Message = Local_RM.GetString("All checked out"),
                        Title = Local_RM.GetString("Finish operation")
                    });


                return result.SelectMany(r =>
                {
                    if (r == CaretagMessageBoxResult.Ok)
                    {
                        SelectedOperation.State = OperationState.FINISHED.ToString();
                        checkboxService.Update(SelectedOperation.Operation);

                        return _commonInteractions.Confirm.Handle(new CaretagMessageBoxArguments
                        {
                            Options = CaretagMessageBoxOptions.Ok,
                            IsWarning = false,
                            Message = Local_RM.GetString("Operation finished!"),
                            Title = Local_RM.GetString("Success")
                        }).Select(x => new Unit());
                    }
                    else
                        return Observable.Return(new Unit());
                });
            }, canFinishOperation);

            NewOperation = ReactiveCommand.CreateFromObservable(() =>
            {
                return interactions1.NewOperation.Handle(new Unit()).ObserveOn(Scheduler).Select(vm =>
                {
                    if (vm.CreateSuccess)
                    {
                        var operation = new Operation
                        {
                            OperatingRoom = vm.ORName,
                            OperationId = vm.Id,
                            Timestamp = DateTimeOffset.Now,
                            State = OperationState.NEW.ToString()
                        };
                        checkboxService.NewOperation(operation);

                        UpdateCounter++; //Signal change -- this is slightly hacky and costs an unnecessary DB roundtrip. Ideally would be implemented as a reactive list. 

                    }
                    return new Unit();
                });

            });

            InspectOperationInstruments = ReactiveCommand.Create(() =>
            {
                var instrumentList = new InstrumentList(SelectedOperation, checkboxService1);
                instrumentList.ShowDialog();
            });

            //Dependent properties

            _trayStatus = this.WhenAnyValue(vm => vm.ValidatedPackingList, validatedPackingList =>
                {
                    if (validatedPackingList == null)
                        return Local_RM.GetString("No tray!");

                    return validatedPackingList.Result switch
                    {
                        ValidatedPackingList.PackingListState.MoreThanOneTray => Local_RM.GetString(
                            "More trays scanned"),
                        ValidatedPackingList.PackingListState.NoTray => Local_RM.GetString("No tray!"),
                        _ => validatedPackingList.Tray?.Tray_Name,
                    };
                }

            ).ToProperty(this, x => x.TrayStatus);

            _totalInstrumentsCounted = PackingListViewModel.PackingListRowsCollection.ToObservableChangeSet().Select(_ =>
                    PackingListViewModel.PackingListRowsCollection.Sum(r => r.TotalPacked))
                .ToProperty(this, vm => vm.TotalInstrumentsCounted);

            _expectedInstrumentCount = PackingListViewModel.PackingListRowsCollection.ToObservableChangeSet().Select(_ =>
                            PackingListViewModel.PackingListRowsCollection.Sum(r => r.Quantity))
                .ToProperty(this, vm => vm.ExpectedInstrumentCount);

            _packingListState = Observable.CombineLatest(PackingListViewModel.PackingListRowsCollection.ToObservableChangeSet(),
                    this.WhenAnyValue(vm => vm.ValidatedPackingList), (changeset, vl) => new { changeset, vl })
                .Select(r =>
                {
                    if (ValidatedPackingList == null)
                        return PackingListState.NoTray;

                    if (r.changeset.HasCountChanged())
                        return ValidatedPackingList.Result; //We only want changes when the list is already fully loaded

                    if (ValidatedPackingList.Result == PackingListState.NotOk ||
                        ValidatedPackingList.Result == PackingListState.Ok)
                    {

                        var changes = r.changeset.Select(c => c.Item.Current).Where(x => x != null).ToList();
                        //update the corresponding elements in the validated packing list with the manually packed instruments from changes
                        changes.ForEach(change =>
                        {
                            var line = ValidatedPackingList.Lines.FirstOrDefault(l => change.DescriptionId == l.DescriptionId);
                            if (line != null)
                                line.Actual = change.TotalPacked;
                            else if (Features.VerificationEnabled)
                            {
                                var existingRow = PackingListViewModel.PackingListRowsCollection.Where(r => r.DescriptionId == change.DescriptionId).FirstOrDefault();
                                if (existingRow != null)
                                    existingRow.QuantityPackedManually = change.TotalPacked;

                                if (_unpackedItems != null && _unpackedItems.Any())
                                {
                                    var unpackedItem = _unpackedItems.Where(ui => ui.Instrument_Descrip_ID == change.DescriptionId).FirstOrDefault();
                                    if (unpackedItem != null)
                                        unpackedItem.ManuallyPackedCount = change.TotalPacked;
                                }
                            }
                        });
                        ValidatedPackingList.ValidateResult();

                        if (Features.VerificationEnabled)
                            Task.Run(async () => await GenerateReport.Execute());
                    }
                    return ValidatedPackingList.Result;
                })
                .ToProperty(this, vm => vm.PackingListState);

            _operations = this.WhenAnyValue(vm => vm.From, vm => vm.To,
                    vm => vm.UpdateCounter, vm => vm.ShowFinishedOperations,
                    (from, to, added, showFinishedOperations) =>
                        checkboxService.GetOperations(@from, to.AddDays(1), showFinishedOperations)
                            .Select(op => new OperationViewModel(op)).ToList())
                .ToProperty(this, x => x.Operations);

            _checkedInInstruments = this.WhenAnyValue(vm => vm.SelectedOperation,
                op => op?.Operation.OperationInstruments?.Count(i => i.ActiveLink) ?? 0)
                .ToProperty(this, x => x.CheckedInInstruments);

            _checkedOutInstruments = this.WhenAnyValue(vm => vm.SelectedOperation,
                    op => op?.Operation.OperationInstruments?.Count(i => !i.ActiveLink) ?? 0)
                .ToProperty(this, x => x.CheckedOutInstruments);

            this.WhenValueChanged(vm => vm.SelectedInstrumentLifecycleRfid)
                .Subscribe(m =>
                {
                    InstrumentScanEvents = m == null ? new List<ScanEvent>() : scanEventService1.GetByTag(m.EPC_Nr);
                });

            GenerateReport = ReactiveCommand.CreateFromTask(async () =>
            {
                // Save scan data into CSV file
                if (Features.VerificationEnabled)
                {
                    _verificationReportItems.Clear();

                    if (ValidatedPackingList != null)
                    {

                        foreach (var line in ValidatedPackingList.Lines)
                        {
                            // Manually packed and Not detected (grouped row)
                            if (line.Instruments.Count == 0)
                            {
                                _verificationReportItems.Add(new VerificationReportItem
                                {
                                    DateTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"),
                                    TrayUDI = _currentTrayEpc,
                                    TrayName = _currentTray?.Tray_Name,
                                    ArticleUDI = "-",
                                    ArticleSku = line.DescriptionId,
                                    ArticleName = line.InstrumentDescription?.Description_Name,
                                    Brand = line.InstrumentDescription?.Instrument_Company,
                                    Quantity = line.Actual,
                                    Expected = line.Expected,
                                    FoundStatus = line.Actual == 0 ? "Instrument not detected" : "Instrument not detected via RFID, manually updated"
                                });
                            }
                            // Instruments not part of the packset (one row per item)
                            else if (line.Expected == 0)
                            {
                                foreach (var instrument in line.Instruments)
                                {
                                    _verificationReportItems.Add(new VerificationReportItem
                                    {
                                        DateTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"),
                                        TrayUDI = _currentTrayEpc,
                                        TrayName = _currentTray?.Tray_Name,
                                        ArticleUDI = instrument.EPC_Nr,
                                        ArticleSku = line.DescriptionId,
                                        ArticleName = line.InstrumentDescription?.Description_Name,
                                        Brand = line.InstrumentDescription?.Instrument_Company,
                                        Quantity = 1,
                                        Expected = 0,
                                        FoundStatus = "Valid new instrument (not part of the packing set)"
                                    });
                                }
                            }
                            // Partially of fully detected (one row per item)
                            else
                            {
                                for (var i = 0; i < line.Expected; i++)
                                {
                                    var instrument = i < line.Instruments.Count ? line.Instruments[i] : null;

                                    _verificationReportItems.Add(new VerificationReportItem
                                    {
                                        DateTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"),
                                        TrayUDI = _currentTrayEpc,
                                        TrayName = _currentTray?.Tray_Name,
                                        ArticleUDI = instrument != null ? instrument.EPC_Nr : "-",
                                        ArticleSku = line.DescriptionId,
                                        ArticleName = line.InstrumentDescription?.Description_Name,
                                        Brand = line.InstrumentDescription?.Instrument_Company,
                                        Quantity = instrument != null ? 1 : 0,
                                        Expected = 1,
                                        FoundStatus = instrument != null ? "Instrument detected" : "Instrument not detected"
                                    });
                                }
                            }
                        }
                        // Missing (not packed) (grouped row)
                        if (_unpackedItems != null)
                        {
                            foreach (var item in _unpackedItems)
                            {
                                _verificationReportItems.Add(new VerificationReportItem
                                {
                                    DateTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"),
                                    TrayUDI = _currentTrayEpc,
                                    TrayName = _currentTray?.Tray_Name,
                                    ArticleUDI = "-",
                                    ArticleSku = item.Instrument_Descrip_ID,
                                    ArticleName = item.InstrumentDescription?.Description_Name,
                                    Brand = item.InstrumentDescription?.Instrument_Company,
                                    Quantity = item.ManuallyPackedCount,
                                    Expected = (int)item.Number,
                                    FoundStatus = "Instrument missing (comparing with PackSet)"
                                });
                            }
                        }
                    }

                    var previouslyScannedInstruments = PackingListViewModel.PackingListRowsCollection.Where(i => !_verificationReportItems.Any(vi => vi.ArticleSku == i.DescriptionId))
                                                                                                     .ToList();
                    // Instruments not part of the packset scanned with the previous scan
                    foreach (var item in previouslyScannedInstruments)
                    {
                        foreach (var instrument in item.PackedInstruments)
                        {
                            _verificationReportItems.Add(new VerificationReportItem
                            {
                                DateTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"),
                                TrayUDI = _currentTrayEpc,
                                TrayName = _currentTray?.Tray_Name,
                                ArticleUDI = instrument.EPC_Nr,
                                ArticleSku = item.DescriptionId,
                                ArticleName = item.InstrumentDescription,
                                Brand = item.InstrumentVendor,
                                Quantity = 1,
                                Expected = 0,
                                FoundStatus = "Valid new instrument (not part of the packing set)"
                            });
                        }
                    }

                    // Not recognized EPCs
                    var notRecognizedEpcs = _verificationSessionTags.Where(t => !_verificationReportItems.Any(vi => vi.ArticleUDI == t || vi.TrayUDI == t)).ToList();

                    foreach (var epc in notRecognizedEpcs)
                    {
                        var rfidEpc = new RfidEPC(epc);
                        _verificationReportItems.Add(new VerificationReportItem
                        {
                            DateTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"),
                            TrayUDI = _currentTrayEpc,
                            TrayName = _currentTray?.Tray_Name,
                            ArticleUDI = epc,
                            ArticleSku = "-",
                            ArticleName = "-",
                            Brand = "-",
                            Quantity = 1,
                            Expected = 0,
                            FoundStatus = rfidEpc.ValidCaretagEPC ? 
                                            "Other RFID codes (maybe instruments, but not in the database)" :
                                            "EPC Tag not programmed yet. Allocate to a specific asset"
                        });
                    }

                    if (_verificationReportItems.Count > 0)
                    {
                        await _reportingService.GenerateVerificationCsv(_verificationReportItems, _updateReportSessionNumber);
                        _updateReportSessionNumber = false;
                    }

                }
            }, scanNotInProgress, Scheduler);

            SendEmailReport = ReactiveCommand.CreateFromTask(() =>
            {
                return _reportingService.SendVerificationReportEmail(_verificationReportItems);
            }, scanNotInProgress, Scheduler);

            GenerateHtmlReport = ReactiveCommand.CreateFromTask(async () =>
            {
                try
                {
                    var result = await _reportingService.GenerateHtmlReport(_verificationReportItems);
                    await _commonInteractions.Confirm.Handle(new CaretagMessageBoxArguments
                    {
                        Options = CaretagMessageBoxOptions.Ok,
                        Title = "Info",
                        Message = $"The report file has been successfully generated (session {result.Item1}, in {result.Item2} folder). \nIf it has access, it will be also shared by email."
                    });
                }
                catch (Exception ex)
                {
                    _commonInteractions.ExceptionInteraction.Handle(ex).Subscribe();
                }
            }, scanNotInProgress, Scheduler);
        }


        public ReactiveCommand<Tuple<int, int>, ValidatedPackingList> SingleScan { get; private set; }
        public ReactiveCommand<Unit, Unit> Scan { get; private set; }
        public ReactiveCommand<Tuple<bool, int, int, bool>, Unit> ScanExtra { get; private set; }
        public ReactiveCommand<Unit, Unit> CheckIn { get; private set; }
        public ReactiveCommand<Unit, Unit> CheckOut { get; private set; }
        public ReactiveCommand<Unit, Unit> StartOperation { get; private set; }
        public ReactiveCommand<Unit, Unit> FinishOperation { get; private set; }
        public ReactiveCommand<Unit, Unit> NewOperation { get; private set; }
        public ReactiveCommand<Unit, Unit> InspectOperationInstruments { get; private set; }
        public ReactiveCommand<Unit, Unit> SendInstrumentToService { get; private set; }
        public ReactiveCommand<Unit, Unit> GenerateReport { get; private set; }
        public ReactiveCommand<Unit, Unit> SendEmailReport { get; private set; }
        public ReactiveCommand<Unit, Unit> GenerateHtmlReport { get; private set; }

        public void SaveValidatedPackingListUpdates()
        {
            _packingListValidationService.Save(ValidatedPackingList);
        }

        public TouchscreenPackingListViewModel PackingListViewModel { get; set; }

        private int _totalTagsScanned = 0;
        public int TotalTagsScanned
        {
            get => _totalTagsScanned;
            set => this.RaiseAndSetIfChanged(ref _totalTagsScanned, value);
        }

        public int ExpectedInstrumentCount => _expectedInstrumentCount.Value;
        private readonly ObservableAsPropertyHelper<int> _expectedInstrumentCount;

        public int TotalInstrumentsCounted => _totalInstrumentsCounted.Value;
        private readonly ObservableAsPropertyHelper<int> _totalInstrumentsCounted;

        private int _updateCounter;
        public int UpdateCounter
        {
            get => _updateCounter;
            set => this.RaiseAndSetIfChanged(ref _updateCounter, value);
        }

        private int _scanProgress = 100;

        public int ScanProgress
        {
            get => _scanProgress;
            set => this.RaiseAndSetIfChanged(ref _scanProgress, value);
        }


        private readonly ObservableAsPropertyHelper<int> _checkedInInstruments;
        public int CheckedInInstruments => _checkedInInstruments.Value;

        private readonly ObservableAsPropertyHelper<int> _checkedOutInstruments;
        public int CheckedOutInstruments => _checkedOutInstruments.Value;

        private CheckboxFeatures _features;

        public CheckboxFeatures Features
        {
            get => _features;
            set => this.RaiseAndSetIfChanged(ref _features, value);
        }

        private OperationViewModel _selectedOperation;

        public OperationViewModel SelectedOperation
        {
            get => _selectedOperation;
            set => this.RaiseAndSetIfChanged(ref _selectedOperation, value);
        }

        private bool _showFinishedOperations;
        public bool ShowFinishedOperations
        {
            get => _showFinishedOperations;
            set => this.RaiseAndSetIfChanged(ref _showFinishedOperations, value);
        }

        private readonly ObservableAsPropertyHelper<List<OperationViewModel>> _operations;
        public List<OperationViewModel> Operations => _operations.Value;

        private DateTime _to = DateTime.Now;

        public DateTime To
        {
            get => _to;
            set => this.RaiseAndSetIfChanged(ref _to, value);
        }

        private DateTime _from = DateTime.Now.AddDays(-1);

        public DateTime From
        {
            get => _from;
            set => this.RaiseAndSetIfChanged(ref _from, value);
        }

        readonly ObservableAsPropertyHelper<string> _trayStatus;
        public string TrayStatus => _trayStatus.Value;

        private ValidatedPackingList? _validatedValidatedPackingList;
        public ValidatedPackingList? ValidatedPackingList
        {
            get => _validatedValidatedPackingList;
            set => this.RaiseAndSetIfChanged(ref _validatedValidatedPackingList, value);
        }

        private List<Instrument_RFID> _instrumentLifecycleRfids;
        public List<Instrument_RFID> InstrumentLifecycleRfids
        {
            get => _instrumentLifecycleRfids;
            set => this.RaiseAndSetIfChanged(ref _instrumentLifecycleRfids, value);
        }

        private Instrument_RFID _selectedInstrumentLifecycleRfid;
        public Instrument_RFID SelectedInstrumentLifecycleRfid
        {
            get => _selectedInstrumentLifecycleRfid;
            set => this.RaiseAndSetIfChanged(ref _selectedInstrumentLifecycleRfid, value);
        }

        private List<ScanEvent> _instrumentScanEvents;
        public List<ScanEvent> InstrumentScanEvents
        {
            get => _instrumentScanEvents;
            set => this.RaiseAndSetIfChanged(ref _instrumentScanEvents, value);
        }
        public PackingListState PackingListState => _packingListState.Value;
        private readonly ObservableAsPropertyHelper<PackingListState> _packingListState;

    }
}
