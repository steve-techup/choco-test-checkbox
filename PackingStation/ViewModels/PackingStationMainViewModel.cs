using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Caretag_Class.Model;
using DynamicData;
using DynamicData.Binding;
using RFIDAbstractionLayer.ReactiveExtension;
using RFIDAbstractionLayer.Readers;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using Caretag_Class.Repositories;
using Microsoft.VisualBasic;
using PackingStation.My;
using PackingStation.My.Resources;
using PackingStation.Repositories;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Caretag_Class.Util;
using PackingStation.Configuration;
using PackingStation.Services;
using Caretag_Class.EventReporting;
using PackingStation.Models;
using Zebra.Sdk.Printer.Discovery;
using Zebra.Sdk.Printer;
using Caretag_Class;
using Caretag_Class.Extensions;
using Caretag_Class.ReactiveUI;
using Caretag_Class.ReactiveUI.ViewModels;
using DevExpress.Data.Linq;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.DB.Exceptions;
using RFIDAbstractionLayer.TagEncoding;
using Surgical_Admin.Interactions;
using Exception = System.Exception;
using Caretag_Class.ReactiveUI.Services;
using Caretag_Class.Services;
using com.caen.RFIDLibrary;
using DevExpress.Xpo.Logger;
using Main.Services;
using DevExpress.Map.Kml.Model;
using Main.ReactiveUI.Interactions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.CompilerServices;
using NurApiDotNet;
using Unit = System.Reactive.Unit;
using DevExpress.XtraRichEdit.Model;
using Main.Model.PackingList;
using Caretag_Class.Logging;

namespace PackingStation.ViewModels
{

    public enum MessageType
    {
        Error,
        Info,
        Warning
    }

    public class MessageViewModel
    {
        public MessageViewModel()
        {
            Message = "";
            Type = MessageType.Info;
        }

        public string Message { get; set; }
        public MessageType Type { get; set; }
    }

    public class PackingStationMainViewModel : ReactiveObject
    {
        private readonly RFIDReaderCollection _readerCollection;
        private readonly ExcelExportService _excelExportService;
        public IScheduler Scheduler { get; set; }

