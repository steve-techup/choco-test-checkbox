using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using ReactiveUI;
using static Caretag_Class.ReactiveUI.ViewModels.TouchscreenPackingListViewModel;

namespace Main.ReactiveUI
{
    public static class Extensions
    {
        public static IObservable<T> ObservableForSelection<T>(this DataGridView gridView)
        {
            return Observable.FromEventPattern<DataGridViewCellEventHandler, DataGridViewCellEventArgs>(
                    h => gridView.CellClick += h,
                    h => gridView.CellClick -= h)
                .Select(x => x.EventArgs.RowIndex)
                .Where(x => x >= 0)
                .Select(x => gridView.Rows[x].DataBoundItem)
                .Cast<T>();
        }

        public static IObservable<T> ObservableForSelection<T>(this GridControl gridControl)
        {
            return ((GridView)gridControl.DefaultView).ObservableForSelection<T>();

        }

        public static IObservable<T> ObservableForSelection<T>(this GridView gridView)
        {
            return Observable.FromEventPattern(gridView, nameof(gridView.SelectionChanged))
                .Merge(Observable.FromEventPattern(gridView, nameof(gridView.RowCountChanged)))
                .Select(_ => (T) gridView.GetRow(gridView.FocusedRowHandle));
        }

        
    }
}
