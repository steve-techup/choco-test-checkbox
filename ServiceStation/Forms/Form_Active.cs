using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using Caretag_Class;
using Caretag_Class.EventReporting;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Service_Station
{
    public partial class Form_Active : Form
    {
        private readonly EventReporter _eventReporter;
        // Const Not_allowedChars As String = ";:,-_/\*+!#¤%&()=?´}][{$£@½§*<>"

        private bool Should_Reboot;

        public Form_Active(string User_Name, int The_Seq_Code, EventReporter eventReporter, bool Reboot = true)
        {
            _eventReporter = eventReporter;
            // This call is required by the designer.
            InitializeComponent();
            try
            {
                LabelSecurity.Text = The_Seq_Code.ToString();
                TextBoxUserName.Text = User_Name;
                Function_Module.Program_User = User_Name;
                Should_Reboot = Reboot;
                ButtonExit.Select();
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while initializing the form", "An error occurred while initializing the form", "ServiceStation-33", true, true);
                Stop_Application();
            }

            _ButtonExit.Name = "ButtonExit";
        }

        private bool Do_Log(string The_Status)
        {
            bool Do_LogRet = default;
            var objConnection = new SqlConnection(Function_Module.SQL_ConnectionString);
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                string InsertSQL = "(Connect_ID,Log_Type,UserName, Log_Place)  VALUES('" + Function_Module.GlobalPersonID.ToString() + "','" + The_Status + "','" + Function_Module.Program_User + "','" + Function_Module.The_Reader_Name + "')";
                var com1 = objConnection.CreateCommand();
                com1.CommandType = CommandType.Text;
                com1.CommandText = "INSERT INTO LogIn_Table " + InsertSQL + ";";
                int results = com1.ExecuteNonQuery();
                // com1.CommandText = "SELECT SCOPE_IDENTITY();"
                // The_Log_ID = CInt(com1.ExecuteScalar)
                Do_LogRet = true;
            }
            catch (Exception ex)
            {
                Do_LogRet = false;
            }

            return Do_LogRet;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Do_Log("ActRefused");
            Close_DLL();
        }

        private bool Close_DLL()
        {
            if (Should_Reboot)
            {
                if (!My.MyProject.Computer.Keyboard.CtrlKeyDown)
                {
                    Caretag_Class.Caretag_Common.Functions.ExecuteShutdown("-s -t 00");
                }
                else
                {
                    Dispose();
                    Close();
                    Application.Exit();
                }
            }
            else
            {
                Dispose();
                Close();
                Application.Exit();
            }

            return default;
        }

        private string LookUpInDataBase_PARA(string Database_Name, string WhereString, string Field_Name)
        {
            string LookUpInDataBase_PARARet = default;
            var objConnection = new SqlConnection(Function_Module.SQL_ConnectionString);
            LookUpInDataBase_PARARet = "Not Found - An Issue !";
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                string The_Value = WhereString.Substring(WhereString.IndexOf("=") + 1);
                The_Value = The_Value.Replace("'", "");
                WhereString = WhereString.Substring(0, WhereString.IndexOf("=") + 1) + "@The_Parameter";
                var com1 = new SqlCommand("SELECT * FROM " + Database_Name + " WHERE " + WhereString + ";", objConnection);
                com1.Parameters.AddWithValue("@The_Parameter", The_Value);
                var reader = com1.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (Information.IsDBNull(reader[Field_Name]))
                        {
                            LookUpInDataBase_PARARet = "Not Found - An Issue !";
                        }
                        else
                        {
                            LookUpInDataBase_PARARet = reader[Field_Name].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LookUpInDataBase_PARARet = "Not Found - An Issue !" + Field_Name + Database_Name;
            }

            objConnection.Close();
            return LookUpInDataBase_PARARet;
        }

        private int WriteToDatabase_ParaM(string TableName, string InsertString, string[] Field_Array, string Count_ID, bool UseError = true, bool Use_Identity = false)
        {
            int WriteToDatabase_ParaMRet = default;
            var objConnection = new SqlConnection(Function_Module.SQL_ConnectionString);
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                if (Use_Identity)
                {
                    var command = new SqlCommand("INSERT INTO " + TableName + InsertString + "SELECT CAST(scope_identity() AS int);", objConnection);
                    int MaxArray = Information.UBound(Field_Array, 1);
                    for (int i = 0, loopTo = MaxArray; i <= loopTo; i++)
                        command.Parameters.AddWithValue("@Field_" + i.ToString(), Field_Array[i].ToString());
                    WriteToDatabase_ParaMRet = Conversions.ToInteger(command.ExecuteScalar());
                    if (WriteToDatabase_ParaMRet < 1)
                        throw new Exception("Insert Scope Failed:");
                }
                else
                {
                    var command = new SqlCommand("INSERT INTO " + TableName + InsertString + "SELECT COUNT(" + Count_ID.ToString() + ") FROM " + TableName + ";", objConnection);
                    int MaxArray = Information.UBound(Field_Array, 1);
                    for (int i = 0, loopTo1 = MaxArray; i <= loopTo1; i++)
                        command.Parameters.AddWithValue("@Field_" + i.ToString(), Field_Array[i].ToString());
                    WriteToDatabase_ParaMRet = Conversions.ToInteger(command.ExecuteScalar());
                    if (WriteToDatabase_ParaMRet < 1)
                        throw new Exception("Insert Count Failed:");
                }

                objConnection.Close();
                return WriteToDatabase_ParaMRet;
            }
            catch (Exception ex)
            {
                if (UseError)
                {
                    _eventReporter.ReportError(ex, "An error occurred while trying to write to the database", "An error occurred while trying to write to the database", "ServiceStation-34", true, true);
                    WriteToDatabase_ParaMRet = 0;
                }

                objConnection.Close();
            }

            return WriteToDatabase_ParaMRet;
        }

        private bool Stop_Application()
        {
            bool Stop_ApplicationRet = default;
            Stop_ApplicationRet = false;
            Application.DoEvents();
            Thread.Sleep(1000);
            Dispose();
            Close();
            Application.Exit();
            return Stop_ApplicationRet;
        }
    }
}