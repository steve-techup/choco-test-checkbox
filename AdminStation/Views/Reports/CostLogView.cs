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
using AdminStation.ViewModels.ReactiveUI;
using ReactiveUI;

namespace AdminStation.Views.Reports
{
    public partial class CostLogView : UserControl, IViewFor<CostLogViewModel>
    {
        private CostLogViewModel _vm;

        public CostLogView(CostLogViewModel vm)
        {
            _vm = vm;
            InitializeComponent();

            _vm.AvailableCostCenters.ForEach(c =>
            {
                costCentersComboBoxEdit.Properties.Items.Add(c);
            });
            
            this.WhenActivated(b =>
            {
                b(_vm.WhenAnyValue(x => x.Report).Subscribe(report =>
                {
                    costLogGridControl.DataSource = report;

                }));
                
                //b(this.Bind(_vm, vm => vm.Report, v => v.costLogGridControl.DataSource));
                b(this.Bind(_vm, vm => vm.From, v => v.fromDateEdit.DateTime));
                b(this.Bind(_vm, vm => vm.To, v => v.toDateEdit.DateTime));

                b(this.Bind(_vm, vm => vm.SelectedCostCenter, v => v.costCentersComboBoxEdit.SelectedItem, 
                    Observable.FromEventPattern(costCentersComboBoxEdit, nameof(costCentersComboBoxEdit.EditValueChanged))));
                b(this.Bind(_vm, vm => vm.SelectedCostItem, v => v.costItemsComboBoxEdit.SelectedItem,
                    Observable.FromEventPattern(costItemsComboBoxEdit, nameof(costItemsComboBoxEdit.EditValueChanged))));

                b(_vm.WhenAnyValue(vm => vm.AvailableCostItems)
                    .Subscribe(items =>
                    {
                        costItemsComboBoxEdit.Properties.Items.Clear();
                        items.ForEach(i => costItemsComboBoxEdit.Properties.Items.Add(i));
                        costItemsComboBoxEdit.Enabled = items.Count > 0;
                    }));
                
                b(this.BindCommand(_vm, vm => vm.GenerateReportCommand, v => v.generateReportSimpleButton));

                b(_vm.WhenAnyValue(x => x.ExcelExportFilename)
                    .Subscribe(filename =>
                    {
                        if (!string.IsNullOrWhiteSpace(filename))
                            costLogGridControl.ExportToXlsx(filename);
                    }));
            });
        }

        object? IViewFor.ViewModel
        {
            get => _vm;
            set => _vm = (CostLogViewModel)value!;
        }

        CostLogViewModel IViewFor<CostLogViewModel>.ViewModel
        {
            get => _vm;
            set => _vm = value;
        }
    }
}
