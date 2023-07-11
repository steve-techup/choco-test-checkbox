using System;
using System.Windows.Forms;
using Caretag_Class.Model;
using CheckboxStation.Services;
using CheckboxStation.ViewModels;
using CheckboxStation.Views;
using ReactiveUI;

namespace CheckboxStation
{
    public partial class InstrumentList : Form, IViewFor<InstrumentListViewModel>
    {
        private InstrumentListViewModel _vm;

        object IViewFor.ViewModel
        {
            get => _vm;
            set => _vm = (InstrumentListViewModel)value;
        }

        InstrumentListViewModel IViewFor<InstrumentListViewModel>.ViewModel
        {
            get => _vm;
            set => _vm = value;
        }
        
        public InstrumentList(OperationViewModel operation, CheckboxService checkboxService)
        {
            InitializeComponent();
            _vm = new InstrumentListViewModel(operation, checkboxService);

            this.OneWayBind(_vm, vm => vm.OperationViewModel, form => form.operationDataLabel.Text,
                operation => operation.OperationId);

            _vm.WhenAnyValue(vm => vm.GroupedInstruments).Subscribe(instruments =>
            {
                assetScanListView.Items.Clear();
                assetScanListView.Items.AddRange(ViewHelpers.ToPresentation(instruments));
            });
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
