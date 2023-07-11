using Caretag_Class.Extensions;
using Caretag_Class.Forms;
using Main.ReactiveUI.ViewModels;
using Main.ReactiveUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Services
{
    public class LoginService
    {
        private readonly ApiLoginViewModel _apiLoginViewModel;
        private readonly ApiLogin _loginForm;

        public LoginService(ApiLoginViewModel apiLoginViewModel, ApiLogin loginForm)
        {
            _apiLoginViewModel = apiLoginViewModel;
            _loginForm = loginForm;
        }
        public bool Login()
        {
            _loginForm.ShowDialog();

            return _loginForm.ViewModel.IsLoggedIn;
        }
    }
}
