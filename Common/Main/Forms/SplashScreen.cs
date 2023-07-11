using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static System.String;

namespace Caretag_Class
{
    public partial class SplashScreen
    {
        public string Message
        {
            set {
                txtMsg.Invoke(() => txtMsg.Text = value);
                Refresh();
                Application.DoEvents();
            }
            
            
        }
        

        public SplashScreen(string stationID, string stationName)
        {
            InitializeComponent();
            HeaderTextBox.Text = $"Loading {stationName}";

            companyInfoLabel.Text = Application.CompanyName + " All Rights © " + DateAndTime.Now.Year;
            LabelVersion.Text = "Version: " + Application.ProductVersion;
            LabelID.Text = "Station ID: " + (IsNullOrEmpty(stationID) ? "-" : stationID);
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            Refresh();
            Application.DoEvents();
        }
        
    }
}