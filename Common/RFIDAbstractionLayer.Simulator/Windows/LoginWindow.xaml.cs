using System;
using System.Windows;
using System.Windows.Input;

namespace RFIDAbstractionLayer.Simulator
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        public bool Execute(ref string username, ref string password, ref string apiUrl)
        {
            userNameBox.Text = username;
            passwordBox.Password = password;
            apiUrlBox.Text = apiUrl;
            bool dialogResult = (bool)this.ShowDialog();
            if (dialogResult)
            {
                username = userNameBox.Text;
                password = passwordBox.Password;
                apiUrl = apiUrlBox.Text;
            }

            return dialogResult;
        }
        /*
        public bool Execute(ref SimulatorAppSettings settings)
        {
            string user = settings.UserName;
            string pass = settings.Password;
            string url = settings.ApiURL;

            var result = Execute(ref user, ref pass, ref url);

            settings.UserName = user;
            settings.Password = pass;
            settings.ApiURL = url;

            return result;
        }*/

        private void userNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ConfirmSelection();
            }
        }

        private void ConfirmSelection()
        {
            if (userNameBox.Text.Length == 0)
            {
                userNameBox.Focus();
                return;
            }

            if (passwordBox.Password.Length == 0)
            {
                passwordBox.Focus();
                return;
            }

            if (apiUrlBox.Text.Length == 0)
            {
                apiUrlBox.Focus();
                return;
            }

            this.DialogResult = true;
        }

        private void passwordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ConfirmSelection();
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            ConfirmSelection();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void apiUrlBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ConfirmSelection();
            }
        }
        
        private void btnDefaults_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show(App.Translate("LoadDefaultsMsg"), 
                                App.Translate("LoadDefaultsTitle"), 
                                MessageBoxButton.YesNo, 
                                MessageBoxImage.Warning) == MessageBoxResult.No)
                return;

          /*  var defaults = App.GetDefaultSettings();
            userNameBox.Text = defaults.UserName;
            passwordBox.Password = defaults.Password;
            apiUrlBox.Text = defaults.ApiURL;
          */
            userNameBox.Focus();
        }
        
        private void Window_Activated(object sender, EventArgs e)
        {
            userNameBox.Focus();
        }
    }
}
