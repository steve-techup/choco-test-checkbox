using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caretag_Class.ReactiveUI.ViewModels;
using Caretag_Class.Util.UI;
using ReactiveUI;
using static Caretag_Class.ReactiveUI.ViewModels.TouchscreenPackingListViewModel;

namespace Caretag_Class.ReactiveUI.Views;

public partial class TouchscreenPackingListView : UserControl, IViewFor<TouchscreenPackingListViewModel>
{
    private readonly string ManualPackingColumnName = "manualImageColumn";
    private readonly string StatusColumnName = "StatusColumn";
    private readonly string VendorColumnName = "InstrumentVendorColumn";
    public TouchscreenPackingListView()
    {
        InitializeComponent();

        this.WhenActivated(d =>
        {
            this.OneWayBind(ViewModel, vm => vm.PackingListRowsCollection,
                view => view.DataGridViewInstruments.DataSource,
                list =>
                {
                    DataGridViewInstruments.Refresh();
                    return list;
                });

            // Only update SelectedPackingListRow if the SelectionChanged event is fired with 250ms of the click event
            DataGridViewInstruments.Events().Click.Join(DataGridViewInstruments.Events().SelectionChanged, 
                _ => Observable.Return(0).Delay(new TimeSpan(0,0,0,0,250)), 
                _ => Observable.Return(0).Delay(new TimeSpan(0, 0, 0, 0, 250)), 
                (x,y)=> x)
                .Subscribe(_ =>
            {
                if (DataGridViewInstruments.SelectedRows.Count > 0)
                    ViewModel.SelectedPackingListRow =
                        DataGridViewInstruments.SelectedRows[0].DataBoundItem as PackingListRowViewModel;
                else
                    ViewModel.SelectedPackingListRow = null!;
            });
            
            ViewModel.WhenAnyValue(vm => vm.PackingListMode).Subscribe(mode =>
            {
                switch (mode)
                {
                    case Mode.Checkbox:
                        DataGridViewInstruments.Columns[StatusColumnName].Visible = true;
                        DataGridViewInstruments.Columns[VendorColumnName].Visible = false;
                        DataGridViewInstruments.SelectionMode = DataGridViewSelectionMode.CellSelect;
                        break;
                    case Mode.Standard:
                        DataGridViewInstruments.Columns[StatusColumnName].Visible = false;
                        DataGridViewInstruments.Columns[VendorColumnName].Visible = true;
                        break;
                }
            });
        });

    }

    public TouchscreenPackingListViewModel ViewModel { get; set; }

    object IViewFor.ViewModel
    {
        get => ViewModel;
        set => ViewModel = (TouchscreenPackingListViewModel) value;
    }
        
    private void DataGridViewInstruments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        var row = DataGridViewInstruments.Rows[e.RowIndex];

        //for each cell in row set the color to yellow if not all instruments are packed and green if all instruments are packed
        if (row.DataBoundItem is PackingListRowViewModel packingListRow)
        {
            if (packingListRow.NotPacked)
                row.DefaultCellStyle.BackColor = Color.Lavender;
            else if (packingListRow.TotalPacked == 0)
                row.DefaultCellStyle.BackColor = Color.LightGray;
            else
                row.DefaultCellStyle.BackColor = packingListRow.TotalPacked != packingListRow.Quantity
                    ? Color.Yellow
                    : Color.Green;
        }
    }

    private void DataGridViewInstruments_MouseDown(object sender, MouseEventArgs e)
    {
        DataGridViewInstruments.ClearSelection();
    }

    private void DataGridViewInstruments_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
        DataGridViewInstruments.ClearSelection();
    }

    private void Clicked(DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == DataGridViewInstruments.Columns[ManualPackingColumnName].Index && e.RowIndex != -1)
        {
            DataGridViewInstruments.BeginEdit(true);
            TouchScreenNumberDialogViewModel numberDialogViewModel = new();
            var row = DataGridViewInstruments.Rows[e.RowIndex];
            var packingListRowViewModel = row.DataBoundItem as PackingListRowViewModel;
            if (!packingListRowViewModel.CanPackManually)
                return;

            numberDialogViewModel.Number = packingListRowViewModel.QuantityPackedManually;
            numberDialogViewModel.Message = "Enter the number of instruments packed manually";
            
            TouchscreenNumberDialog numberDialog = new();
            numberDialog.ViewModel = numberDialogViewModel;
            numberDialog.StartPosition = FormStartPosition.CenterParent;
            numberDialog.ShowDialog(this);
            if (numberDialogViewModel.ShowDialog == false)
            {
                packingListRowViewModel.QuantityPackedManually = numberDialogViewModel.Number;
            }
            
            ViewModel.PackingListRowsCollection.ResetItem(
                ViewModel.PackingListRowsCollection.IndexOf(packingListRowViewModel));
        }
    }

    private void DataGridViewInstruments_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void DataGridViewInstruments_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void DataGridViewInstruments_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        DataGridViewInstruments.ClearSelection();
        foreach (DataGridViewRow dataGridViewRow in DataGridViewInstruments.Rows)
        {
            dataGridViewRow.Cells[ManualPackingColumnName].ReadOnly = true;
        }

        if(DataGridViewInstruments.Columns["NotPacked"] != null)
        {
            DataGridViewInstruments.Columns["NotPacked"].Visible = false;
        }
    }

    private void DataGridViewInstruments_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
    {
        if (DataGridViewInstruments.Columns[e.ColumnIndex].Name == ManualPackingColumnName)
        {       
            if (e.Value != null)
            {
                try
                {
                    e.Value = int.Parse(e.Value.ToString());
                    // Set the ParsingApplied property to 
                    // Show the event is handled.
                    e.ParsingApplied = true;
                }
                catch (FormatException)
                {
                    // Set to false in case another CellParsing handler
                    // wants to try to parse this DataGridViewCellParsingEventArgs instance.
                    e.ParsingApplied = false;
                }
            }
        }
    }

    private void DataGridViewInstruments_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        Clicked(e);
    }

    private void DataGridViewInstruments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        Clicked(e);
    }
}