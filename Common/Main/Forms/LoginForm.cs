using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
using Caretag_Class.Model;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using RFIDAbstractionLayer;
using RFIDAbstractionLayer.Readers;

namespace Caretag_Class.Forms
{
    public partial class LoginForm
    {   private int _contStop;
        private readonly bool FirstLogin = false;
        private bool _stopReader;
        private bool _noUsers;
        private readonly DataTable Check_tbl = new();

        // *****************************************************************************************************************************
        public static string SQL_ConnectionString = "";
        // ****************************************************************************************************************************
        private RFIDReaderCollection ReaderCollection;
        
        public event LogInfoEventHandler LogInfo;

        public delegate void LogInfoEventHandler(string Testdata);

        private ResourceManager Local_RM = new ResourceManager("Caretag_Login.WinFormStrings", typeof(LoginForm).Assembly);
        private string The_Reader_Name;
        private string DeskTop_Reader;
        private string Program_User;
        private int GlobalPersonID;
        private int Programs_Security_Level;
        private int The_Log_ID;

        public int LoggedInUserId { get; set; }

        public LoginForm(bool NoCancel, string DataSource, string ReaderName, short The_Seq_Code, string Info_String, string The_UI_Language = "en-US", string Transl_Name_Reader = "") : this(null, NoCancel, DataSource, ReaderName, The_Seq_Code, Info_String, The_UI_Language, Transl_Name_Reader)
        {
        }

        public LoginForm(RFIDReaderCollection rfidReaderCollection, bool NoCancel, string DataSource, string ReaderName, short The_Seq_Code, string Info_String, string The_UI_Language = "en-US", string Transl_Name_Reader = "")
        {
            InitializeComponent();
            if (Information.IsNothing(The_UI_Language) || The_UI_Language.Trim().Length < 1)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(The_UI_Language);
            }

            ReaderCollection = rfidReaderCollection;

            // This call is required by the designer.
            Frm_Login_Load(DataSource, ReaderName, Transl_Name_Reader);
            _TextBoxPassword.Name = "TextBoxPassword";
            _TextBoxUserName.Name = "TextBoxUserName";
            _ButtonLogin.Name = "ButtonLogin";
            _BtnExit.Name = "ButtonCancel";
            _PictureBox1.Name = "PictureBox1";
        }

        private void Frm_Login_Load(string DataSource, string ReaderName, string Transl_Name_Reader)
        {
            try
            {
                SQL_ConnectionString = DataSource;
                The_Reader_Name = ReaderName;

                if (Transl_Name_Reader.Trim().Length < 1)
                {
                    var lastChar = (short)ReaderName.LastIndexOf("_", StringComparison.Ordinal);
                    if (lastChar > 0)
                    {
                        DeskTop_Reader = ReaderName.Substring(0, lastChar);
                    }
                }
                else
                {
                    DeskTop_Reader = Transl_Name_Reader;
                }
                
                
                bool argUse_ActiveD = false;
                bool argUse_Login = true;
                Check_Login_Verif();
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error while initializing login form. ", "Unexpected error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Stop_Application();
            }

            TextBoxPgrName.Text = ReaderName;
            Load_User_Table();
            if (_noUsers)
            {
                // First Time make sure that ONE user Exist = Admin  Also Done in Admin First Time Setup
                var userGuid = Guid.NewGuid();
                var Field_Array = new string[] { "AdminUser", "Caretag", "Admin", userGuid.ToString(), "0", "9" };
                string str_SQL_Write = "(FirstName, FamilyName,UserName,UserGuid,DashBoard, SecurityLevel) " + "VALUES (@Field_0,@Field_1,@Field_2,@Field_3,@Field_4,@Field_5)";
                int test = WriteToDatabase_ParaM("TblPassword", str_SQL_Write, Field_Array, "UserID", true, true);

                // ....Just close the program .... and then start from a fresh
                
                Do_Log("Cancel");
                Stop_Application();
            }

            BackgroundWorker1.RunWorkerAsync();
        }

        #region Reader Stuff