        public PackingStationMainViewModel(RFIDReaderCollection readerCollection,
            PackingStationUnitOfWorkFactory unitOfWorkFactory,
            PackingStationAppSettings appSettings,
            PackedTrayReportService packedTrayReportService,
            CommonInteractionsFactory commonInteractionsFactory,
            ReactiveCommandService reactiveCommandService,
            ZebraPrintService zebraPrintService,
            ExcelExportService excelExportService,
            VerboseLogger verboseLogger,
        IScheduler? scheduler = null)
        {
            Guid? _currentScanningSession = null;

            //Log application info
            verboseLogger.LogDatabaseSettings(appSettings.ConnectionStrings.SQLServer);
            verboseLogger.LogApplicationVersion(System.Windows.Forms.Application.ProductVersion);

            _readerCollection = readerCollection;
            _excelExportService = excelExportService;
            Scheduler = scheduler ?? RxApp.MainThreadScheduler; //UI thread is standard
            _commonInteractions = commonInteractionsFactory.Create(Scheduler);

            TouchscreenPackingListViewModel = new TouchscreenPackingListViewModel();
            CurrentInstrumentPackTrayTypes = new List<Tray_Description>();

            _totalScanned = TouchscreenPackingListViewModel.PackingListRowsCollection.ToObservableChangeSet()
                .Select(x =>
                {
                    return TouchscreenPackingListViewModel.PackingListRowsCollection.Select(r => r.TotalPacked)
                        .Sum();
                })
                .ToProperty(this, x => x.TotalScanned, 0);

            IDisposable deleteMessageDisposable = null;

            this.WhenAnyValue(x => x.CurrentMessage)
                .Subscribe(val =>
                {
                    deleteMessageDisposable?.Dispose();
                    if (!string.IsNullOrWhiteSpace(val?.Message))
                    {
                        deleteMessageDisposable = Scheduler.Schedule("", new TimeSpan(0, 0, 0, 0, 2000),
                            (_, _) => { CurrentMessage = null; });
                    }
                });

            PackingStationUnitOfWork unitOfWork = null;
            IDisposable unsubscribe = null;

            Cost_Log? costLog = null;

            AppDomain.CurrentDomain.FirstChanceException += (sender, args) =>
            {
                if (args.Exception is OperationCanceledException || args.Exception is NurApiException || args.Exception is IOException || args.Exception is CAENRFIDException)
                    return;

                if (Debugger.IsAttached)
                    Debugger.Break();

                string userMessage = "An unexpected error happened. ";
                string logMessage = "An unexpected error happened. ";

                if (args.Exception is SchemaCorrectionNeededException)
                {
                    userMessage = "An error occurred while querying the database ";
                    logMessage = "An error occurred while querying the database - schema did not match model. ";
                }

                _commonInteractions.ErrorReportInteraction.Handle(new ErrorReport()
                {
                    AddContactMessage = true,
                    AddRestartMessage = true,
                    Exception = args.Exception,
                    LogMessage = "First chance exception caught in current AppDomain. " + logMessage,
                    UserErrorMessage = userMessage,
                    ErrorCode = "PackingStation-1",
                    ReportLevel = ReportLevel.Error
                }).Subscribe();
            };

            this.WhenAnyValue(x => x.SelectedTrayType, y => y.TouchscreenPackingListViewModel.SelectedPackingListRow)
                .Subscribe(async values =>
                {
                    var selectedTray = values.Item1;
                    var selectedInstrumentDescriptionId = values.Item2?.DescriptionId;

                    if (unitOfWork == null) //Currently not in the business flow
                    {
                        SideImage = Resources.Caretag_Banner;
                        return;
                    }

                    if (selectedInstrumentDescriptionId != null)
                    {
                        if (DateTime.Now - _lastInstrumentImageUpdate < TimeSpan.FromMilliseconds(200)) //Debounce instrument image updates
                            return;

                        await SetInstrumentImage(unitOfWork, selectedInstrumentDescriptionId);
                        return;
                    }

                    if (selectedTray != null)
                        SideImage =
                            await unitOfWork.TrayImageRepository.GetResizedImageByTrayIdAsync(
                                selectedTray.Description_ID, 560, 688) ?? Resources.Caretag_Banner;
                    else
                        SideImage = Resources.Caretag_Banner;
                });

            Restart = ReactiveCommand.CreateFromObservable(() =>
            {
                return Observable.Start(() =>
                {
                    TouchscreenPackingListViewModel.Clear();
                    unsubscribe?.Dispose();
                    if (unitOfWork != null)
                    {
                        unitOfWork.Dispose();
                        unitOfWork = null;
                    }

                    CurrentTray = null;
                    SelectedTrayType = null;
                    SterilizationIndicatorLotNumber = "";
                    CurrentMessage = null;
                    CurrentPage = 0;
                    IsScanning = false;
                    costLog = null;
                    CurrentInstrumentPackTrayTypes = new List<Tray_Description>();
                    CurrentInstrument = null;
                    return Unit.Default;
                }, Scheduler);
            });
            reactiveCommandService.HandleExceptions(Restart, "An error occurred while restarting the application.",
                "Error in Restart command", "PackingStation-16", ReportLevel.Error);

            CancelPacking = ReactiveCommand.CreateFromObservable(() =>
            {
                verboseLogger.Log($"Clicked on \"Cancel\" with session {_currentScanningSession}");
                return _commonInteractions.Confirm.Handle(new CaretagMessageBoxArguments()
                {
                    IsWarning = false,
                    Options = CaretagMessageBoxOptions.YesNo,
                    Message = "Are you sure you want to cancel packing? All changes will be lost. ",
                    Title = "Cancel?"
                }).Select(result =>
                {
                    if (result == CaretagMessageBoxResult.Yes)
                        Restart.Execute().Subscribe();
                    return Unit.Default;
                });
            });


            ScanNewTray = ReactiveCommand.Create(() =>
            {
                _currentScanningSession = Guid.NewGuid();
                verboseLogger.Log($"Clicked on \"Scan Tray\" with session {_currentScanningSession}");
                unitOfWork = unitOfWorkFactory.Create();
                readerCollection.Readers.ForEach(r => r.SetPower(PowerLevel.Low));
                TrayTypes = unitOfWork.TrayDescriptionRepository
                    .Get(t => !(t.Deleted_Tray ?? false) && !(t.Hide_Tray ?? false),
                        trays => trays.OrderBy(t => t.Tray_Name)).ToList();

                IsScanning = true;
                unsubscribe = readerCollection.SubscribeAsObservable(Scheduler).Subscribe(tags =>
                {
                    try
                    {
                        if (tags.Length == 1)
                        {
                            var tag = tags.First();
                            var tray = unitOfWork.TrayRfidRepository.Get(t => t.EPC_Nr == tag).FirstOrDefault();
                            if (tray != null)
                            {
                                CurrentTray = tray;

                                CurrentPage = 2;
                                SetMessage("Tray scanned! ", MessageType.Info, SoundType.Scanned);
                                IsScanning = false;
                                unsubscribe.Dispose();
                            }
                            else
                                SetMessage("Tray not found", MessageType.Error, SoundType.Error);
                        }
                        else
                            SetMessage("More than one tag scanned. Please scan one tray at a time. ",
                                MessageType.Warning,
                                SoundType.Warning);
                    }
                    catch (Exception ex)
                    {
                        _commonInteractions.ErrorReportInteraction
                            .Handle(new ErrorReport()
                            {
                                Exception = ex,
                                AddContactMessage = true,
                                AddRestartMessage = true,
                                UserErrorMessage = "An error occurred while scanning a tray",
                                LogMessage = "Error in subscribe part of ScanNewTray command",
                                ErrorCode = "PackingStation-17",
                                ReportLevel = ReportLevel.Error
                            }).Subscribe();
                    }
                });

            }, this.WhenAnyValue(vm => vm.IsScanning).Select(v => !v));


            reactiveCommandService.HandleExceptions(ScanNewTray, "An error occurred while scanning a new tray",
                "Error in ScanNewTray command", "PackingStation-2", ReportLevel.Error);

            StartPacking = ReactiveCommand.Create(() =>
            {
                verboseLogger.Log($"Clicked on \"Scan Packing\" with session {_currentScanningSession}");
                CurrentPage = 3;

                TouchscreenPackingListViewModel.Clear();
                var packingList = unitOfWork.PackingListRepository.GetPackingList(SelectedTrayType.Description_ID)
                    .Select(row =>
                        new TouchscreenPackingListViewModel.PackingListRowViewModel
                        {
                            InstrumentDescription = row.InstrumentDescription,
                            Quantity = row.Quantity,
                            CanPackManually = row.PackedManually.HasValue,
                            DescriptionId = row.DescriptionId,
                            InstrumentVendor = row.InstrumentVendor,
                            QuantityPackedManually = 0
                        });
                TouchscreenPackingListViewModel.UpsertPackingListRows(packingList);
                IsLocked = SelectedTrayType.Tray_Lock ?? true;

                IsScanning = true;
                unsubscribe = readerCollection.SubscribeAsObservable(Scheduler).Subscribe(tags =>
                {
                    try
                    {
                        if (tags.Length == 1)
                        {
                            var tag = tags.First();
                            var instrument = unitOfWork.InstrumentRfidRepository.Get(i => i.EPC_Nr == tag)
                                .FirstOrDefault();
                            if (instrument != null)
                            {
                                TouchscreenPackingListViewModel.EditPackingListRows(async innerCache =>
                                {
                                    var row = innerCache.Items.FirstOrDefault(x =>
                                        x.DescriptionId == instrument.Description_ID);
                                    if (row != null)
                                    {
                                        /*
                                        Observable.Start(() =>
                                        {
                                            TouchscreenPackingListViewModel.SelectedPackingListRow =
                                                null!; // Hack to compensate for DataGridview's unfortunate behavior in automatically selecting the first row
                                        }).Delay(new TimeSpan(0,0,0,0,250)).Subscribe();
                                        */

                                        if (row.PackedInstruments.Any(p => p.EPC_Nr == instrument.EPC_Nr))
                                        {
                                            SetMessage("Instrument already packed", MessageType.Warning,
                                                SoundType.Warning);
                                        }
                                        else if (row.Quantity == row.PackedInstruments.Count && IsLocked)
                                        {
                                            SetMessage(
                                                "Already packed all the required instruments of the type. Please scan another instrument or unlock tray.",
                                                MessageType.Warning, SoundType.Warning);
                                        }
                                        else
                                        {
                                            PlaySound(SoundType.Scanned);
                                            row.PackedInstruments.Add(instrument);
                                            innerCache.AddOrUpdate(row);
                                            await SetInstrumentImage(unitOfWork, instrument.Description_ID);
                                        }
                                    }
                                    else
                                    {
                                        if (IsLocked)
                                        {
                                            SetMessage(
                                                "Packing list does not contain instruments of this type. Please scan another instrument or unlock tray.",
                                                MessageType.Warning, SoundType.Warning);
                                        }
                                        else
                                        {
                                            PlaySound(SoundType.Scanned);
                                            var instrumentDescription =
                                                unitOfWork.InstrumentDescriptionRepository.GetByID(instrument
                                                    .Description_ID);

                                            innerCache.AddOrUpdate(
                                                new TouchscreenPackingListViewModel.PackingListRowViewModel
                                                {
                                                    InstrumentDescription = instrumentDescription.GetFullDescription(),
                                                    InstrumentVendor = instrumentDescription.Instrument_Company,
                                                    Quantity = 0,
                                                    CanPackManually = false,
                                                    DescriptionId = instrument.Description_ID,
                                                    PackedInstruments = new List<Instrument_RFID> { instrument }
                                                });
                                        }
                                    }

                                });
                            }
                            else
                            {
                                SetMessage("Instrument not found", MessageType.Error, SoundType.Error);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _commonInteractions.ErrorReportInteraction
                            .Handle(new ErrorReport()
                            {
                                Exception = e,
                                AddContactMessage = true,
                                AddRestartMessage = true,
                                UserErrorMessage = "An error occurred while scanning an instrument",
                                LogMessage = "Error in subscribe part of StartPacking command",
                                ErrorCode = "PackingStation-3",
                                ReportLevel = ReportLevel.Error
                            }).Subscribe();
                    }
                });
            });

            reactiveCommandService.HandleExceptions(StartPacking, "An error occurred while packing instruments",
                "Error in StartPacking command", "PackingStation-4", ReportLevel.Error);

            FinishPacking = ReactiveCommand.CreateFromObservable(() =>
            {
                if (TouchscreenPackingListViewModel.PackingListRowsCollection.Any(x => x.TotalPacked < x.Quantity) &&
                    IsLocked)
                {
                    SetMessage("Not all instruments packed. Pack all instruments or unlock tray. ", MessageType.Error,
                        SoundType.Error);
                    return Observable.Return(Unit.Default);
                }
                else if (TouchscreenPackingListViewModel.PackingListRowsCollection.Sum(r => r.TotalPacked) == 0)
                {
                    SetMessage("At least one instrument must be packed to continue. ", MessageType.Error,
                        SoundType.Error);
                    return Observable.Return(Unit.Default);
                }

                verboseLogger.Log($"Clicked on \"Next\" with session {_currentScanningSession}");

                unitOfWork.PackingListRepository.ClearPackingListForTray(CurrentTray.EPC_Nr);
                unitOfWork.PackingListRepository.AddPackingList(SelectedTrayType, CurrentTray,
                    TouchscreenPackingListViewModel.PackingListRowsCollection.SelectMany(x => x.PackedInstruments)
                        .ToList(),
                    TouchscreenPackingListViewModel.PackingListRowsCollection.Where(x => x.QuantityPackedManually > 0)
                        .Select(x => new PackedInstrument
                        {
                            DescriptionId = x.DescriptionId,
                            Quantity = x.QuantityPackedManually
                        }).ToList(), LoggedInUserId, 0, IsLocked);

                //unitOfWork.Save();
                unsubscribe?.Dispose();
                IsScanning = false;
                if (appSettings.Features.Containers)
                {
                    CurrentPage = 4;
                    return Observable.Return(Unit.Default);
                }
                else
                {
                    return GoChooseCostCenter.Execute();
                }
            });
            reactiveCommandService.HandleExceptions(FinishPacking, "An error occurred while finishing packing",
                "Error in FinishPacking command", "PackingStation-5", ReportLevel.Error);

            ScanContainer = ReactiveCommand.Create(() =>
            {
                verboseLogger.Log($"Clicked on \"Scan Container\" with session {_currentScanningSession}");
                IsScanning = true;
                unsubscribe = readerCollection.SubscribeAsObservable(Scheduler).Select(tags =>
                {
                    if (tags.Length == 1)
                    {
                        var tag = tags.First();
                        var container = unitOfWork.ContainerRfidRepository.Get(c => c.EPC_Nr == tag).FirstOrDefault();
                        if (container != null)
                        {
                            CurrentContainer = container;
                            CurrentContainer.Tray_ID = CurrentTray.Tray_ID;
                            unsubscribe?.Dispose();
                            IsScanning = false;
                            SetMessage("Container scanned! ", MessageType.Info, SoundType.Scanned);
                            return GoChooseCostCenter.Execute();
                        }
                        else
                        {
                            SetMessage("Container not found. Maybe you scanned an instrument or a tray?",
                                MessageType.Error, SoundType.Error);
                        }
                    }

                    return Observable.Return(Unit.Default);
                }).Subscribe();
            }, this.WhenAnyValue(vm => vm.IsScanning).Select(v => !v));
            reactiveCommandService.HandleExceptions(ScanContainer, "An error occurred while scanning container",
                "Error in ScanContainer command", "PackingStation-6", ReportLevel.Error);

            GoChooseCostCenter = ReactiveCommand.CreateFromObservable(() =>
            {
                CurrentPage = 5;
                CostCenters =
                    unitOfWork.CostCenterRepository.Get(orderBy: centers => centers.OrderBy(c => c.Cost_Center_Name));

                if (SelectedTrayType.Cost_ID == 0)
                {
                    ChooseCostCenter = true;
                    return Observable.Return(Unit.Default);
                }

                ChooseCostCenter = false;

                SelectedCostCenter = CostCenters.FirstOrDefault(center => center.Index_ID == SelectedTrayType.Cost_ID);
                return Observable.Return(Unit.Default);
            });
            reactiveCommandService.HandleExceptions(GoChooseCostCenter, "An error occurred while choosing cost center",
                "Error in GoChooseCostCenter command", "PackingStation-7", ReportLevel.Error);

            this.WhenAnyValue(vm => vm.SelectedCostCenter).Subscribe(center =>
            {
                if (center != null)
                    CostTypes = center.CostItems.Select(ci => ci.CostType);
            });

            GoAdditionalInformation = ReactiveCommand.CreateFromObservable(() =>
            {
                if (ChooseCostCenter)
                {
                    if (SelectedCostCenter == null)
                    {
                        SetMessage("Please select a cost center", MessageType.Error, SoundType.Error);
                        return Observable.Return(Unit.Default);
                    }

                    if (SelectedCostType == null)
                    {
                        SetMessage("Please select a cost type", MessageType.Error, SoundType.Error);
                        return Observable.Return(Unit.Default);
                    }

                    costLog = new Cost_Log
                    {
                        ChangeDate = DateTime.Now,
                        CostItem = SelectedCostCenter.CostItems.First(ci => ci.CostType == SelectedCostType),
                        Extra_Text = CostCenterNote,
                        TrayDescriptionId = SelectedTrayType.Description_ID,
                    };

                    unitOfWork.CostLogRepository.Insert(costLog);
                }

                CurrentPage = 6;
                return Observable.Return(Unit.Default);
            });
            reactiveCommandService.HandleExceptions(GoAdditionalInformation,
                "An error occurred while going to additional information", "Error in GoAdditionalInformation command",
                "PackingStation-8", ReportLevel.Error);

            SaveAndGoToReportAndFinalize = ReactiveCommand.CreateFromObservable(() =>
            {
                if (SterilizationIndicatorLotNumber.Length < 2)
                {
                    SetMessage("Please enter a valid lot number", MessageType.Error, SoundType.Error);
                    return Observable.Return(Unit.Default);
                }

                return _commonInteractions.Confirm.Handle(new CaretagMessageBoxArguments
                {
                    IsWarning = false,
                    Options = CaretagMessageBoxOptions.YesNo,
                    Message = "Are you sure you want to save this packing? You cannot undo this action.",
                    Title = "Confirm"
                }).ObserveOn(Scheduler).Select(result =>
                {
                    if (result != CaretagMessageBoxResult.Yes) return Unit.Default;

                    verboseLogger.Log($"Clicked on \"Save\" with session {_currentScanningSession}");

                    int sum = 0;
                    foreach (var pr in TouchscreenPackingListViewModel.PackingListRowsCollection)
                        sum += (pr.QuantityPackedManually);

                    var packingListAsPacked = new PackingLog
                    {
                        TrayTypeId = SelectedTrayType.Description_ID,
                        TrayRfidId = CurrentTray.Tray_ID,
                        ContainerRfidId = CurrentContainer?.Container_ID,
                        CostLog = costLog,
                        Timestamp = DateTime.Now,
                        PackedByUserId = LoggedInUserId,
                        PackingLogLines = TouchscreenPackingListViewModel.PackingListRowsCollection.SelectMany(pr =>
                            pr.PackedInstruments.Select(pi =>
                                new PackingLogLine
                                {
                                    InstrumentDescriptionId = pi.Description_ID,
                                    InstrumentRfid = pi,
                                    QuantityPackedManually = 0
                                })).Append(TouchscreenPackingListViewModel.PackingListRowsCollection
                            .Where(pr => pr.QuantityPackedManually > 0).Select(pr =>
                                new PackingLogLine()
                                {
                                    QuantityPackedManually = pr.QuantityPackedManually,
                                    InstrumentDescriptionId = pr.DescriptionId,
                                })).ToList(),
                        SterilizationIndicatorLotNumber = SterilizationIndicatorLotNumber,
                        TotalInstrumentTypes =
                            TouchscreenPackingListViewModel.PackingListRowsCollection.Count(r => r.TotalPacked > 0),
                        TotalInstruments =
                            TouchscreenPackingListViewModel.PackingListRowsCollection.Sum(pr => pr.TotalPacked),
                        TotalPackedManually =
                            sum
                    };

                    unitOfWork.PackingLogRepository.Insert(packingListAsPacked);
                    unitOfWork.Save();
                    var packingListAsPackedWithRefsLoading = unitOfWork.PackingLogRepository
                        .Get(x => x.Id == packingListAsPacked.Id, includeProperties: "PackedByUser").First();

                    CurrentPage = 7;
                    PackingReport = packedTrayReportService.ReportPackedTray(packingListAsPackedWithRefsLoading);
                    verboseLogger.LogPacking(packingListAsPacked, TouchscreenPackingListViewModel.PackingListRowsCollection.ToList(), _currentScanningSession);
                    return Unit.Default;
                });
            });

            reactiveCommandService.HandleExceptions(SaveAndGoToReportAndFinalize,
                "An error occurred while saving and going to report and finalizing packing. ",
                "Error in SaveAndGoToReportAndFinalize command", "PackingStation-9", ReportLevel.Error);

            FinishAndPrintLabel = ReactiveCommand.CreateFromObservable(() =>
            {
                try
                {
                    if (NumberOfLabelsToPrint > 0)
                    {
                        var trayLabel = new TrayLabel
                        {
                            TrayName = SelectedTrayType.Tray_Name,
                            PackedBy = Function_Module.Program_User,
                            DatePacked = DateTime.Now,
                            ExpiresDate = DateTime.Now,
                            AssetId = (int)new RfidEPC(CurrentTray.EPC_Nr).AssetId
                        };

                        var filename = "label.zpl";

                        zebraPrintService.PrintLabel(trayLabel, NumberOfLabelsToPrint, filename);
                    }
                }
                catch (Exception)
                {
                    //TODO: Handle errors on label print
                }

                CurrentPage = 0;
                return Observable.Return(Unit.Default);
            });
            reactiveCommandService.HandleExceptions(FinishAndPrintLabel,
                "An error occurred while finishing and printing label. ", "Error in FinishAndPrintLabel command",
                "PackingStation-10", ReportLevel.Error);

            GoPackTray = ReactiveCommand.CreateFromObservable(() =>
            {
                CurrentPage = 1;
                return Observable.Return(Unit.Default);
            });
            reactiveCommandService.HandleExceptions(GoPackTray, "An error occurred while going to pack tray. ",
                "Error in GoPackTray command", "PackingStation-11", ReportLevel.Error);
            GoInstrumentLookup = ReactiveCommand.CreateFromObservable(() =>
            {
                CurrentPage = 8;
                return Observable.Return(Unit.Default);
            });
            reactiveCommandService.HandleExceptions(GoInstrumentLookup,
                "An error occurred while going to instrument lookup. ", "Error in GoInstrumentLookup command",
                "PackingStation-12", ReportLevel.Error);

            GoViewPackedTrays = ReactiveCommand.CreateFromObservable(() =>
            {
                unitOfWork = unitOfWorkFactory.Create();
                SelectedPackingLogId = (int)(unitOfWork.DbContext.PackingLogs
                    .Include("TrayDescription")
                    .Include("PackedByUser")
                    .OrderByDescending(x => x.Timestamp).FirstOrDefault()?.Id ?? 0);
                PackingLogXPServerCollectionSource = new EntityServerModeSource()
                {
                    ElementType = typeof(PackingLog),
                    KeyExpression = "Id",
                    QueryableSource = unitOfWork.DbContext.PackingLogs
                        .Include("TrayDescription")
                        .Include("PackedByUser")
                        .OrderByDescending(x => x.Timestamp)
                };

                CurrentPage = 9;
                return Observable.Return(Unit.Default);
            });
            reactiveCommandService.HandleExceptions(GoViewPackedTrays,
                "An error occurred while going to view packed trays. ", "Error in GoViewPackedTrays command",
                "PackingStation-13", ReportLevel.Error);

            GoToReportAndPrintLabel = ReactiveCommand.CreateFromObservable(() =>
            {
                //check that SelectedPackingLogId > 0 and display an error if it is 0
                if (SelectedPackingLogId == 0)
                {
                    SetMessage("Please select a packing log", MessageType.Error, SoundType.Error);
                    return Observable.Return(Unit.Default);
                }

                CurrentPage = 10;
                var packingListAsPacked = unitOfWork.PackingLogRepository.Get(pl => pl.Id == SelectedPackingLogId,
                    includeProperties: "PackingLogLines.InstrumentDescription, PackedByUser, TrayDescription").First();
                TrayContentsReport =
                    packingListAsPacked.PackingLogLines.GroupBy(pl => pl.InstrumentDescriptionId).Select(g => new
                        Tuple<string, string>(g.First().InstrumentDescription.GetFullDescription(),
                            g.Sum(pl => pl.QuantityPackedManually > 0 ? pl.QuantityPackedManually : 1)
                                .ToString())).ToList();

                SelectedTrayType = packingListAsPacked.TrayDescription;
                CurrentTray = packingListAsPacked.TrayRfid;
                PackingReport = packedTrayReportService.ReportPackedTray(packingListAsPacked);
                return Observable.Return(Unit.Default);
            });
            reactiveCommandService.HandleExceptions(GoToReportAndPrintLabel,
                "An error occurred while going to report and printing label. ",
                "Error in GoToReportAndPrintLabel command", "PackingStation-14", ReportLevel.Error);

            GenericBack = ReactiveCommand.CreateFromObservable(() =>
            {
                return Observable.Start(() =>
                {
                    CurrentPage--;
                    TouchscreenPackingListViewModel.SelectedPackingListRow = null;
                    unsubscribe?.Dispose();
                    return Unit.Default;
                }, Scheduler);
            });

            BackWithConfirm =
                reactiveCommandService.ConfirmCommand(GenericBack,
                    "Are you sure you want to go back? All changes will be lost.");

            reactiveCommandService.HandleExceptions(GenericBack, "An error occurred while going back. ",
                "Error in GenericBack command", "PackingStation-15", ReportLevel.Error);

            Login = ReactiveCommand.CreateFromObservable(() =>
            {
                return _commonInteractions.LoginInteraction.Handle(Unit.Default).Select(result =>
                {
                    if (result == null) return false;
                    LoggedInUserId = result.UserID;
                    return true;
                });
            });

            reactiveCommandService.HandleExceptions(Login,
                "An error occurred during login. ",
                "Error in Login command", "PackingStation-19", ReportLevel.Error);

            Logout = ReactiveCommand.Create(() =>
            {
                Login.Execute().Subscribe(loginSuccessful =>
                {
                    if (!loginSuccessful)
                    {
                        System.Windows.Forms.Application.Exit();
                    }
                });
                return Unit.Default;
            });
            reactiveCommandService.HandleExceptions(Logout,
                "An error occurred during logout. ",
                "Error in Logout command", "PackingStation-20", ReportLevel.Error);

            // The ScanInstrumentForLookup command is used to scan an instrument with the RFID reader and then uses PackingListRepository.GetTraysForInstrument to get a list of trays
            // that the instrument is packed in. The list is then assigned to ScannedCurrentInstrumentPackTrayTypes.
            ScanInstrumentForLookup = ReactiveCommand.CreateFromObservable(() =>
            {
                unitOfWork = unitOfWorkFactory.Create();
                IsScanning = true;
                unsubscribe = readerCollection.SubscribeAsObservable(Scheduler).Select(tags =>
                {
                    if (tags.Length == 1)
                    {
                        var tag = tags.First();
                        CurrentInstrument = unitOfWork.InstrumentRfidRepository.Get(i => i.EPC_Nr == tag, includeProperties: "InstrumentDescription")
                            .Select(i => i.InstrumentDescription).FirstOrDefault();
                        if (CurrentInstrument != null)
                        {
                            CurrentInstrumentPackTrayTypes =
                                unitOfWork.PackingListRepository.GetTraysForInstrument(CurrentInstrument!);
                            unsubscribe?.Dispose();
                            IsScanning = false;
                            SetMessage("Instrument scanned! ", MessageType.Info, SoundType.Scanned);
                        }
                        else
                        {
                            SetMessage("Instrument not found", MessageType.Error, SoundType.Error);
                        }
                    }

                    return Observable.Return(Unit.Default);
                }).Subscribe();
                return Observable.Return(Unit.Default);
            }, this.WhenAnyValue(vm => vm.IsScanning).Select(v => !v));

            reactiveCommandService.HandleExceptions(ScanInstrumentForLookup,
                "An error occurred during instrument scanning. ",
                "Error in ScanInstrumentForLookup command", "PackingStation-21", ReportLevel.Error);

            ExportPacklistToExcel = ReactiveCommand.CreateFromObservable(() =>
            {
                return _commonInteractions.BrowseSaveFileInteraction.Handle("Excel file (*.xlsx)|*.xlsx").SelectMany(
                    filename =>
                    {
                        if (filename == null)
                            return Observable.Return(CaretagMessageBoxResult.Cancel);

                        _excelExportService.ExportPacklistToExcel(filename, unitOfWork.PackingListRepository.GetPackingListForRendering(SelectedTrayType.Description_ID), SelectedTrayType.Tray_Name,
                            true);
                        return _commonInteractions.Confirm.Handle(new CaretagMessageBoxArguments()
                        {
                            IsWarning = false,
                            Options = CaretagMessageBoxOptions.Ok,
                            Message = "Export successful",
                            Title = "Export successful"
                        });
                    }).Select(result => Unit.Default);
            });

            reactiveCommandService.HandleExceptions(ExportPacklistToExcel,
                "An error occurred while exporting packlist to Excel. ",
                "Error in ExportPacklistToExcel command", "PackingStation-22", ReportLevel.Error);
        }
        public void CleanUp()
        {
            //_readerCollection.UnsubscribeAll();
            //Thread.Sleep(100); // wait for the unsubscribe to finish
            _readerCollection.Dispose();
        }

        private void SetMessage(string message, MessageType messageType, SoundType sound)
        {
            CurrentMessage = new MessageViewModel
            {
                Message = message,
                Type = messageType
            };
            PlaySound(sound);
        }

        private DateTime _lastInstrumentImageUpdate = DateTime.MinValue;

        private async Task SetInstrumentImage(PackingStationUnitOfWork unitOfWork, string instrumentDescriptionId)
        {
            _lastInstrumentImageUpdate = DateTime.Now;
            var image = await unitOfWork.InstrumentImageRepository
                .GetResizedImageByInstrumentDescriptionId(instrumentDescriptionId, 560, 688);
            if (image != null)
            {
                SideImage = image;
            }
        }

        private void PlaySound(SoundType sound)
        {
            switch (sound)
            {
                case SoundType.Scanned:
                    MyProject.Computer.Audio.Play(Resources.beep_ok, AudioPlayMode.Background);
                    break;
                case SoundType.Error:
                    MyProject.Computer.Audio.Play(Resources.Short_Beep, AudioPlayMode.Background);
                    break;
                case SoundType.Info:
                    Interaction.Beep();
                    break;
                case SoundType.Warning:
                    SystemSounds.Hand.Play();
                    break;
            }
        }

        private enum SoundType
        {
            Scanned,
            Info,
            Warning,
            Error,
            Silent
        }

        public ReactiveCommand<Unit, Unit> GoPackTray { get; }
        public ReactiveCommand<Unit, Unit> GoInstrumentLookup { get; }
        public ReactiveCommand<Unit, Unit> GoViewPackedTrays { get; }
        public ReactiveCommand<Unit, Unit> ScanNewTray { get; }
        public ReactiveCommand<Unit, Unit> Restart { get; set; }
        public ReactiveCommand<Unit, Unit> CancelPacking { get; }
        public ReactiveCommand<Unit, Unit> StartPacking { get; set; }
        public ReactiveCommand<Unit, Unit> FinishPacking { get; set; }
        public ReactiveCommand<Unit, Unit> ScanContainer { get; set; }
        public ReactiveCommand<Unit, Unit> GenericBack { get; set; }
        public ReactiveCommand<Unit, Unit> BackWithConfirm { get; set; }
        public ReactiveCommand<Unit, Unit> GoChooseCostCenter { get; set; }
        public ReactiveCommand<Unit, Unit> GoAdditionalInformation { get; set; }
        public ReactiveCommand<Unit, Unit> SaveAndGoToReportAndFinalize { get; set; }
        public ReactiveCommand<Unit, Unit> GoToReportAndPrintLabel { get; set; }
        public ReactiveCommand<Unit, Unit> FinishAndPrintLabel { get; set; }
        public ReactiveCommand<Unit, bool> Login { get; set; }
        public ReactiveCommand<Unit, Unit> Logout { get; set; }
        public ReactiveCommand<Unit, Unit> ExportPacklistToExcel { get; set; }


        public TouchscreenPackingListViewModel TouchscreenPackingListViewModel { get; set; }

        public ReactiveCommand<Unit, Unit> ScanInstrumentForLookup { get; }

        private string _sterilizationIndicatorLotNumber;
        public string SterilizationIndicatorLotNumber
        {
            get => _sterilizationIndicatorLotNumber;
            set => this.RaiseAndSetIfChanged(ref _sterilizationIndicatorLotNumber, value);
        }

        private int _loggedInUserId;
        public int LoggedInUserId
        {
            get => _loggedInUserId;
            set => this.RaiseAndSetIfChanged(ref _loggedInUserId, value);
        }

        private List<Tuple<string, string>> _packingReport;
        public List<Tuple<string, string>> PackingReport
        {
            get => _packingReport;
            set => this.RaiseAndSetIfChanged(ref _packingReport, value);
        }

        private List<Tuple<string, string>> _trayContentsReport;
        public List<Tuple<string, string>> TrayContentsReport
        {
            get => _trayContentsReport;
            set => this.RaiseAndSetIfChanged(ref _trayContentsReport, value);
        }

        private bool _chooseCostCenter;
        public bool ChooseCostCenter
        {
            get => _chooseCostCenter;
            set => this.RaiseAndSetIfChanged(ref _chooseCostCenter, value);
        }

        private Container_RFID _currentContainer;
        public Container_RFID CurrentContainer
        {
            get => _currentContainer;
            set => this.RaiseAndSetIfChanged(ref _currentContainer, value);
        }

        private Tray_RFID _currentTray;
        public Tray_RFID CurrentTray
        {
            get => _currentTray;
            set => this.RaiseAndSetIfChanged(ref _currentTray, value);
        }
        private int _currentPage;
        public int CurrentPage
        {
            get => _currentPage;
            set => this.RaiseAndSetIfChanged(ref _currentPage, value);
        }
        private MessageViewModel _currentMessage;
        public MessageViewModel CurrentMessage
        {
            get => _currentMessage;
            set => this.RaiseAndSetIfChanged(ref _currentMessage, value);
        }

        private bool _isScanning;
        public bool IsScanning
        {
            get => _isScanning;
            set => this.RaiseAndSetIfChanged(ref _isScanning, value);
        }


        private Tray_Description _selectedTrayType;
        public Tray_Description SelectedTrayType
        {
            get => _selectedTrayType;
            set => this.RaiseAndSetIfChanged(ref _selectedTrayType, value);
        }

        private List<Tray_Description> _trayTypes;
        public List<Tray_Description> TrayTypes
        {
            get => _trayTypes;
            set => this.RaiseAndSetIfChanged(ref _trayTypes, value);
        }

        private bool _isLocked;
        public bool IsLocked
        {
            get => _isLocked;
            set => this.RaiseAndSetIfChanged(ref _isLocked, value);
        }

        private readonly ObservableAsPropertyHelper<int> _totalScanned;
        public int TotalScanned => _totalScanned.Value;

        private Image _sideImage;
        public Image SideImage
        {
            get => _sideImage;
            set => this.RaiseAndSetIfChanged(ref _sideImage, value);
        }

        private IEnumerable<Cost_Center> _costCenters;
        public IEnumerable<Cost_Center> CostCenters
        {
            get => _costCenters;
            set => this.RaiseAndSetIfChanged(ref _costCenters, value);
        }

        private IEnumerable<Cost_Type> _costTypes;
        public IEnumerable<Cost_Type> CostTypes
        {
            get => _costTypes;
            set => this.RaiseAndSetIfChanged(ref _costTypes, value);
        }

        private Cost_Center? _selectedCostCenter;
        public Cost_Center? SelectedCostCenter
        {
            get => _selectedCostCenter;
            set => this.RaiseAndSetIfChanged(ref _selectedCostCenter, value);
        }

        private Cost_Type? _selectedCostType;
        public Cost_Type? SelectedCostType
        {
            get => _selectedCostType;
            set => this.RaiseAndSetIfChanged(ref _selectedCostType, value);
        }

        private string _costCenterNote;
        public string CostCenterNote
        {
            get => _costCenterNote;
            set => this.RaiseAndSetIfChanged(ref _costCenterNote, value);
        }

        private int _numberOfLabelsToPrint;
        public int NumberOfLabelsToPrint
        {
            get => _numberOfLabelsToPrint;
            set => this.RaiseAndSetIfChanged(ref _numberOfLabelsToPrint, value);
        }

        private EntityServerModeSource _packingLogXPServerCollectionSource;
        public EntityServerModeSource PackingLogXPServerCollectionSource
        {
            get => _packingLogXPServerCollectionSource;
            set => this.RaiseAndSetIfChanged(ref _packingLogXPServerCollectionSource, value);
        }

        private int _selectedPackingLogId;
        private readonly CommonInteractions _commonInteractions;

        public int SelectedPackingLogId
        {
            get => _selectedPackingLogId;
            set => this.RaiseAndSetIfChanged(ref _selectedPackingLogId, value);
        }

        private List<Tray_Description> _currentInstrumentPackTrayTypes;
        public List<Tray_Description> CurrentInstrumentPackTrayTypes
        {
            get => _currentInstrumentPackTrayTypes;
            set => this.RaiseAndSetIfChanged(ref _currentInstrumentPackTrayTypes, value);
        }

        private Instrument_Description? _currentInstrument;
        public Instrument_Description? CurrentInstrument
        {
            get => _currentInstrument;
            set => this.RaiseAndSetIfChanged(ref _currentInstrument, value);
        }
    }
}
