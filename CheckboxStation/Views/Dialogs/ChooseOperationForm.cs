using System;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Forms;
using Caretag_Class.Model;
using CheckboxStation.ViewModels;
using DynamicData.Binding;
using ReactiveUI;

namespace CheckboxStation
{
    public partial class ChooseOperationForm : Form, IViewFor<CheckboxViewModel>
    {
        private CheckboxViewModel _vm;

        object IViewFor.ViewModel
        {
            get => _vm;
            set => _vm = (CheckboxViewModel)value;
        }

        CheckboxViewModel IViewFor<CheckboxViewModel>.ViewModel
        {
            get => _vm;
            set => _vm = value;
        }
        public ChooseOperationForm(CheckboxViewModel vm)
        {
            InitializeComponent();

            _vm = vm;

            _vm.WhenValueChanged(vm => vm.ShowOperationsForm).Subscribe(showForm =>
            {
                if (!showForm)
                    Close();
            });

            this.Bind(_vm, vm => vm.SelectedOperation, form => form.operationComboBox.SelectedItem, Observable.FromEventPattern(operationComboBox, "SelectedIndexChanged"));
            this.BindCommand(vm, vm => vm.OnOperationSelected, form => form.okButton);
            vm.Operations.Where(o => o.State != OperationState.FINISHED.ToString()).ToList().ForEach(operation =>
                    {
                        operationComboBox.Items.Add(operation);
                    });

            operationComboBox.SelectedIndex = operationComboBox.Items.Count > 0 ? 0 : -1;
        }
    }
}
