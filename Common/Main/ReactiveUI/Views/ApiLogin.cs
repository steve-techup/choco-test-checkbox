using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caretag_Class;
using Caretag_Class.ReactiveUI.ViewModels;
using DevExpress.CodeParser;
using Main.ReactiveUI.ViewModels;
using Main.Repositories.UnitOfWork;
using ReactiveUI;


namespace Main.ReactiveUI.Views
{
    public partial class ApiLogin : Form, IViewFor<ApiLoginViewModel>
    {
        private ApiLoginViewModel _vm;

        object IViewFor.ViewModel
        {
            get => _vm;
            set => _vm = (ApiLoginViewModel)value;
        }

        ApiLoginViewModel IViewFor<ApiLoginViewModel>.ViewModel
        {
            get => _vm;
            set => _vm = value;
        }

        public ApiLoginViewModel ViewModel { get => _vm; }

        public ApiLogin(ApiLoginViewModel vm)
        {
            _vm = vm;
            InitializeComponent();
            this.Bind(_vm, vm => vm.Username, v => v.TextBoxUserName.Text);
            this.Bind(_vm, vm => vm.Password, v => v.TextBoxPassword.Text);
            this.Bind(_vm, vm => vm.ShowError, v => v.errorMessageLabel.Visible);
            this.BindCommand(_vm, vm => vm.Login, v => v.loginButton);
            this.BindCommand(_vm, vm => vm.Close, v => v.exitButton);

            TextBoxUserName.Events().KeyDown.Where(e => e.KeyCode == Keys.Enter).Select(_ => Unit.Default).InvokeCommand(_vm.Login);
            TextBoxPassword.Events().KeyDown.Where(e => e.KeyCode == Keys.Enter).Select(_ => Unit.Default).InvokeCommand(_vm.Login);

            this.WhenAnyValue(x => x._vm.ShowForm)
                .Where(x => !x)
                .Subscribe(_ => this.Close());

            this.Bind(_vm, vm => vm.UserNameHasFocus,
                v => v.TextBoxUserName.Focused, TextBoxUserName.Events().LostFocus
                    .Merge(TextBoxUserName.Events().GotFocus));
        }
    }
}
