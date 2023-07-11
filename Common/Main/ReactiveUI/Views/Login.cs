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
using Main.ReactiveUI.ViewModels;
using Main.Repositories.UnitOfWork;
using ReactiveUI;

namespace Main.ReactiveUI.Views
{
    public partial class Login : Form, IViewFor<LoginViewModel>
    {
        private LoginViewModel _vm;

        object IViewFor.ViewModel
        {
            get => _vm;
            set => _vm = (LoginViewModel)value;
        }

        LoginViewModel IViewFor<LoginViewModel>.ViewModel
        {
            get => _vm;
            set => _vm = value;
        }

        public Login(LoginViewModel vm)
        {
            _vm = vm;
            InitializeComponent();
            
            this.Bind(_vm, vm => vm.Username, v => v.TextBoxUserName.Text);
            this.Bind(_vm, vm => vm.Password, v => v.TextBoxPassword.Text);
            this.Bind(_vm, vm => vm.ShowError, v => v.LabelErrorMessage.Visible);
            this.BindCommand(_vm, vm => vm.Login, v => v.loginButton);
            this.BindCommand(_vm, vm => vm.Close, v => v.exitButton);
            // execute Login command on enter in textboxes
            TextBoxUserName.Events().KeyDown.Where(e => e.KeyCode == Keys.Enter).Select(_ => Unit.Default).InvokeCommand(_vm.Login);
            TextBoxPassword.Events().KeyDown.Where(e => e.KeyCode == Keys.Enter).Select(_ => Unit.Default).InvokeCommand(_vm.Login);

            TextBoxUserName.Events().KeyDown.Where(e => e.KeyCode == Keys.Enter).Subscribe(x => _vm.EnterPressed++);
            TextBoxPassword.Events().KeyDown.Where(e => e.KeyCode == Keys.Enter).Subscribe(x => _vm.EnterPressed++);

            this.WhenAnyValue(x => x._vm.ShowForm)
                .Where(x => !x)
                .Subscribe(_ => this.Close());

            this.Bind(_vm, vm => vm.UserNameHasFocus, 
                v => v.TextBoxUserName.Focused, TextBoxUserName.Events().LostFocus
                    .Merge(TextBoxUserName.Events().GotFocus));
            
        }
    }
}
