using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Reactive;
using AdminStation.ViewModels.DataTypeViewModels;
using AdminStation.ViewModels.Validation;
using Caretag_Class;
using Caretag_Class.Configuration;
using Caretag_Class.Model;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.XtraBars.Docking2010.DragEngine;
using DevExpress.XtraGrid.Views.Base;
using Main.Model.DevexpressModels;
using Main.Util;
using ReactiveUI;
using System.Data.Entity;

namespace AdminStation.ViewModels.ReactiveUI;

public class TraysViewModel: ReactiveObject, IRoutableViewModel, IDisposable, ExcelExportableViewModel
{
    private readonly CaretagModel _caretagModel;
    
    
    public TraysViewModel(AppSettingsBase appSettingsBase, CaretagModelFactory caretagModelFactory)
    {
        _caretagModel = caretagModelFactory.Create();
        XpoDefault.DataLayer =
            XpoDefault.GetDataLayer(appSettingsBase.ConnectionStrings.SQLServer, AutoCreateOption.None);
        _session = new Session(XpoDefault.DataLayer);
        
        AvailableInstrumentsDataSource = new XPServerCollectionSource(_session, typeof(InstrumentDescriptionXPOModel));
        AvailableCostItems = _caretagModel.Cost_Item.ToList();
        SaveChangesCommand = ReactiveCommand.Create<RowObjectEventArgs, Unit>(SaveChanges);
        
        Trays = new EFBackedBindingList<TrayViewModel, Tray_Description, int>(_caretagModel.Tray_Description, () => _caretagModel.SaveChanges(), new TrayValidator(), 
            _caretagModel.Tray_Description.Include(t => t.Images).Include(t => t.CostItem).ToList().Select(td => new TrayViewModel(td))); 
        AddInstrumentToTrayCommand = ReactiveCommand.Create(AddInstrumentToTray);
        RemoveInstrumentFromTrayCommand = ReactiveCommand.Create(RemoveInstrumentFromTray);
        SaveChangesInTrayCommand = ReactiveCommand.Create<RowObjectEventArgs, Unit>(SaveChangesInTrayPacklist);

        this.WhenAny(vm => vm.SelectedTrayDescription, vm => vm.Value?.Pkid)
            .Subscribe(descriptionId =>
            {
                if (descriptionId == null || descriptionId == 0)
                {
                    InstrumentsInTray = new BindingList<InstrumentInTrayViewModel>();
                    return;
                }
                InstrumentsInTray = new BindingList<InstrumentInTrayViewModel>(_caretagModel.Tray_PackList.Where(pl => 
                        pl.Tray_Descrip_ID == descriptionId).Include(tp => tp.InstrumentDescription).Include(tp => tp.InstrumentDescription).ToList()
                    .Select(pl => new InstrumentInTrayViewModel(pl)).ToList());
            });

        ExportToExcelCommand = ReactiveCommand.Create(ExportToExcel, this.WhenAnyValue(vm => vm.SelectedTrayDescription,(TrayViewModel? tray) => tray!= null));
    }

    public List<Cost_Item> AvailableCostItems { get; set; }
    public XPServerCollectionSource AvailableInstrumentsDataSource { get; set; }
    public string? UrlPathSegment => "Trays";
    public IScreen HostScreen { get; }
    public EFBackedBindingList<TrayViewModel, Tray_Description, int> Trays { get; set; }
    public ReactiveCommand<Unit, Unit> NavigateToEditCommand { get; set; }
    public ReactiveCommand<Unit, Unit> NavigateToTraysListCommand { get; set; }
    public ReactiveCommand<RowObjectEventArgs, Unit> SaveChangesCommand { get; set; }
    public ReactiveCommand<Unit, Unit> AddInstrumentToTrayCommand { get; set; }
    public ReactiveCommand<Unit, Unit> RemoveInstrumentFromTrayCommand { get; set; }
    public ReactiveCommand<RowObjectEventArgs, Unit> SaveChangesInTrayCommand { get; set; }
    
    private TrayViewModel? _selectedTrayDescription;
    public TrayViewModel? SelectedTrayDescription
    {
        get => _selectedTrayDescription;
        set => this.RaiseAndSetIfChanged(ref _selectedTrayDescription, value);
    }

