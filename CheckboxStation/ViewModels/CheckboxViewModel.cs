using Caretag.Contracts.Api.v1;
using Caretag.Contracts.Core;
using Caretag.Contracts.Models.v1.Settings;
using Caretag_Class.Configuration;
using Caretag_Class.Logging;
using Caretag_Class.Model;
using Caretag_Class.Model.Service;
using Caretag_Class.ReactiveUI;
using Caretag_Class.ReactiveUI.ViewModels;
using CheckboxStation.Configuration;
using CheckboxStation.Infrastructure;
using CheckboxStation.Reporting;
using CheckboxStation.Services;
using CheckboxStation.Services.Bridge;
using CheckboxStation.Verification;
using CheckboxStation.Views;
using DevExpress.DataAccess.Native.Web;
using DynamicData.Binding;
using global::System.Resources;
using Main.Exceptions;
using Main.Model.Assets;
using Main.Model.PackingList.Validation;
using Main.ReactiveUI.Interactions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NodaTime;
using Org.BouncyCastle.Bcpg.Sig;
using ReactiveUI;
using RFIDAbstractionLayer.ReactiveExtension;
using RFIDAbstractionLayer.Readers;
using RFIDAbstractionLayer.TagEncoding;
using Surgical_Admin.Interactions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Main.Model.PackingList.Validation.ValidatedPackingList;

namespace CheckboxStation.ViewModels
{

    public enum CheckState
    {
        CanCheckIn,
        CanCheckOut,
        Mix,
        NoInstruments
    }

    public partial class CheckboxViewModel : ReactiveObject
    {
        private readonly CheckInViewModelFactory _checkInViewModelFactory;
        private readonly PackingListValidationService _packingListValidationService;
        private readonly CommonInteractions _commonInteractions;
        private readonly CheckStateService _checkStateService;
        private readonly ICheckInService _checkInOutService;
        private readonly ISettingsApi _settingsApi;
        private readonly ISet<string> _uniqueScannedTags = new HashSet<string>();
        private ResourceManager Local_RM = new ResourceManager("CheckBoxStation.WinFormStrings", typeof(CheckboxViewModel).Assembly);
        private List<string> _checkedIdTags;
        private bool _forceCheckinFinish = false;
        private readonly VerboseLogger _verboseLogger;
        private List<UnpackedItem> _unpackedItems = new List<UnpackedItem>();
        private string _currentTrayEpc = string.Empty;
        private Tray_Description _currentTray;
        private readonly ReportingService _reportingService;
        private bool _updateReportSessionNumber = true;
        private List<VerificationReportItem> _verificationReportItems;
        private List<string> _verificationSessionTags;
        private static object _lockTagCollection = new object();

        private readonly IScanService _bridge;
        public Duration ScanDelay { get; set; } = Duration.FromSeconds(6);

        public IScheduler Scheduler { get; set; }

        private bool _forceValidateAllOnNextScan = false;
        private bool _scanPressedForForcedValidation = false;
        private bool _scanFinished = false;

