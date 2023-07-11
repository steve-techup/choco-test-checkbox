using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Forms;
using AdminStation.ViewModels;
using AdminStation.ViewModels.DataTypeViewModels;
using AdminStation.ViewModels.ReactiveUI;
using Caretag_Class.Model;
using DevExpress.XtraGrid.Views.Base;
using Main.Model.DevexpressModels;
using Main.ReactiveUI;
using ReactiveUI;

namespace AdminStation.Views.Assets;

public partial class CostCentersView : UserControl, IViewFor<CostCentersViewModel>
{
    private CostCentersViewModel _vm;
        
    object? IViewFor.ViewModel
    {
        get => _vm;
        set => _vm = (CostCentersViewModel)value!;
    }

    CostCentersViewModel IViewFor<CostCentersViewModel>.ViewModel
    {
        get => _vm;
        set => _vm = value;
    }

    public CostCentersView(CostCentersViewModel vm)
    {
        InitializeComponent();
        _vm = vm;

        costTypesGridControl.DataSource = _vm.CostTypes;
        costCentersGridControl.DataSource = _vm.CostCenters;
        
        this.WhenActivated(b =>
        {

            //b(Observable.FromEventPattern(costCentersGridView, nameof(costCentersGridView.RowUpdated))
            //    .Subscribe(x => vm.SaveChangesCommand.Execute(Unit.Default).Subscribe()));
            
            b(costTypesGridControl.ObservableForSelection<CostTypeViewModel>()
                .Subscribe(ct => vm.SelectedCostType = ct));
            b(costCentersGridView.ObservableForSelection<CostCenterViewModel>().Subscribe(t => vm.SelectedCostCenter = t));
            b(this.OneWayBind(vm, model => model.CostItemsForCostCenter, view => view.costItemsGridControl.DataSource));
            b(this.BindCommand(vm, model => model.RemoveCostItemCommand, view => view.removeCostItemButton));
            b(this.BindCommand(vm, model => model.AddCostItemCommand, view => view.addCostItemButton));
            b(Observable.FromEventPattern(costItemsGridView, nameof(costItemsGridView.RowUpdated))
                .Subscribe(x => vm.SaveChangesCommand.Execute().Subscribe()));
            b(Observable.FromEventPattern(costCentersGridView, nameof(costCentersGridView.ValidateRow))
                .Subscribe(vm.CostCenters.RowValidating));
            b(Observable.FromEventPattern(costItemsGridView, nameof(costItemsGridView.ValidateRow))
                .Subscribe(vm.CostItemsForCostCenter.RowValidating));
            b(Observable.FromEventPattern(costTypesGridView, nameof(costTypesGridView.ValidateRow))
                .Subscribe(vm.CostTypes.RowValidating));


            b(costItemsGridView.ObservableForSelection<CostItemViewModel>().Subscribe(ci => vm.SelectedCostItem = ci));
            
            costCentersGridView.SelectRow(0);
            costTypesGridView.SelectRow(0);
            vm.SelectedCostCenter = costCentersGridView.GetFocusedRow() as CostCenterViewModel;
            vm.SelectedCostType = costTypesGridView.GetFocusedRow() as CostTypeViewModel;
        });

    }
    //ValidateRowEventArgs
}