    public InstrumentInTrayViewModel? _selectedInstrumentInTray;
    public InstrumentInTrayViewModel? SelectedInstrumentInTray
    {
        get => _selectedInstrumentInTray;
        set => this.RaiseAndSetIfChanged(ref _selectedInstrumentInTray, value);
    }
    public InstrumentDescriptionXPOModel _selectedInstrumentAvailable;
    public InstrumentDescriptionXPOModel SelectedInstrumentAvailable
    {
        get => _selectedInstrumentAvailable;
        set => this.RaiseAndSetIfChanged(ref _selectedInstrumentAvailable, value);
    }

    private BindingList<InstrumentInTrayViewModel> _instrumentsInTray;
    public BindingList<InstrumentInTrayViewModel> InstrumentsInTray
    {
        get => _instrumentsInTray;
        set => this.RaiseAndSetIfChanged(ref _instrumentsInTray, value);
    }

    private void AddInstrumentToTray()
    {
        if (_caretagModel.Tray_PackList.Any(pl => 
                pl.Tray_Descrip_ID == SelectedTrayDescription.Pkid && 
                pl.Instrument_Descrip_ID == SelectedInstrumentAvailable.Description_ID))
        {
            //TODO error via interactions
            return;
        }
        
        _caretagModel.Tray_PackList.Add(new Tray_PackList()
        {
            Instrument_Descrip_ID = SelectedInstrumentAvailable.Description_ID,
            TrayDescription= _caretagModel.Tray_Description.First(t => t.Description_ID == SelectedTrayDescription.Pkid),
            Number = 1,
            Date_Changed = DateTime.Now
        });
        
        var instrumentInTrayViewModel = InstrumentsInTray.AddNew();
        instrumentInTrayViewModel.Description= SelectedInstrumentAvailable.GetFullDescription();
        instrumentInTrayViewModel.Amount= 1;
        instrumentInTrayViewModel.DescriptionId = SelectedInstrumentAvailable.Description_ID;
        instrumentInTrayViewModel.Vendor = SelectedInstrumentAvailable.Instrument_Company;
        InstrumentsInTray.EndNew(InstrumentsInTray.Count - 1);
        
        _caretagModel.SaveChanges();
    }

    private void RemoveInstrumentFromTray()
    {
        var currentInstrumentDescriptionId = SelectedInstrumentInTray?.DescriptionId ?? "";

        var packlistEntry = _caretagModel.Tray_PackList.FirstOrDefault(pl =>
            pl.Tray_Descrip_ID == SelectedTrayDescription.Pkid &&
            pl.Instrument_Descrip_ID == currentInstrumentDescriptionId);
        if (packlistEntry != null)
        {
            _caretagModel.Tray_PackList.Remove(packlistEntry);

            InstrumentsInTray.Remove(SelectedInstrumentInTray);

            _caretagModel.SaveChanges();
        }
        else
        {
            //TODO error via interactions
        }
    }

    private void NavigateToEdit()
    {
        SelectedPage = 1;
    }
    
    private void NavigateToTraysList()
    {
        SelectedPage = 0;
    }

    private Unit SaveChangesInTrayPacklist(RowObjectEventArgs rowObjectEventArgs)
    {
        var instrument= (InstrumentInTrayViewModel)rowObjectEventArgs.Row;
        _caretagModel.Tray_PackList.First(pl => pl.Tray_Descrip_ID == SelectedTrayDescription.Pkid &&
                                                pl.Instrument_Descrip_ID == instrument.DescriptionId).Number = instrument.Amount;

        _caretagModel.SaveChanges(); 
        return Unit.Default;
    }

    private Unit SaveChanges(RowObjectEventArgs args)
    {
        _caretagModel.SaveChanges();
        return Unit.Default;
    }

    private int _selectedPage;
    private readonly Session _session;

    public int SelectedPage
    {
        get => _selectedPage;
        set => this.RaiseAndSetIfChanged(ref _selectedPage, value);
    }
    
    public void Dispose()
    {
        _caretagModel.Dispose();
        AvailableInstrumentsDataSource.Dispose();
        NavigateToEditCommand.Dispose();
        NavigateToTraysListCommand.Dispose();
        _session.Dispose();
    }

    private void ExportToExcel()
    {
        var filename = Common.ShowExcelSaveDialog();
        if (filename == null) return;
        var exporter = new ExcelExporter();
        exporter.AddSheet(Trays, "Trays");
        exporter.AddSheet(InstrumentsInTray, "Instruments in " + SelectedTrayDescription?.Tray_Name);
        exporter.Save(filename);
        Common.ShowSuccessDialog();
    }
    public ReactiveCommand<Unit, Unit> ExportToExcelCommand { get; }
}