        public CheckboxViewModel(CheckboxService checkboxService,
            InstrumentService instrumentService,
            ScanEventService scanEventService,
            CheckboxStationAppSettings appSettings,
            RFIDReaderCollection rfidReaderCollection,
            CheckInViewModelFactory checkInViewModelFactory,
            CheckboxInteractions checkboxInteractions,
            CommonInteractionsFactory commonInteractionsFactory,
            PackingListValidationService packingListValidationService,
            CheckStateService checkStateService, ILogger<CheckboxViewModel> logger,
            VerboseLogger verboseLogger,
            ReportingService reportingService,
            IScanService bridge,
            AppSettingsBase appSettingsBase,
            ICheckInService checkInOutService,
            ISettingsApi settingsApi,
            IScheduler? scheduler = null)
        {

            PackingListViewModel = new TouchscreenPackingListViewModel
            {
                PackingListMode = TouchscreenPackingListViewModel.Mode.Checkbox
            };

            var obs = Observable.FromEventPattern<ManuallyAddedAsset>(PackingListViewModel, "OnManuallyAddedAsset").Subscribe(async e =>
            {
                var existingAsset = ManuallyAddedAssets.Where(a => a.AssetTypeId == e.EventArgs.AssetTypeId).FirstOrDefault();

                if (existingAsset != null)
                {
                    foreach (var assetId in e.EventArgs.AssetIds)
                    {
                        if (!existingAsset.AssetIds.Any(a => a == assetId))
                        {
                            existingAsset.AssetIds.Add(assetId);
                        }
                    }
                }
                else
                {
                    ManuallyAddedAssets.Add(e.EventArgs);
                }
                if (Features.CheckInEnabled && !Features.CheckOutEnabled)
                {
                    try
                    {
                        await DoCheckIn();
                        _selectedOperation.State = OperationState.ACTIVE.ToString();
                        Operations.Where(o => o.OperationId == _selectedOperation.OperationId).First().State = OperationState.ACTIVE.ToString();
                        CheckInInProgress = true;
                    }
                    catch (CaretagApiException ex)
                    {
                        if (!CheckInInProgress)
                        {
                            CurrentScanningSession = null;
                        }

                        _commonInteractions.ApiExceptionInteraction.Handle(new KeyValuePair<string, Exception>(Local_RM.GetString("CheckInFailed"), ex)).Subscribe();
                    }
                }
                else if (!Features.CheckInEnabled && Features.CheckOutEnabled)
                {
                    try
                    {
                        var checkoutResponse = await _checkInOutService.CheckOut(_uniqueScannedTags.ToArray(), ManuallyAddedAssets);
                        CurrentOperationId = checkoutResponse?.Sessions?.Select(s => s.SessionInfo?.SurgeryId).FirstOrDefault();
                    }
                    catch (CaretagApiException ex)
                    {
                        _commonInteractions.ApiExceptionInteraction.Handle(new KeyValuePair<string, Exception>(Local_RM.GetString("CheckOutFailed"), ex)).Subscribe();

                    }
                }
            });

            //this.BindCommand(this, vm => vm.Scan, f => PackingListViewModel.OnManuallyAddedAsset);

            _commonInteractions = commonInteractionsFactory.Create(RxApp.MainThreadScheduler);
            _checkInViewModelFactory = checkInViewModelFactory;
            _packingListValidationService = packingListValidationService;
            _checkStateService = checkStateService;
            _checkInOutService = checkInOutService;
            var interactions1 = checkboxInteractions;
            interactions1.Setup();
            Scheduler = scheduler ?? RxApp.MainThreadScheduler; //UI thread is standard
            _verboseLogger = verboseLogger;
            _reportingService = reportingService;
            _settingsApi = settingsApi;

            try
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(appSettingsBase.UILanguage);


                PackingListViewModel.DescriptionIdColumnHeaderText = Local_RM.GetString("DescriptionIdCoulmnHeaderText");
                PackingListViewModel.DescriptionColumnHeaderText = Local_RM.GetString("DescriptionCoulmnHeaderText");
                PackingListViewModel.BrandColumnHeaderText = Local_RM.GetString("BrandColumnHeaderText");
                PackingListViewModel.QuantityColumnHeaderText = Local_RM.GetString("QuantityColumnHeaderText");
            }
            catch { }

            _bridge = bridge;

            var checkboxService1 = checkboxService;
            var instrumentService1 = instrumentService;
            var scanEventService1 = scanEventService;
            AppSettingsBase = appSettingsBase;

            _checkedIdTags = new List<string>();

            Features = appSettings.Features;

            OnLoad = ReactiveCommand.CreateFromTask(async (EventArgs e) =>
            {
                // LOAD SETTINGS

                if (AppSettingsBase.UseApi)
                {
                    AppInstanceResponse appInstance = null;
                    Task.Run(async () =>
                    {
                        await _settingsApi.GetAppInstanceSettings().MatchAsync(
                           appInstanceResponse =>
                           {
                               appInstance = appInstanceResponse;
                               return Task.CompletedTask;
                           }, erorResponse => { return Task.CompletedTask; });
                    }).Wait();

                    if (appInstance != null)
                    {
                        Features = Features.LoadFromAppInstance(appInstance);
                        Title = String.Format(appInstance.Name + "{0}", Features.VerificationEnabled ? String.Format(" ({0})", Local_RM.GetString("Verification")) : "");
                    }

                    if (Features.VerificationEnabled || Features.CheckOutEnabled || !AppSettingsBase.UseApi)
                    {
                        _hasActiveOperations.OnNext(true);
                    }

                }

                // LOAD SETTINGS END

                //Log application info
                _verboseLogger.LogDatabaseSettings(appSettings.ConnectionStrings.SQLServer);
                _verboseLogger.LogApplicationVersion(Application.ProductVersion);

                if (Features.VerificationEnabled)
                {
                    _verificationReportItems = new List<VerificationReportItem>();
                    _verificationSessionTags = new List<string>();
                }
            });