        private void BackgroundWorker1_progress(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage > 0)
            {
                Label_Message.Visible = true;
            }
            else
            {
                Label_Message.Visible = false;
            }
        }

        private void BackgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (ReaderCollection != null)
            {
                Read_Card();
            }
            else
            {
                Label_Message.Visible = false;
                Cancel_Reader_Reading();
            }
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (!_stopReader)
            {
                ButtonLogin.BackColor = Color.LightGreen;
                TextBoxUserName.Text = Program_User;
                if (this.DoLogin_Procedure(Program_User).Trim().Length < 1)
                {
                    BackgroundWorker1.RunWorkerAsync();
                    return;
                }

                Do_Log(What_LogIN_Type());
                Application.DoEvents();
                Thread.Sleep(1000);
                LogInfo?.Invoke(Program_User);
                Dispose();
                Close();
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                _stopReader = false;
                Load_User_Table();
                BackgroundWorker1.RunWorkerAsync();
            }
            catch (Exception ex)
            {
            }
        }

        private bool Read_Card()
        {
            _contStop = 1;
            var readCardRet = true;
            while (_contStop == 1)
            {
                try
                {
                    var tags = ReaderCollection.ReadTags();

                    foreach (var tag in tags)
                    {
                        if (tag.Value == "") continue;
                        try
                        {
                            if (Check_UserCard(tag))
                            {
                                _contStop = 0;
                            }
                        }
                        catch (Exception e)
                        {
                            break;
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    readCardRet = false;
                }

                Application.DoEvents();
            } // Fine While ContStop

            return readCardRet;
        }
        private bool Check_UserCard(ReadingResult tag)
        {
            bool checkUserCardRet;
            try
            {
                checkUserCardRet = false;
                foreach (DataRow row in Check_tbl.Rows)
                {
                    if (Information.IsNothing(row["UserID"]))
                        break;
                    if ((row["RFID"].ToString() ?? "") == (tag.Value ?? ""))
                    {
                        Program_User = row["UserName"].ToString();
                        GlobalPersonID = Conversions.ToInteger(row["UserID"]);
                        if (Conversions.ToInteger(row["SecurityLevel"]) >= Programs_Security_Level)
                        {
                            checkUserCardRet = true;
                            BackgroundWorker1.ReportProgress(0);
                            break;
                        }
                        else
                        {
                            BackgroundWorker1.ReportProgress(1);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                checkUserCardRet = false;
            }

            return checkUserCardRet;
        }

        private void Cancel_Reader_Reading()
        {
            if (_stopReader) return;
            try
            {
                BackgroundWorker1.CancelAsync();
                BackgroundWorker1.Dispose();
                _stopReader = true;
                _contStop = 0;
            }
            catch (Exception)
            {
            }
        }
        #endregion

        private void Load_User_Table()
        {
            try
            {
                FillDataInTable("SELECT * FROM TblPassword");
                Check_tbl.Columns.Add("RFID", Type.GetType("System.String"));
                Check_tbl.Columns.Add("SEQ", Type.GetType("System.String"));
                string Pass_Encrypt = "";
                if (Check_tbl.Rows.Count == 0)
                {
                    _noUsers = true;
                    return;
                }

                foreach (DataRow row in Check_tbl.Rows)
                {
                    if (Information.IsNothing(row["UserID"]))
                        break;
                    if (!Information.IsDBNull(row["RFID_Code"]))
                    {
                        Pass_Encrypt = row["RFID_Code"].ToString();

                        row["RFID"] = Pass_Encrypt;
                    }
                    else
                    {
                        row["RFID"] = "0";
                    }

                    if (!Information.IsDBNull(row["SEQ_Code"]))
                    {
                        Pass_Encrypt = row["SEQ_Code"].ToString();
                        row["SEQ"] = PasswordEncryptionUtil.Decrypt(Pass_Encrypt);
                    }
                    else
                    {
                        row["SEQ"] = "0";
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string userGuid = LookUpInDataBase_PARA("TblPassword", " UserName ='" + TextBoxUserName.Text + "'", "UserGuid");
                string password = LookUpInDataBase_PARA("TblPassword", " UserName ='" + TextBoxUserName.Text + "'", "PassCode");

                Program_User = TextBoxUserName.Text;
                string Pass_Encrypt = PasswordEncryptionUtil.EncryptWithGuid(TextBoxPassword.Text, userGuid);
                if ((password ?? "") == (Pass_Encrypt ?? ""))
                {
                    Program_User = TextBoxUserName.Text;
                    DoLogin_Procedure(TextBoxUserName.Text);
                    Do_Log(What_LogIN_Type());
                    LogInfo?.Invoke(Program_User);

                    //TODO SPEED SPEED SPEED!!!!!!
                    using var dbContext = new CaretagModel(SQL_ConnectionString);
                    LoggedInUserId = dbContext.TblPassword.First(x => x.UserName == Program_User).UserID;
                    Close();
                }
                else
                {
                    Label_Message.Visible = true;
                    TextBoxUserName.Text = "";
                    TextBoxPassword.Text = "";
                    TextBoxUserName.Focus(); 

                    return;
                }

                if (CheckSecurity_Procedure(TextBoxUserName.Text, 0.ToString()) < Programs_Security_Level)
                {
                    Label_Message.Visible = true;
                    TextBoxUserName.Text = "";
                    TextBoxPassword.Text = "";
                    TextBoxUserName.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Quit?", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
                return;

            Stop_Application();
            
        }


        #region Procedure

        private string DoLogin_Procedure(string Value1)
        {
            string DoLogin_ProcedureRet = default;
            if (Value1.Length < 1)
                return DoLogin_ProcedureRet;
            var objConnection = new SqlConnection(SQL_ConnectionString);
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                using (objConnection)
                {
                    var sqlComm = new SqlCommand();
                    sqlComm.Connection = objConnection;
                    sqlComm.CommandText = "DoLogin";
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@username", Value1);
                    DoLogin_ProcedureRet = Conversions.ToString(sqlComm.ExecuteScalar());
                }

                GlobalPersonID = Conversions.ToInteger(LookUpInDataBase("TblPassword", " UserName ='" + Value1 + "'", "UserID"));
            }


            catch (Exception ex)
            {
                DoLogin_ProcedureRet = "";
            }

            objConnection.Close();
            return DoLogin_ProcedureRet;
        }

        private string ChangePassW_Procedure(string Value1, string Value2)
        {
            string ChangePassW_ProcedureRet = default;
            var objConnection = new SqlConnection(SQL_ConnectionString);
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                using (objConnection)
                {
                    var sqlComm = new SqlCommand();
                    sqlComm.Connection = objConnection;
                    sqlComm.CommandText = "ChangePassword";
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@UserName", Value1);
                    sqlComm.Parameters.AddWithValue("@PassCode", Value2);
                    ChangePassW_ProcedureRet = Conversions.ToString(sqlComm.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                ChangePassW_ProcedureRet = "";
            }

            objConnection.Close();
            return ChangePassW_ProcedureRet;
        }

        private string CheckUser_Procedure(string Value1, string Value2)
        {
            string CheckUser_ProcedureRet = default;
            var objConnection = new SqlConnection(SQL_ConnectionString);
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                using (objConnection)
                {
                    var sqlComm = new SqlCommand();
                    sqlComm.Connection = objConnection;
                    sqlComm.CommandText = "CheckUser";
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@username", Value1);
                    sqlComm.Parameters.AddWithValue("@password", Value2);
                    CheckUser_ProcedureRet = Conversions.ToString(sqlComm.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                // First Time No Password OKAY
                CheckUser_ProcedureRet = "";
            }

            objConnection.Close();
            return CheckUser_ProcedureRet;
        }

        private short CheckSecurity_Procedure(string Value1, string Value2)
        {
            short CheckSecurity_ProcedureRet = default;
            var objConnection = new SqlConnection(SQL_ConnectionString);
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                using (objConnection)
                {
                    var sqlComm = new SqlCommand();
                    sqlComm.Connection = objConnection;
                    sqlComm.CommandText = "CheckSecurity";
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@UserName", Value1);
                    sqlComm.Parameters.AddWithValue("@Security", Value2);
                    CheckSecurity_ProcedureRet = Conversions.ToShort(sqlComm.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                CheckSecurity_ProcedureRet = 0;
            }

            objConnection.Close();
            return CheckSecurity_ProcedureRet;
        }

        private string What_LogIN_Type()
        {
            string What_LogIN_TypeRet = default;
            try
            {
                // Dim Is_LogIN As String = LookUpInDataBase("TblPassword", " UserName ='" & The_User_Name & "'", "Log_ID")
                string Is_LogIN = LookUpInDataBase("TblPassword", "  UserID ='" + GlobalPersonID + "'", "Log_ID");
                int number = 0;
                bool results = int.TryParse(Is_LogIN, out number);
                if (results)
                {
                    What_LogIN_TypeRet = "FORCE";
                }
                else
                {
                    What_LogIN_TypeRet = "LogIN";
                }
            }
            catch (Exception ex)
            {
                What_LogIN_TypeRet = "Error";
            }

            return What_LogIN_TypeRet;
        }

        protected bool Do_Log(string The_Status)
        {
            bool Do_LogRet = default;
            var objConnection = new SqlConnection(SQL_ConnectionString);
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                string InsertSQL = "(Connect_ID,Log_Type,UserName, Log_Place)  VALUES('" + GlobalPersonID.ToString() + "','" + The_Status + "','" + Program_User + "','" + The_Reader_Name + "')";
                var com1 = objConnection.CreateCommand();
                com1.CommandType = CommandType.Text;
                com1.CommandText = "INSERT INTO LogIn_Table " + InsertSQL + ";";
                int results = com1.ExecuteNonQuery();
                com1.CommandText = "SELECT SCOPE_IDENTITY();";
                The_Log_ID = Conversions.ToInteger(com1.ExecuteScalar());

                // com1.CommandText = "UPDATE LogIn_Table SET Connect_ID='" & The_Log_ID & "' WHERE Log_ID ='" & The_Log_ID & "';"
                // results = com1.ExecuteNonQuery

                com1.CommandText = "UPDATE TblPassword SET Log_ID='" + The_Log_ID + "' WHERE UserName ='" + Program_User + "';";
                results = com1.ExecuteNonQuery();
                Application.DoEvents();
                Do_LogRet = true;
            }
            catch (Exception ex)
            {
                Do_LogRet = false;
            }

            return Do_LogRet;
        }

        #endregion


        #region  TextBox Handling


        private void TextBoxUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Label_Message.Visible = false;
            Cancel_Reader_Reading();
            if (e.KeyChar == (char)Keys.Return)
                ButtonLogin_Click(sender, e);
        }

        private void TextBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxPassword.BackColor = Color.White;
            Label_Message.Visible = false;
            if (e.KeyChar == (char)Keys.Return)
                ButtonLogin_Click(sender, e);
        }

        private void TextBoxPassword_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (TextBoxPassword.Text.Length < 6 & FirstLogin & TextBoxPassword.Text.Length > 0)
                {
                    TextBoxPassword.Text = "";
                    TextBoxPassword.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        private void FillDataInTable(string selectCommand)
        {
            try
            {
                var objDataAdapter = new SqlDataAdapter(selectCommand, SQL_ConnectionString);
                Check_tbl.Reset();
                objDataAdapter.Fill(Check_tbl);
            }
            catch (Exception ex)
            {
                // ignored
            }
        }

        private int WriteToDatabase_ParaM(string tableName, string insertString, string[] fieldArray, string countId, bool useError = true, bool useIdentity = false)
        {
            int WriteToDatabase_ParaMRet = default;
            var objConnection = new SqlConnection(SQL_ConnectionString);
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                if (useIdentity)
                {
                    var command = new SqlCommand("INSERT INTO " + tableName + insertString + "SELECT CAST(scope_identity() AS int);", objConnection);
                    int MaxArray = Information.UBound(fieldArray, 1);
                    for (int i = 0, loopTo = MaxArray; i <= loopTo; i++)
                        command.Parameters.AddWithValue("@Field_" + i, fieldArray[i]);
                    WriteToDatabase_ParaMRet = Conversions.ToInteger(command.ExecuteScalar());
                    if (WriteToDatabase_ParaMRet < 1)
                        throw new Exception("Insert Scope Failed:");
                }
                else
                {
                    var command = new SqlCommand("INSERT INTO " + tableName + insertString + "SELECT COUNT(" + countId + ") FROM " + tableName + ";", objConnection);
                    int MaxArray = Information.UBound(fieldArray, 1);
                    for (int i = 0, loopTo1 = MaxArray; i <= loopTo1; i++)
                        command.Parameters.AddWithValue("@Field_" + i, fieldArray[i]);
                    WriteToDatabase_ParaMRet = Conversions.ToInteger(command.ExecuteScalar());
                    if (WriteToDatabase_ParaMRet < 1)
                        throw new Exception("Insert Count Failed:");
                }

                objConnection.Close();
            }
            catch (Exception ex)
            {
                if (useError)
                {
                    MessageBox.Show(Local_RM.GetString("Problem in database ... Check server ") + Constants.vbCrLf + Constants.vbCrLf + ex.Message, "WriteToDatabase_ParaM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    WriteToDatabase_ParaMRet = 0;
                }

                objConnection.Close();
            }

            return WriteToDatabase_ParaMRet;
        }

        public static bool UpdateToDatabase(string TableName, string InsertString, bool Show_Error = true)
        {
            bool updateToDatabaseRet;
            var objConnection = new SqlConnection(SQL_ConnectionString);
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                using (var com1 = objConnection.CreateCommand())
                {
                    com1.CommandType = CommandType.Text;
                    com1.CommandText = "UPDATE " + TableName + " SET " + InsertString + ";";
                    int results = com1.ExecuteNonQuery();
                    if (results < 1 & Show_Error)
                        throw new Exception("Update Failed:");
                    updateToDatabaseRet = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem in database ... Check server " + Constants.vbCrLf + Constants.vbCrLf + ex.Message, "UpdateToDatabase", MessageBoxButtons.OK, MessageBoxIcon.Error);
                updateToDatabaseRet = false;
            }

            objConnection.Close();
            return updateToDatabaseRet;
        }

        private string LookUpInDataBase(string databaseName, string whereString, string fieldName)
        {
            var objConnection = new SqlConnection(SQL_ConnectionString);
            var LookUpInDataBaseRet = "";
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                var com1 = objConnection.CreateCommand();
                com1.CommandType = CommandType.Text;
                com1.CommandText = "SELECT * FROM " + databaseName + " WHERE " + whereString + ";";
                var reader = com1.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (Information.IsDBNull(reader[fieldName]))
                        {
                            LookUpInDataBaseRet = "";
                        }
                        else
                        {
                            LookUpInDataBaseRet = reader[fieldName].ToString();
                        }
                    }
                }
            }
            catch (Exception)
            {
                LookUpInDataBaseRet = "Not Found - An Issue !" + fieldName + databaseName;
            }

            objConnection.Close();
            return LookUpInDataBaseRet;
        }

        private string LookUpInDataBase_PARA(string Database_Name, string WhereString, string Field_Name)
        {
            var objConnection = new SqlConnection(SQL_ConnectionString);
            var lookUpInDataBaseParaRet = "Not Found - An Issue !";
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
                        lookUpInDataBaseParaRet = Information.IsDBNull(reader[Field_Name]) ? "Not Found - An Issue !" : reader[Field_Name].ToString();
                    }
                }
            }
            catch (Exception)
            {
                lookUpInDataBaseParaRet = "Not Found - An Issue !" + Field_Name + Database_Name;
            }

            objConnection.Close();
            return lookUpInDataBaseParaRet;
        }
        

        private bool Check_Login_Verif()
        {
            bool checkLoginVerifRet;
            checkLoginVerifRet = true;
            try
            {
                string To_Check = LookUpInDataBase("SystemInfo", " ID > 0", "Login_Verification");
                if (To_Check.Length != 11)
                {
                    throw new Exception("The Login Verification is Altered ! ");
                }
                
                string Using_Login = To_Check.Substring(2, 1);
                string Check_Ciffer = To_Check.Substring(5, 1);
                string Using_ActiveD = To_Check.Substring(9, 1);
                string Part_4 = To_Check.Substring(10, 1);
                if (Check_Ciffer != Part_4)
                {
                    throw new Exception(Local_RM.GetString("The Login Verification is Altered !"));
                }

                string To_Check_Active = LookUpInDataBase("SystemInfo", " ID > 0", "Use_ActiveDirectory");
                if (To_Check_Active == "False" & Conversions.ToDouble(Using_ActiveD) == 1d)
                {
                    throw new Exception(Local_RM.GetString("The Login Verification is Altered !"));
                }

                if (To_Check_Active == "True" & Conversions.ToDouble(Using_ActiveD) == 0d)
                {
                    throw new Exception(Local_RM.GetString("The Login Verification is Altered !"));
                }

                To_Check_Active = LookUpInDataBase("SystemInfo", " ID > 0", "Use_Login");
                if (To_Check_Active == "False" & Using_Login == "1")
                {
                    throw new Exception(Local_RM.GetString("The Login Verification is Altered !"));
                }

                if (To_Check_Active == "True" & Using_Login == "0")
                {
                    throw new Exception(Local_RM.GetString("The Login Verification is Altered !"));
                }
            }
            catch (Exception)
            {
                Label_Message.Text = Local_RM.GetString("The Login Verification is Altered !");
                Label_Message.Visible = true;
                checkLoginVerifRet = false;
                Stop_Application();
            }

            return checkLoginVerifRet;
        }
        
        private void Stop_Application()
        {
            Application.DoEvents();
            Thread.Sleep(100);
            Dispose();
            Cancel_Reader_Reading();
            Close();
            Application.Exit();
            Thread.Sleep(100);
            Environment.Exit(0);
        }

    }
}