using System;
using System.Windows.Forms;
using CheckboxStation.ViewModels;
using DynamicData.Binding;
using ReactiveUI;

namespace CheckboxStation.Views
{
    public partial class NewOperationForm : Form, IViewFor<NewOperationViewModel>
    {
        private NewOperationViewModel _vm;
        object IViewFor.ViewModel
        {
            get => _vm;
            set => _vm = (NewOperationViewModel)value;
        }

        public NewOperationViewModel ViewModel
        {
            get => _vm;
            set => _vm = value;
        }

        public NewOperationForm()
        {
            InitializeComponent();
            _vm = new NewOperationViewModel();

            this.Bind(_vm, vm => vm.Id, form => form. operationIdTextBox.Text);
            this.Bind(_vm, vm => vm.ORName, form => form.operatingRoomTextbox.Text);

            this.BindCommand(_vm, vm => vm.Ok, form => form.okButton);
            this.BindCommand(_vm, vm => vm.Cancel, form => form.cancelButton);

            _vm.WhenValueChanged(vm => vm.ShowForm).Subscribe(showForm =>
            {
                if (!showForm)
                    Close();
            });
        }
    }
}
