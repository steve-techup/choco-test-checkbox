using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading.Tasks;
using AdminStation.Services;
using Caretag_Class.ReactiveUI;
using DynamicData;
using Main.ReactiveUI.Interactions;
using ReactiveUI;

namespace AdminStation.ViewModels.ReactiveUI;

public class CSVImportViewModel : ReactiveObject, IRoutableViewModel
{
    private readonly SourceList<string> _columnNames = new();
    private bool _autoImageSearch;

    private int _currentWizardPage;

    private DataTable _dataTable;

    private string _delimiter;


    // viewmodel property for the selected filename
    private string _filename;

    private string _imageSearchPattern;

    private int _progressBarState;

    private int _selectedDescriptionIdColumnIndexIndex = -1;

    private int _selectedImageUrlColumnIndexIndex = -1;

    private int _selectedInstrumentDescriptionColumnIndexIndex = -1;

    private int _selectedInstrumentVendorColumnIndex = -1;

    private int _selectedPackingSetNameColumnIndexIndex = -1;

    private int _selectedQuantityColumnIndexIndex = -1;

    private int _selectedUntaggableColumnIndex = -1;

    public CSVImportViewModel(CommonInteractionsFactory commonInteractionsFactory, CSVImportService csvImportService,
        IScheduler? scheduler = null)
    {
        Scheduler = scheduler ?? RxApp.MainThreadScheduler;
        var commonInteractions = commonInteractionsFactory.Create(Scheduler);
        var csvImportService1 = csvImportService;

        // Browse command opens a browse interaction
        Browse = ReactiveCommand.CreateFromTask(async () =>
        {
            var file = await commonInteractions.BrowseOpenCSVInteraction.Handle(Unit.Default).FirstAsync();
            Filename = file;
            var likelyDelimiter = GuessDelimiter();
            if (likelyDelimiter != null)
                Delimiter = likelyDelimiter;
            return Unit.Default;
        }, outputScheduler: RxApp.MainThreadScheduler);

        OpenFileCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            DataTable = csvImportService1.Load(_filename, _delimiter);
            if (DataTable == null)
                return Unit.Default;
            if (DataTable.Rows.Count > 0)
            {
                _columnNames.AddRange(DataTable.Columns.Cast<DataColumn>().Select(x => x.ColumnName));
                CurrentWizardPage = 1;
            }

            return Unit.Default;
        }, outputScheduler: RxApp.MainThreadScheduler);

        Import = ReactiveCommand.CreateFromTask(async () =>
        {
            var columnNames = new CSVImportService.ColumnNames
            {
                DescriptionId = DataTable.Columns[SelectedDescriptionIdColumnIndex].ColumnName,
                Quantity = DataTable.Columns[SelectedQuantityColumnIndex].ColumnName,
                Description = DataTable.Columns[SelectedInstrumentDescriptionColumnIndex].ColumnName,
                SetName = DataTable.Columns[SelectedPackingSetNameColumnIndex].ColumnName,
                ImageUrl = AutoImageSearch ? "" : DataTable.Columns[SelectedImageUrlColumnIndex].ColumnName,
                VendorId = DataTable.Columns[SelectedInstrumentVendorColumnIndex].ColumnName,
                Untaggable = DataTable.Columns[SelectedUntaggableColumnIndex].ColumnName
            };

            // get the directory for _filename
            await Task.Run(async () =>
            {
                try
                {
                    await csvImportService1.SaveInDatabase(DataTable, columnNames,
                        val =>
                        {
                            Observable.Start(() => { ProgressBarState = val; }, RxApp.MainThreadScheduler).Subscribe();
                        },
                        AutoImageSearch, ImageSearchPattern, Path.GetDirectoryName(_filename));

                    commonInteractions.Confirm.Handle(new CaretagMessageBoxArguments
                    {
                        Options = CaretagMessageBoxOptions.Ok,
                        Title = "Import successful",
                        Message = "Import successful",
                        IsWarning = false
                    }).Subscribe();
                }
                catch (Exception e)
                {
                    commonInteractions.ExceptionInteraction.Handle(e).Subscribe();
                }
            });
        });

        Back = ReactiveCommand.Create(() => { Reset(); });

        Browse.ThrownExceptions.Subscribe(ex => { commonInteractions.ExceptionInteraction.Handle(ex).Subscribe(); });
        OpenFileCommand.ThrownExceptions.Subscribe(ex =>
        {
            commonInteractions.ExceptionInteraction.Handle(ex).Subscribe();
        });
        Import.ThrownExceptions.Subscribe(ex => { commonInteractions.ExceptionInteraction.Handle(ex).Subscribe(); });
    }

    public string Filename
    {
        get => _filename;
        set => this.RaiseAndSetIfChanged(ref _filename, value);
    }

    public string Delimiter
    {
        get => _delimiter;
        set => this.RaiseAndSetIfChanged(ref _delimiter, value);
    }

    public int CurrentWizardPage
    {
        get => _currentWizardPage;
        set => this.RaiseAndSetIfChanged(ref _currentWizardPage, value);
    }

    public DataTable DataTable
    {
        get => _dataTable;
        set => this.RaiseAndSetIfChanged(ref _dataTable, value);
    }

    public ReactiveCommand<Unit, Unit> OpenFileCommand { get; }

    public ReactiveCommand<Unit, Unit> Browse { get; }
    public ReactiveCommand<Unit, Unit> Import { get; }
    public ReactiveCommand<Unit, Unit> Back { get; }

    public int SelectedDescriptionIdColumnIndex
    {
        get => _selectedDescriptionIdColumnIndexIndex;
        set => this.RaiseAndSetIfChanged(ref _selectedDescriptionIdColumnIndexIndex, value);
    }

    public int SelectedQuantityColumnIndex
    {
        get => _selectedQuantityColumnIndexIndex;
        set => this.RaiseAndSetIfChanged(ref _selectedQuantityColumnIndexIndex, value);
    }

    public int SelectedInstrumentDescriptionColumnIndex
    {
        get => _selectedInstrumentDescriptionColumnIndexIndex;
        set => this.RaiseAndSetIfChanged(ref _selectedInstrumentDescriptionColumnIndexIndex, value);
    }

    public int SelectedPackingSetNameColumnIndex
    {
        get => _selectedPackingSetNameColumnIndexIndex;
        set => this.RaiseAndSetIfChanged(ref _selectedPackingSetNameColumnIndexIndex, value);
    }

    public int SelectedImageUrlColumnIndex
    {
        get => _selectedImageUrlColumnIndexIndex;
        set => this.RaiseAndSetIfChanged(ref _selectedImageUrlColumnIndexIndex, value);
    }

    public int SelectedInstrumentVendorColumnIndex
    {
        get => _selectedInstrumentVendorColumnIndex;
        set => this.RaiseAndSetIfChanged(ref _selectedInstrumentVendorColumnIndex, value);
    }

    public bool AutoImageSearch
    {
        get => _autoImageSearch;
        set => this.RaiseAndSetIfChanged(ref _autoImageSearch, value);
    }

    public string ImageSearchPattern
    {
        get => _imageSearchPattern;
        set => this.RaiseAndSetIfChanged(ref _imageSearchPattern, value);
    }

    public int SelectedUntaggableColumnIndex
    {
        get => _selectedUntaggableColumnIndex;
        set => this.RaiseAndSetIfChanged(ref _selectedUntaggableColumnIndex, value);
    }

    public int ProgressBarState
    {
        get => _progressBarState;
        set => this.RaiseAndSetIfChanged(ref _progressBarState, value);
    }

    public IScheduler Scheduler { get; set; }

    public string? UrlPathSegment => "csvImport";
    public IScreen HostScreen { get; }

    public IObservable<IChangeSet<string>> ConnectToColumnNames()
    {
        return _columnNames.Connect();
    }

    private string GuessDelimiter()
    {
        var firstLine = File.ReadLines(_filename).First();
        if (firstLine.Contains('|'))
            return "|";
        if (firstLine.Contains(';'))
            return ";";
        if (firstLine.Contains(','))
            return ",";
        if (firstLine.Contains('\t'))
            return "\t";
        return null;
    }

    public void Reset()
    {
        Filename = string.Empty;
        Delimiter = string.Empty;
        CurrentWizardPage = 0;
        DataTable = null;
        SelectedDescriptionIdColumnIndex = -1;
        SelectedQuantityColumnIndex = -1;
        SelectedInstrumentDescriptionColumnIndex = -1;
        SelectedPackingSetNameColumnIndex = -1;
        SelectedImageUrlColumnIndex = -1;
        SelectedInstrumentVendorColumnIndex = -1;
        AutoImageSearch = false;
        ImageSearchPattern = string.Empty;
        ProgressBarState = 0;
    }
}