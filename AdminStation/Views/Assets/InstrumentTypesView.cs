using System;
using System.Diagnostics.Tracing;
using System.Reactive.Linq;
using System.Windows.Forms;
using AdminStation.ViewModels.ReactiveUI;
using Caretag_Class.EventReporting;
using Caretag_Class.Model;
using DevExpress.XtraGrid.Views.Base;
using ReactiveUI;

namespace AdminStation.Views.Assets;

public partial class InstrumentTypesView : UserControl, IViewFor<InstrumentTypesViewModel>
{
    private InstrumentTypesViewModel _vm;

    public InstrumentTypesView(EventReporter eventReporter, InstrumentTypesViewModel vm)
    {
        InitializeComponent();
        _vm = vm;
        AppDomain.CurrentDomain.FirstChanceException += (sender, args) =>
        {
            if (args.Exception is InvalidOperationException)
                eventReporter.ReportError(args.Exception, "An error occurred while querying the database ",
                    "An error occurred while loading the grid view", "AdminStation-218", true, true);
        };
        gridControl1.DataSource = _vm.ServerModeDS;
        repositoryItemSearchLookUpEdit1.DataSource = _vm.Vendors;
        repositoryItemSearchLookUpEdit1.ValueMember = "Vendor_ID";
        repositoryItemSearchLookUpEdit1.DisplayMember = "Vendor_Name";

        this.WhenActivated(b =>
        {
            b(Observable.FromEventPattern(gridView1, nameof(gridView1.ValidateRow))
                .Subscribe(x => vm.InstrumentDescriptionValidator.RowValidating(x)));
        });
        /*
        repositoryItemImageEdit1.BeforePopup += (sender, args) =>
        {
            var edit = (DevExpress.XtraEditors.Repository.RepositoryItemImageEdit)sender;
            
            DevExpress.Utils.ImageCollection images = new DevExpress.Utils.ImageCollection();
            
            images.AddImage(vm.GetImage());
            edit.Images = images;
            
        };*/
    }
    
    object? IViewFor.ViewModel
    {
        get => _vm;
        set => _vm = (InstrumentTypesViewModel) value!;
    }

    InstrumentTypesViewModel IViewFor<InstrumentTypesViewModel>.ViewModel
    {
        get => _vm;
        set => _vm = value;
    }
}