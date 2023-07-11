using System;
using System.Data.SqlClient;

namespace Service_Station
{
    public partial class SystemInfo
    {
        public SystemInfo()
        {
            InitializeComponent();
            _TopTitle.Name = "TopTitle";
        }
        // Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        // Dim csSection As ConnectionStringsSection = config.ConnectionStrings
        // Dim cs As ConnectionStringSettings = csSection.ConnectionStrings(configline) ' Bemærk nr på connection statement i config file
        // Dim str_ConnectionString As String = cs.ConnectionString
        private SqlConnection objConnection = new SqlConnection(Caretag_Class.Function_Module.SQL_ConnectionString);

        public static void Main()
        {
        }

        private void SystemInfo_Load(object sender, EventArgs e)
        {
            OSSystem.Text = string.Format("{0} - {1} - {2}", Environment.OSVersion.Platform, Environment.OSVersion.Version.Major, Environment.Version.ToString());
            UserName.Text = Environment.UserName;
            LatestVersion.Text = "Latest Version - OK";
            MachineName.Text = Environment.MachineName;
            SystemFolder.Text = Environment.SystemDirectory;
            TextBoxLanguage.Text = Caretag_Class.Function_Module.Language_Choosen;
            objConnection.Open();
            State.Text = objConnection.State.ToString();
            DataBase.Text = objConnection.Database.ToString();
            // Me.DriverText.Text = objConnection.Driver.ToString
            ServerVersion.Text = objConnection.ServerVersion.ToString();
            objConnection.Close();
        }

        private void TopTitle_Click(object sender, EventArgs e)
        {
            bool Choose_Dir = false;
            if (My.MyProject.Computer.Keyboard.CtrlKeyDown)
            {
                Choose_Dir = true;
            }

            Caretag_Class.Caretag_Common.Functions.ScreenDump(Handle, Choose_Dir);
        }
    }
}