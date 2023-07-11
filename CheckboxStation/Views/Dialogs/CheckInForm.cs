using System;
using System.Reactive.Linq;
using System.Windows.Forms;
using CheckboxStation.ViewModels;
using DynamicData.Binding;
using ReactiveUI;

namespace CheckboxStation
{
    public partial class CheckInForm : Form, IViewFor<CheckInViewModel>
    {
        private CheckInViewModel _vm;

        object IViewFor.ViewModel
        {
            get => _vm;
            set => _vm = (CheckInViewModel)value;
        }

        CheckInViewModel IViewFor<CheckInViewModel>.ViewModel
        {
            get => _vm;
            set => _vm = value;
        }
        public CheckInForm(CheckInViewModel vm)
        {
            InitializeComponent();

            _vm = vm;

            this.OneWayBind(_vm, vm => vm.Status, form => form.statusLabel.Text);
            this.OneWayBind(_vm, vm => vm.StatusColor, form => form.statusLabel.ForeColor);
            
            _vm.WhenValueChanged(vm => vm.ShowForm).Subscribe(showForm =>
            {
                if (!showForm)
                    Close();
            });

            this.Bind(_vm, vm => vm.SelectedOperation, form => form.operationComboBox.SelectedItem, Observable.FromEventPattern(operationComboBox, "SelectedIndexChanged"));
            this.BindCommand(vm, vm => vm.Ok, form => form.okButton);
            this.BindCommand(vm, vm => vm.Cancel, form => form.cancelButton);
            vm.Operations.Subscribe(list =>
                    list.ForEach(operation =>
                    {
                        operationComboBox.Items.Add(operation);
                    })
            );
        }
    }
}
