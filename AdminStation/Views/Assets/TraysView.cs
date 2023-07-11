using System;
using System.Reactive.Linq;
using System.Windows.Forms;
using AdminStation.ViewModels.DataTypeViewModels;
using AdminStation.ViewModels.ReactiveUI;
using Caretag_Class.Model;
using DevExpress.XtraGrid.Views.Base;
using Main.Model.DevexpressModels;
using Main.ReactiveUI;
using ReactiveUI;

namespace AdminStation.Views.Assets;

public partial class TraysView : UserControl, IViewFor<TraysViewModel>
{
    private TraysViewModel _vm;
    
    public TraysView(TraysViewModel vm)
    {
        _vm = vm;
        
        InitializeComponent();

        traysGridControl.DataSource = _vm.Trays;
        availableInstrumentsGridControl.DataSource = _vm.AvailableInstrumentsDataSource;

        repositoryItemSearchLookUpEdit1.DataSource = _vm.AvailableCostItems;

        this.WhenActivated(b =>
        {
            b(Observable.FromEventPattern(trayGridView, nameof(trayGridView.RowUpdated))
                .Subscribe(x => vm.SaveChangesCommand.Execute((RowObjectEventArgs) x.EventArgs).Subscribe()));
            b(Observable.FromEventPattern(trayGridView, nameof(trayGridView.ValidateRow))
                .Subscribe(x => vm.Trays.RowValidating(x)));
            b(trayGridView.ObservableForSelection<TrayViewModel>().Subscribe(t => vm.SelectedTrayDescription = t));
            b(this.OneWayBind(vm, model => model.InstrumentsInTray, view => view.trayInstrumentsGridControl.DataSource));
            b(this.BindCommand(vm, model => model.AddInstrumentToTrayCommand, view => view.addInstrumentToTrayButton));
            b(this.BindCommand(vm, model => model.RemoveInstrumentFromTrayCommand, view => view.removeInstrumentFromTrayButton));
            b(availableInstrumentsGridControl.ObservableForSelection<InstrumentDescriptionXPOModel>()
                .Subscribe(i => vm.SelectedInstrumentAvailable = i));
            b(Observable.FromEventPattern(instrumentsInTrayGridView, nameof(instrumentsInTrayGridView.RowUpdated))
                .Subscribe(x => vm.SaveChangesInTrayCommand.Execute((RowObjectEventArgs)x.EventArgs).Subscribe()));
              
            
            b(instrumentsInTrayGridView.ObservableForSelection<InstrumentInTrayViewModel>().Subscribe(i => vm.SelectedInstrumentInTray = i));
        });
    }
    
    object? IViewFor.ViewModel
    {
        get => _vm;
        set => _vm = (TraysViewModel) value!;
    }

    TraysViewModel IViewFor<TraysViewModel>.ViewModel
    {
        get => _vm;
        set => _vm = value;
    }
}