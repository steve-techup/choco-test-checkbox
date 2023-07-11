using System;
using System.Linq;
using System.Windows.Forms;
using CheckboxStation.ViewModels;
using DynamicData.Binding;
using Main.Extensions;
using OnScreenKeyboard;
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

            foreach (var control in ControlExtensions.GetAllControlsRecusrvive<TextBox>(this).Where(c => !c.ReadOnly))
            {
                OskUiController.Instance.AddControl(control);
            }
        }

        private void NewOperationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (OSK.Instance.IsRunning)
                OSK.Instance.HideKeyboard();
        }

        private void NewOperationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var control in ControlExtensions.GetAllControlsRecusrvive<TextBox>(this).Where(c => !c.ReadOnly))
            {
                OskUiController.Instance.DeleteControl(control);
            }
        }
    }
}
