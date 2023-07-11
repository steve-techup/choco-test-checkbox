using System;
using Microsoft.Extensions.DependencyInjection;
using Service_Station.CARETAG_Main;

namespace Service_Station
{
    public partial class Form_Exit
    {
        public Form_Exit()
        {
            InitializeComponent();
            _ButtonLogOut.Name = "ButtonLogOut";
            _ButtonShutDown.Name = "ButtonShutDown";
        }

        private void frm_Exit_Load(object sender, EventArgs e)
        {
            if (Caretag_Class.Function_Module.Program_User.Length > 0)
            {
                TextBoxUserName.Text = Caretag_Class.Function_Module.Program_User.ToString();
            }
            else
            {
                TextBoxUserName.Text = " --- ";
            }
        }

        private void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Program.Kernel.GetRequiredService<FrmMain>().NoCancel = true;
            Do_Log();
            Close();
        }

        private void ButtonShutDown_Click(object sender, EventArgs e)
        {
            Program.Kernel.GetRequiredService<FrmMain>().NoCancel = false;
            Do_Log();
            Close();
        }

        private bool Do_Log()
        {
            bool Do_LogRet = default;
            try
            {
                string InsertSQL = "(Connect_ID,Log_Type,UserName, Log_Place)  VALUES('" + Caretag_Class.Function_Module.GlobalPersonID + "','LogOUT','" + Caretag_Class.Function_Module.Program_User + "','" + Caretag_Class.Function_Module.The_Reader_Name + "')";
                int UpdatedNumber = Caretag_Class.SQLUtil.WriteToDatabase("LogIn_Table", InsertSQL, "Log_ID");
                if (Caretag_Class.Function_Module.GlobalPersonID > 0)
                {
                    string str_SQL = " Log_ID = NULL WHERE UserID ='" + Caretag_Class.Function_Module.GlobalPersonID + "';";
                    if (!Caretag_Class.SQLUtil.UpdateToDatabase("TblPassword", str_SQL))
                    {
                        throw new Exception("Update  TblPassword  Failed:");
                    }
                }

                Do_LogRet = true;            // Not used
            }
            catch (Exception ex)
            {
                // okay - strange
                Do_LogRet = false;
            }           // Not used

            return Do_LogRet;
        }
    }
}