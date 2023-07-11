using System;
using System.Reactive.Linq;
using System.Windows.Forms;
using AdminStation.ViewModels.DataTypeViewModels;
using AdminStation.ViewModels.ReactiveUI;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Main.Model.DevexpressModels;
using Main.ReactiveUI;
using ReactiveUI;

namespace AdminStation.Views.Reports;

public partial class ScansView : UserControl, IViewFor<ScansViewModel>
{
    private ScansViewModel _vm;
    
    public ScansView(ScansViewModel vm)
    {
        _vm = vm;
        
        InitializeComponent();
        scansGridControl.DataSource = _vm.ServerModeDS;
        
        this.WhenActivated(b =>
        {
            b(Observable.FromEventPattern(scansGridView, nameof(scansGridView.DoubleClick))
                .Subscribe(evt =>
                {
                    DXMouseEventArgs ea = evt.EventArgs as DXMouseEventArgs;
                    GridView view = evt.Sender as GridView;
                    GridHitInfo info = view.CalcHitInfo(ea.Location);
                    if (info.InRow || info.InRowCell)
                    {
                        var row = view.GetRow(info.RowHandle) as ValidatedPackingListXPOModel;
                        vm.ShowValidatedPackingListDetailsCommand.Execute(row.Id).Subscribe();
                    }
                }));
        });
    }
    
    object? IViewFor.ViewModel
    {
        get => _vm;
        set => _vm = (ScansViewModel) value!;
    }

    ScansViewModel IViewFor<ScansViewModel>.ViewModel
    {
        get => _vm;
        set => _vm = value;
    }
}