            var scanNotInProgress = this.WhenAnyValue(vm => vm.ScanProgress, progress => progress == 100);
            var hasOperations = this.WhenAnyValue(vm => vm.Operations, operations =>
            {

                return Features.VerificationEnabled ||
                       Features.CheckOutEnabled ||
                       !AppSettingsBase.UseApi ||
                       operations?.Count > 0;
            });

            var checkoutEnabled = this.WhenAnyValue(vm => vm.Features.CheckOutEnabled);
            var verificationEnabled = this.WhenAnyValue(vm => vm.Features.VerificationEnabled);

            var passedOperationsCheckUp = Observable.CombineLatest(hasOperations, checkoutEnabled, verificationEnabled)
                                                    .Select(conditions => conditions.Any(c => c) || !AppSettingsBase.UseApi);

            var canScan = Observable.CombineLatest(scanNotInProgress, _hasActiveOperations, passedOperationsCheckUp)
                                    .Select(conditions => conditions.All(c => c));

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
                                    QuantityPackedManually = 0,
                                    Status = checkState == ViewHelpers.CheckState.CheckedIn ? "C.In" : "C.Out",
                                    CanPackManually = row.PackedManually || Features.VerificationEnabled,
                                    DescriptionId = row.DescriptionId,
                                    NotPacked = unpackedItem != null,
                                    InstrumentVendor = row.InstrumentDescription?.Instrument_Company,
                                    AssetIds = row.AssetIds,
                                    AssetTypeId = row.AssetTypeId
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
                                                CanPackManually = item.InstrumentDescription.RfidUntaggable || Features.VerificationEnabled,
                                                DescriptionId = item.Instrument_Descrip_ID,
                                                NotPacked = true,
                                                InstrumentVendor = item.InstrumentDescription?.Instrument_Company ?? "N/A"
                                            });
                                        }
                                    }
                                }
                            }

                            if (appSettings.AllowScanAllOnClick && _forceValidateAllOnNextScan)
                            {
                                foreach (var row in rows)
                                {
                                    var missingItems = row.Quantity - row.TotalPacked;

                                    row.QuantityPackedManually = missingItems;
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
                    _checkedIdTags.Clear();
                    _uniqueScannedTags.Clear();
                    TotalTagsScanned = 0;
                }
                // Start reading
                var unSubscribe = rfidReaderCollection.SubscribeAsObservable(Scheduler).Subscribe(results =>
                    {
                        lock (_lockTagCollection)
                        {
                            foreach (var readingResult in results)
                            {
                                _uniqueScannedTags.Add(readingResult);
                                TotalTagsScanned = _uniqueScannedTags.Count;

                                if (Features.VerificationEnabled && _verificationSessionTags != null && !_verificationSessionTags.Contains(readingResult))
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
                        logger.LogTrace("DelayAndReport: Scanned " + tags.Count + "elements");

                        //InstrumentLifecycleRfids = instrumentService1.GetByTagsWithOperationAndDescriptionAndPopulateServiceRequests(tags);
                        SelectedInstrumentLifecycleRfid = null;

                        //Task.Run(async () =>
                        //{
                        //    InstrumentLifecycleRfids = await _bridge.GetInstruments(tags);
                        //}).Wait();


                        // var result = packingListValidationService.ValidatePackingList(tags, null);
                        ValidatedPackingList result = null;

                        logger.LogTrace("DelayAndReport: Start task ValidatePackingList");
                        Task.Run(async () =>
                        {
                            result = await _bridge.ValidatePackingList(tags, null);
                        }).Wait();
                        logger.LogTrace("DelayAndReport: Finished task ValidatePackingList");

                        InstrumentLifecycleRfids = result.InstrumentLifecycleRfids;

                        //Log only if it is the last scan to prevent duplicates
                        if (scanNumber == totalScan)
                        {
                            _scanFinished = true;
                            logger.LogTrace("DelayAndReport: Start LogScanResult");
                            _verboseLogger.LogScanResult(InstrumentLifecycleRfids, result, tags);
                            logger.LogTrace("DelayAndReport: Finished LogScanResult");
                        }

                        return result;
                    })
                    .Finally(async () =>
                    {
                        if (scanNumber == totalScan)
                        {
                            if (!Features.VerificationEnabled && appSettingsBase.UseApi && _uniqueScannedTags.Count > 0)
                            {
                                if (Features.CheckInEnabled && !Features.CheckOutEnabled)
                                {
                                    if (_selectedOperation == null)
                                    {
                                        ShowOperationsForm = true;
                                        interactions1.ChooseOperation.Handle(this).Select(_ =>
                                        {

                                            return new Unit();
                                        }).Take(1).Subscribe(_ =>
                                        {
                                        });
                                    }
                                    else
                                    {
                                        try
                                        {
                                            _selectedOperation.SessionId = CurrentScanningSession;
                                            var currentOperation = Operations.Where(o => o.OperationId == _selectedOperation.OperationId).First();
                                            currentOperation.SessionId = CurrentScanningSession;

                                            logger.LogTrace("Check in start");
                                            Task.Run(async () =>
                                            {
                                                await DoCheckIn();
                                            }).Wait();
                                            logger.LogTrace("Check in end");
                                            _selectedOperation.State = OperationState.ACTIVE.ToString();
                                            currentOperation.State = OperationState.ACTIVE.ToString();
                                            CheckInInProgress = true;
                                        }
                                        catch (CaretagApiException ex)
                                        {
                                            if (!CheckInInProgress)
                                            {
                                                CurrentScanningSession = null;
                                            }
                                            
                                            _commonInteractions.ApiExceptionInteraction.Handle(new KeyValuePair<string, Exception>(Local_RM.GetString("CheckInFailed"), ex)).Subscribe();
                                        }
                                    }
                                }
                                else if (!Features.CheckInEnabled && Features.CheckOutEnabled)
                                {
                                    try
                                    {
                                        logger.LogTrace("Check out start");
                                        Task.Run(async () =>
                                        {
                                            var checkoutResponse = await _checkInOutService.CheckOut(_uniqueScannedTags.ToArray(), ManuallyAddedAssets);
                                            CurrentOperationId = checkoutResponse?.Sessions?.Select(s => s.SessionInfo?.SurgeryId).FirstOrDefault();
                                        }).Wait();
                                        logger.LogTrace("Check out end");
                                    }
                                    catch (CaretagApiException ex)
                                    {
                                        _commonInteractions.ApiExceptionInteraction.Handle(new KeyValuePair<string, Exception>(Local_RM.GetString("CheckOutFailed"), ex)).Subscribe();

                                    }
                                }
                            }
                            else
                            {
                                _uniqueScannedTags.Clear();
                            }
                        }
                        // Stop reading
                        try
                        {
                            logger.LogTrace("DelayAndReport: Start unSubscribe.Dispose()");
                            unSubscribe.Dispose();
                            logger.LogTrace("DelayAndReport: Finished unSubscribe.Dispose()");
                        }
                        catch (Exception ex)
                        {
                            logger.LogError(ex, "Error while closing scan subscription");
                        }
                    });
            }, null, Scheduler);

            Scan = ReactiveCommand.CreateFromTask(async () =>
            {
                if (_scanPressedForForcedValidation)
                {
                    _forceValidateAllOnNextScan = false;
                }

                _scanPressedForForcedValidation = true;
                var proceedWithNewScan = true;

                if (CheckInInProgress)
                {
                    await UpdateUnfinishedOperations.Execute();

                    await interactions1.ConfirmCheckIn.Handle(this);

                    // If "Add to current surgery" clicked, or the current surgery is selected from the grid view
                    // use the same operation/session
                    if (ConfirmCheckInResult == DialogResult.No || SelectedOperationIdOnConfirmCheckIn == SelectedOperation?.OperationId)
                    {
                        proceedWithNewScan = false;
                        SelectedOperationIdOnConfirmCheckIn = null;
                        await ScanExtra.Execute(new Tuple<bool, int, int, bool>(true, 1, 1, true));
                    }
                    else if (ConfirmCheckInResult == DialogResult.Cancel)
                    {
                        proceedWithNewScan = false;
                    }
                    // If  "Add to selected surgery" clicked
                    // Proceed with the selected operation and use the session id from it (if it was already active)
                    else
                    {
                        if (SelectedOperationIdOnConfirmCheckIn != null)
                        {
                            Operations.Where(o => o.OperationId == _selectedOperation.OperationId).First().State = OperationState.ACTIVE.ToString();
                            _selectedOperation = Operations.Where(o => o.OperationId == SelectedOperationIdOnConfirmCheckIn).First();
                            proceedWithNewScan = true;
                        }
                        else
                        {
                            proceedWithNewScan = false;
                        }
                    }
                    ConfirmCheckInResult = null;
                }
                if (proceedWithNewScan)
                {
                    if (SelectedOperationIdOnConfirmCheckIn != null && _selectedOperation != null)
                    {
                        ResetSession(_selectedOperation);
                        if (_selectedOperation.State == OperationState.NEW.ToString())
                        {
                            // If the operation is new (not activated) generate new session and set the operation sessionId to it
                            CurrentScanningSession = Guid.NewGuid();
                            _selectedOperation.SessionId = CurrentScanningSession;
                            Operations.Where(o => o.OperationId == _selectedOperation.OperationId).First().SessionId = CurrentScanningSession;
                        }
                        else
                        {
                            // If the operation is actibe (already used), use the sessionId of the operation as current session,
                            // so the API can match the operations/sessions
                            CurrentScanningSession = _selectedOperation.SessionId;
                        }
                    }
                    else
                    {
                        ResetSession();
                        CurrentScanningSession = Guid.NewGuid();
                    }

                    SelectedOperationIdOnConfirmCheckIn = null;

                    _verboseLogger.Log($"Clicked on \"Scan\" with session {CurrentScanningSession}");

                    var totalScans = 2;
                    var param = new Tuple<int, int>(1 // scan number
                        , totalScans //total
                        );

                    await SingleScan.Execute(param).Select(result =>
                    {
                        //var validationResult = packingListValidationService.ValidatePackingList(result.Tags, null);

                        ValidatedPackingList validationResult = null;

                        logger.LogTrace("Scan: Start ValidatePackingList");
                        Task.Run(async () =>
                        {
                            validationResult = await _bridge.ValidatePackingList(result.Tags, null);
                        }).Wait();
                        logger.LogTrace("Scan: Finished ValidatePackingList");

                        if (validationResult.TrayEPC != null && _currentTrayEpc != validationResult.TrayEPC)
                        {
                            _currentTrayEpc = validationResult.TrayEPC;
                            _currentTray = validationResult.Tray;
                        }

                        if (Features.VerificationEnabled && _currentTray != null)
                        {
                            logger.LogTrace("Scan: Started GetUnpackedItems");
                            Task.Run(async () =>
                            {
                                _unpackedItems = await _bridge.GetUnpackedItems(_currentTray, _currentTrayEpc);
                            }).Wait(); 
                            logger.LogTrace("Scan: Finished GetUnpackedItems");
                        }

                        ValidatedPackingList = validationResult;

                        return Unit.Default;

                    }).SelectMany(_ => ScanExtra.Execute(new Tuple<bool, int, int, bool>(true, 2, totalScans, false))).Delay(TimeSpan.FromSeconds(1), Scheduler)
                            .Finally(() =>
                                ScanProgress = 100);
                }
            }, canScan, Scheduler);

            ScanExtra = ReactiveCommand.CreateFromObservable<Tuple<bool, int, int, bool>, Unit>(param =>
            {
                //If it is an actual button click
                if (param.Item4)
                {
                    if (_scanPressedForForcedValidation)
                    {
                        _forceValidateAllOnNextScan = false;
                    }

                    _scanPressedForForcedValidation = true;

                    _verboseLogger.Log($"Clicked on \"Scan extra\" with session {CurrentScanningSession}");

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

                    ValidatedPackingList tempValidationresult = new ValidatedPackingList();

                    if (ValidatedPackingList != null && ValidatedPackingList.TrayEPC == result.TrayEPC)
                    {
                        //tempValidationresult = packingListValidationService.ValidatePackingList(ValidatedPackingList.Tags.Concat(result.Tags).Distinct().ToList(), ValidatedPackingList);
                        logger.LogTrace("ScanExtra: Start ValidatePackingList(1)");
                        Task.Run(async () =>
                        {
                            tempValidationresult = await _bridge.ValidatePackingList(ValidatedPackingList.Tags.Concat(result.Tags).Distinct().ToList(), ValidatedPackingList);
                        }).Wait();
                        logger.LogTrace("ScanExtra: Finished ValidatePackingList(1)");
                    }

                    else
                    {
                        //tempValidationresult = packingListValidationService.ValidatePackingList(result.Tags, null);
                        logger.LogTrace("ScanExtra: Start ValidatePackingList(2)");
                        Task.Run(async () =>
                        {
                            tempValidationresult = await _bridge.ValidatePackingList(result.Tags, null);
                        }).Wait();
                        logger.LogTrace("ScanExtra: Finished ValidatePackingList(2)");
                    }


                    if (tempValidationresult.TrayEPC != null && _currentTrayEpc != tempValidationresult.TrayEPC)
                    {
                        _currentTrayEpc = tempValidationresult.TrayEPC;
                        _currentTray = tempValidationresult.Tray;
                    }

                    if (Features.VerificationEnabled && _currentTray != null)
                    {
                        logger.LogTrace("ScanExtra: Start GetUnpackedItems");
                        Task.Run(async () =>
                        {
                            _unpackedItems = await _bridge.GetUnpackedItems(_currentTray, _currentTrayEpc);
                        }).Wait();
                        logger.LogTrace("ScanExtra: Finished GetUnpackedItems");
                    }

                    ValidatedPackingList = new ValidatedPackingList(); // force update
                    ValidatedPackingList = tempValidationresult;


                    if (scanNumber == totalScan)
                    {
                        logger.LogTrace("ScanExtra: Start SaveValidatedPackingListUpdates");
                        SaveValidatedPackingListUpdates();
                        logger.LogTrace("ScanExtra: Finished SaveValidatedPackingListUpdates");
                        logger.LogTrace("ScanExtra: Start SaveScanLog");
                        _bridge.SaveScanLog(result.Tags);
                        logger.LogTrace("ScanExtra: Finished SaveScanLog");
                    }
                    return Unit.Default;
                }).Finally(async () =>
                {
                    if (scanNumber == totalScan) //Direct call
                    {
                        ScanProgress = 100;

                        if (Features.VerificationEnabled)
                        {
                            logger.LogTrace("ScanExtra: Start GenerateReport");
                            await GenerateReport.Execute();
                            await GenerateHtmlReport.Execute();
                            logger.LogTrace("ScanExtra: Finished GenerateReport");
                        }
                    }
                });
            }, canScan, Scheduler);

            SingleScan.ThrownExceptions.Merge(Scan.ThrownExceptions)
                .Throttle(TimeSpan.FromMilliseconds(250), RxApp.MainThreadScheduler)
                .Subscribe(error =>
                {
                    logger.LogError(error, "Exception in viewModel while scanning. ");
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
                    //ValidatedPackingList = packingListValidationService.ValidatePackingList(_uniqueScannedTags.ToList(), null);

                    Task.Run(async () =>
                    {
                        ValidatedPackingList = await _bridge.ValidatePackingList(_uniqueScannedTags.ToList(), null);
                    }).Wait();
                    return new Unit();
                });
            }, checkState.Select(c => c == CheckState.CanCheckIn && !appSettingsBase.UseApi), Scheduler);

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
                                //ValidatedPackingList = packingListValidationService.ValidatePackingList(_uniqueScannedTags.ToList(), null);

                                Task.Run(async () =>
                                {
                                    ValidatedPackingList = await _bridge.ValidatePackingList(_uniqueScannedTags.ToList(), null);
                                }).Wait();
                                return new Unit();
                            })
                );

            }, checkState.Select(c => c == CheckState.CanCheckOut && !appSettingsBase.UseApi), Scheduler);

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
                        _hasActiveOperations.OnNext(true);
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
                        {
                            Task.Run(async () =>
                            {
                                await GenerateReport.Execute();
                                await GenerateHtmlReport.Execute();
                            });
                        }
                    }
                    return ValidatedPackingList.Result;
                })
                .ToProperty(this, vm => vm.PackingListState);

            this.WhenAnyValue(cvm => cvm.Features.OperationsEnabled).Subscribe(operationsEnabled =>
            {
                if (operationsEnabled)
                {
                    _operations = this.WhenAnyValue(vm => vm.From, vm => vm.To,
                            vm => vm.UpdateCounter, vm => vm.ShowFinishedOperations,
                            (from, to, added, showFinishedOperations) =>
                                checkboxService.GetOperations(@from, to.AddDays(1), showFinishedOperations)
                                    .Select(op => new OperationViewModel(op)).ToList())
                        .ToProperty(this, x => x.Operations);
                }
                else
                {
                    _operations = null;
                }
            });

            this.WhenAnyValue(cvm => cvm.Features.CheckInEnabled).Subscribe(checkInEnabled =>
            {
                if (checkInEnabled)
                {
                    _checkedInInstruments = this.WhenAnyValue(vm => vm.SelectedOperation,
                    op => op?.Operation.OperationInstruments?.Count(i => i.ActiveLink) ?? 0)
                    .ToProperty(this, x => x.CheckedInInstruments);
                }
                else
                {
                    _checkedInInstruments = null;
                }
            });

            this.WhenAnyValue(cvm => cvm.Features.CheckOutEnabled).Subscribe(checkOutEnabled =>
            {
                if (checkOutEnabled)
                {
                    _checkedOutInstruments = this.WhenAnyValue(vm => vm.SelectedOperation,
                            op => op?.Operation.OperationInstruments?.Count(i => !i.ActiveLink) ?? 0)
                        .ToProperty(this, x => x.CheckedOutInstruments);
                }
                else
                {
                    _checkedOutInstruments = null;
                }
            });


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
                        Title = Local_RM.GetString("ReportConfirmationDialogTitle"),
                        Message = String.Format(Local_RM.GetString("ReportConfirmationDialogMessage"), result.Item1, result.Item2)
                    });
                }
                catch (Exception ex)
                {
                    _commonInteractions.ExceptionInteraction.Handle(ex).Subscribe();
                }
            }, scanNotInProgress, Scheduler);

            OnOperationSelected = ReactiveCommand.CreateFromTask(async () =>
            {
                if (!Features.VerificationEnabled)
                {
                    CurrentOperationId = SelectedOperation?.OperationId;
                    ShowOperationsForm = false;

                    try
                    {
                        await DoCheckIn();
                        CheckInInProgress = true;

                        if (_selectedOperation != null)
                        {
                            _selectedOperation.State = OperationState.ACTIVE.ToString();
                            _selectedOperation.SessionId = CurrentScanningSession;

                            var currentOperation = Operations.Where(o => o.OperationId == _selectedOperation.OperationId).First();
                            currentOperation.State = OperationState.ACTIVE.ToString();
                            currentOperation.SessionId = CurrentScanningSession;
                        }
                    }
                    catch (CaretagApiException ex)
                    {

                        if (!CheckInInProgress)
                        {
                            CurrentScanningSession = null;
                        }
                        _commonInteractions.ApiExceptionInteraction.Handle(new KeyValuePair<string, Exception>(Local_RM.GetString("CheckInFailed"), ex)).Subscribe();
                    }
                }
            });

            CompleteCheckIn = ReactiveCommand.CreateFromTask(async () =>
            {
                if (CurrentScanningSession != null)
                {
                    var shouldComplete = false;

                    if (!_forceCheckinFinish)
                    {
                        await _commonInteractions.Confirm.Handle(new CaretagMessageBoxArguments
                        {
                            Options = CaretagMessageBoxOptions.YesNo,
                            IsWarning = false,
                            Message = Local_RM.GetString("Are you sure that you want to finish the check-in session?"),
                            Title = Local_RM.GetString("Finish check in")
                        }).Select(
                                result =>
                                {
                                    shouldComplete = result == CaretagMessageBoxResult.Yes;
                                    return new Unit();
                                });
                    }

                    if (shouldComplete || _forceCheckinFinish)
                    {
                        _verboseLogger.Log($"Clicked on \"Finish\" with session {CurrentScanningSession}");
                        try
                        {
                            await _checkInOutService.CompleteCheckIn(CurrentScanningSession.Value);
                            if (_selectedOperation != null)
                            {
                                _selectedOperation.State = OperationState.FINISHED.ToString();
                                Operations.Where(o => o.OperationId == _selectedOperation.OperationId).First().State = OperationState.FINISHED.ToString();


                                _hasActiveOperations.OnNext(Operations.Any(o => o.State != OperationState.FINISHED.ToString()));
                            }
                            ResetSession();
                        }
                        catch (Exception ex)
                        {
                            _commonInteractions.ApiExceptionInteraction.Handle(new KeyValuePair<string, Exception>(Local_RM.GetString("FinishCheckInFailed"), ex)).Subscribe();
                        }
                    }
                    _forceCheckinFinish = false;
                }
            }, scanNotInProgress, Scheduler);

            OnConfirmNewCheckIn = ReactiveCommand.CreateFromTask(() =>
            {
                ConfirmCheckInResult = DialogResult.Yes;
                return Task.CompletedTask;
            });

            OnCancelNewCheckIn = ReactiveCommand.CreateFromTask(() =>
            {
                ConfirmCheckInResult = DialogResult.Cancel;
                return Task.CompletedTask;
            });

            OnAddToCurrentSurgery = ReactiveCommand.CreateFromTask(() =>
            {
                ConfirmCheckInResult = DialogResult.No;
                return Task.CompletedTask;
            });

            EnableForcedValidationOnNextScan = ReactiveCommand.CreateFromTask((EventArgs e) =>
            {
                _scanPressedForForcedValidation = false;
                _forceValidateAllOnNextScan = true;
                return Task.CompletedTask;
            });

            RestartSession = ReactiveCommand.CreateFromTask(() =>
            {
                return Task.CompletedTask;
            });

            UpdateUnfinishedOperations = ReactiveCommand.Create(() =>
            {
                UnfinishedOperations = Operations?.Where(o => o.State != OperationState.FINISHED.ToString())
                                                 .OrderBy(o => o.State)
                                                 .ToList();
            });
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
        public ReactiveCommand<Unit, Unit> OnOperationSelected { get; private set; }
        public ReactiveCommand<Unit, Unit> CompleteCheckIn { get; private set; }
        public ReactiveCommand<Unit, Unit> OnCancelNewCheckIn { get; private set; }
        public ReactiveCommand<Unit, Unit> OnConfirmNewCheckIn { get; private set; }
        public ReactiveCommand<Unit, Unit> OnAddToCurrentSurgery { get; private set; }
        public ReactiveCommand<EventArgs, Unit> OnLoad { get; private set; }
        public ReactiveCommand<EventArgs, Unit> EnableForcedValidationOnNextScan { get; private set; }
        public ReactiveCommand<Unit, Unit> RestartSession { get; private set; }
        public ReactiveCommand<Unit, Unit> UpdateUnfinishedOperations { get; private set; }
        public void SaveValidatedPackingListUpdates()
        {
            _bridge.SaveValidatedPackingList(ValidatedPackingList);
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


        private ObservableAsPropertyHelper<int> _checkedInInstruments;
        public int CheckedInInstruments => _checkedInInstruments != null ? _checkedInInstruments.Value : 0;

        private ObservableAsPropertyHelper<int> _checkedOutInstruments;
        public int CheckedOutInstruments => _checkedOutInstruments != null ? _checkedOutInstruments.Value : 0;

        private CheckboxFeatures _features;

        public CheckboxFeatures Features
        {
            get => _features;
            set => this.RaiseAndSetIfChanged(ref _features, value);
        }

        private AppSettingsBase _appSettingsBase;

        public AppSettingsBase AppSettingsBase
        {
            get => _appSettingsBase;
            set => this.RaiseAndSetIfChanged(ref _appSettingsBase, value);
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

        private ObservableAsPropertyHelper<List<OperationViewModel>> _operations;
        public List<OperationViewModel> Operations => _operations?.Value;

        public List<OperationViewModel> UnfinishedOperations;

        private BehaviorSubject<bool> _hasActiveOperations = new BehaviorSubject<bool>(false);
        public IObservable<bool> HasActiveOperations => _hasActiveOperations.AsObservable();

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

        private bool _checkInInProgress;

        public bool CheckInInProgress
        {
            get => _checkInInProgress;
            set => this.RaiseAndSetIfChanged(ref _checkInInProgress, value);
        }

        private string _title = "aaaa";
        public string Title
        {
            get => _title;
            set => this.RaiseAndSetIfChanged(ref _title, value);
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

        private bool _showOperationsForm = true;
        public bool ShowOperationsForm
        {
            get => _showOperationsForm;
            set => this.RaiseAndSetIfChanged(ref _showOperationsForm, value);
        }

        private Guid? _currentScanningSession;
        public Guid? CurrentScanningSession
        {
            get => _currentScanningSession;
            set => this.RaiseAndSetIfChanged(ref _currentScanningSession, value);
        }

        private string _currentOperationId;
        public string CurrentOperationId
        {
            get => _currentOperationId;
            set => this.RaiseAndSetIfChanged(ref _currentOperationId, value);
        }

        private DialogResult? _confirmCheckInResult;
        public DialogResult? ConfirmCheckInResult
        {
            get => _confirmCheckInResult;
            set => this.RaiseAndSetIfChanged(ref _confirmCheckInResult, value);
        }
        public PackingListState PackingListState => _packingListState.Value;
        private readonly ObservableAsPropertyHelper<PackingListState> _packingListState;

        private List<ManuallyAddedAsset> _manuallyAddedAssets = new List<ManuallyAddedAsset>();
        public List<ManuallyAddedAsset> ManuallyAddedAssets
        {
            get => _manuallyAddedAssets;
            set => this.RaiseAndSetIfChanged(ref _manuallyAddedAssets, value);
        }

        public string SelectedOperationIdOnConfirmCheckIn;
    }
}
