using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using AdminStation.ViewModels.Validation;
using Caretag_Class;
using Caretag_Class.Configuration;
using Caretag_Class.Model;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.XtraBars.Docking2010.DragEngine;
using Main.Model.DevexpressModels;
using Main.ReactiveUI.Interactions;
using Main.Util;
using ReactiveUI;
using Surgical_Admin.Interactions;

namespace AdminStation.ViewModels.ReactiveUI;

public class InstrumentTypesViewModel : ReactiveObject, IRoutableViewModel, IDisposable, ExcelExportableViewModel
{
    private readonly CaretagModelFactory _caretagModelFactory;
    private readonly CommonInteractions _commonInteractions;
    private readonly Session _session;

    public InstrumentTypesViewModel(AppSettingsBase appSettingsBase, 
        CaretagModelFactory caretagModelFactory,
        CommonInteractionsFactory commonInteractionsFactory)
    {
        _caretagModelFactory = caretagModelFactory;
        XpoDefault.DataLayer =
            XpoDefault.GetDataLayer(appSettingsBase.ConnectionStrings.SQLServer, AutoCreateOption.None);
        _session = new Session(XpoDefault.DataLayer);
        ServerModeDS =
            new XPServerCollectionSource(_session, typeof(InstrumentDescriptionXPOModel));

        ServerModeDS.AllowEdit = true;
        ServerModeDS.AllowNew = true;
        ServerModeDS.AllowRemove = true;

        using var model = caretagModelFactory.Create();
        Vendors = model.Instrument_Vendor.ToList();
        InstrumentDescriptionValidator = new InstrumentDescriptionValidator();
        _commonInteractions = commonInteractionsFactory.Create(RxApp.MainThreadScheduler);
        ExportToExcelCommand = ReactiveCommand.Create(ExportToExcel, Observable.Return(true));
    }
    
    public InstrumentDescriptionValidator InstrumentDescriptionValidator { get; }
    public List<Instrument_Vendor> Vendors { get; set; }
    public XPServerCollectionSource ServerModeDS { get; set; }
    public string? UrlPathSegment => "InstrumentTypes";
    public IScreen HostScreen { get; }

    public void Dispose()
    {
        _session.Dispose();
        ServerModeDS.Dispose();
    }

    private void ExportToExcel()
    {
        using var model = _caretagModelFactory.Create();
        var filename = Common.ShowExcelSaveDialog();
        if (filename == null) return;
        var exporter = new ExcelExporter();
        var instruments = model.Instrument_Description.AsNoTracking().ToList(); // We have less than hundred thousand instruments, so this is acceptable.
        exporter.AddSheet(instruments, "Instruments");
        exporter.Save(filename);
        Common.ShowSuccessDialog();
    }
    public ReactiveCommand<Unit, Unit> ExportToExcelCommand { get; }
}