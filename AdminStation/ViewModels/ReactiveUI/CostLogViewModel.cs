using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminStation.ViewModels.DataTypeViewModels;
using Caretag_Class;
using Caretag_Class.Model;

namespace AdminStation.ViewModels.ReactiveUI
{
    public class CostLogViewModel : ReactiveObject, IRoutableViewModel, IDisposable, ExcelExportableViewModel
    {
        private readonly CaretagModel _model;

        public CostLogViewModel(CaretagModelFactory caretagModelFactory)
        {
            _model = caretagModelFactory.Create();
            GenerateReportCommand = ReactiveCommand.Create(GenerateReport);
            AvailableCostCenters = _model.Cost_Center.ToList();

            this.WhenAnyValue(vm => vm.SelectedCostCenter).Subscribe(selection =>
            {
                AvailableCostItems = selection == null ? new List<Cost_Item>() : _model.Cost_Item.Where(ci => ci.Cost_Center == selection.Index_ID).ToList();
            });
            
            From = DateTime.Now.AddMonths(-1);
            To = DateTime.Now;
            ExportToExcelCommand = ReactiveCommand.Create(ExportToExcel, 
                this.WhenAnyValue(vm => vm.Report.Count, count => count > 0));
        }

        private void ExportToExcel()
        {
            ExcelExportFilename = Common.ShowExcelSaveDialog();
            ExcelExportFilename = null;
        }

        private string _excelExportFilename;
        public string ExcelExportFilename
        {
            get => _excelExportFilename;
            set => this.RaiseAndSetIfChanged(ref _excelExportFilename, value);
        }
        
        private DateTime _from;
        public DateTime From
        {
            get => _from;
            set => this.RaiseAndSetIfChanged(ref _from, value);
        }

        private DateTime _to;
        public DateTime To
        {
            get => _to;
            set => this.RaiseAndSetIfChanged(ref _to, value);
        }

        private Cost_Center? _selectedCostCenter;
        public Cost_Center? SelectedCostCenter
        {
            get => _selectedCostCenter;
            set => this.RaiseAndSetIfChanged(ref _selectedCostCenter, value);
        }

        private Cost_Item? _selectedCostItem;
        public Cost_Item? SelectedCostItem
        {
            get => _selectedCostItem;
            set => this.RaiseAndSetIfChanged(ref _selectedCostItem, value);
        }

        public List<Cost_Center> AvailableCostCenters { get; set; }

        private List<Cost_Item> _availableCostItems;
        public List<Cost_Item> AvailableCostItems
        {
            get => _availableCostItems;
            set => this.RaiseAndSetIfChanged(ref _availableCostItems, value);
        }

        private List<CostLogReportLine> _report;
        public List<CostLogReportLine> Report
        {
            get => _report;
            set => this.RaiseAndSetIfChanged(ref _report, value);
        }

        public ReactiveCommand<Unit, Unit> GenerateReportCommand { get; }

        private void GenerateReport()
        {
            if (SelectedCostCenter == null || SelectedCostItem == null)
            {
                MessageBox.Show("Please select Cost Center and Cost Item");
                return;
            }
            Report = _model.Cost_Log.Where(cl => cl.CostItemId == SelectedCostItem.Index_ID && cl.ChangeDate >= From && cl.ChangeDate <= To).Select(cl =>
                    new { cl.Tray_Description, cl.ChangeDate})
                .ToList().Select(x => new CostLogReportLine
                {
                    Price = SelectedCostItem.CostType.Cost_Price, 
                    Timestamp = x.ChangeDate,
                    TrayName = x.Tray_Description?.Tray_Name ?? "N/A"
                }).ToList();
        }

        public string? UrlPathSegment { get; }
        public IScreen HostScreen { get; }
        public void Dispose()
        {
            _model.Dispose();
        }

        public ReactiveCommand<Unit, Unit> ExportToExcelCommand { get; }

    }
}
