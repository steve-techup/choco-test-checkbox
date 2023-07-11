using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Caretag_Class.Caretag_Common;
using UIControls;
using UIControls.WinForms;

namespace Caretag_Class
{
    public class SQLUtil
    {
        /// <summary>
    ///     Usage :
    ///     <para>&#160;Please Use The PARAMETER VERSION </para>
    ///     <para>
    ///         &#160;ReadyComboBox(ComboBox_CostCenter, " Cost_Center_Name,Index_ID", " Cost_Center ", " WHERE
    ///         Hidden_Center='False' ORDER BY Cost_Center_Name ", " Must Choose")
    ///     </para>
    /// </summary>
    /// <param name="cbrSelection"></param>
    /// <param name="Selection_Str"></param>
    /// <param name="Name_Data_Table"></param>
    /// <param name="str_Filter"></param>
    /// <param name="All_Names"></param>
    /// <param name="All_Fields"></param>
    /// <param name="DropDown"></param>
    /// <returns></returns>
        public static bool ReadyComboBox(ComboBox cbrSelection, string Selection_Str, string Name_Data_Table, string str_Filter = "", string All_Names = "", bool All_Fields = false, bool DropDown = true)
        {
            bool ReadyComboBoxRet = default;
            try
            {
                string str_query = "SELECT " + Selection_Str + " FROM " + Name_Data_Table + str_Filter;
                using (var objDataAdapter = new SqlDataAdapter(str_query, Function_Module.SQL_ConnectionString))
                {
                    var ds = new DataSet();
                    objDataAdapter.Fill(ds, "ComboDataSet");                                     // Populate the DataTable
                    if (All_Names.Length > 0)
                    {
                        var dr = ds.Tables["ComboDataSet"].NewRow();
                        dr[0] = 0;
                        dr[1] = All_Names.ToString();
                        ds.Tables["ComboDataSet"].Rows.InsertAt(dr, 0);
                    }

                    if (All_Fields)
                    {
                        int i = 0;
                        foreach (DataRow row in ds.Tables["ComboDataSet"].Rows) // Always use one as the main index
                        {
                            ds.Tables["ComboDataSet"].Rows[i][1] = ds.Tables["ComboDataSet"].Rows[i][2] + " " + ds.Tables["ComboDataSet"].Rows[i][3] + " " + ds.Tables["ComboDataSet"].Rows[i][4];
                            i += 1;
                        }
                    }

                    cbrSelection.DataSource = ds.Tables["ComboDataSet"];
                    cbrSelection.ValueMember = ds.Tables["ComboDataSet"].Rows[0].Table.Columns[0].ToString();
                    cbrSelection.DisplayMember = ds.Tables["ComboDataSet"].Rows[0].Table.Columns[1].ToString();
                }
            }
            catch (Exception ex)
            {
                ReadyComboBoxRet = false;
                return default;
            }

            if (DropDown)
            {
                cbrSelection.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            // Clean up
            // objConnection.Dispose()
            ReadyComboBoxRet = true;
            return ReadyComboBoxRet;
        }
        
        /// <summary>
    ///     Usage :
    ///     <para>&#160;str_Select = TextBox_Proc_Filt.Text.Trim </para>
    ///     <para>
    ///         &#160;ReadyComboBox_ParaM(ComboBox_Procedure, str_Select, "OR_Procedure", "Procedure_Name LIKE ",
    ///         WhereString, " ORDER BY Procedure_Name ")
    ///     </para>
    /// </summary>
    /// <param name="cbrSelection"></param>
    /// <param name="Selection_Str"></param>
    /// <param name="Name_Data_Table"></param>
    /// <param name="Col_Name"></param>
    /// <param name="WhereString"></param>
    /// <param name="ExtraText"></param>
    /// <param name="All_Names"></param>
    /// <returns></returns>
        public static bool ReadyComboBox_ParaM(ComboBox cbrSelection, string Selection_Str, string Name_Data_Table, string Col_Name, string WhereString, string ExtraText = "", string All_Names = "")
        {
            bool ReadyComboBox_ParaMRet = default;
            var objConnection = new SqlConnection(Function_Module.SQL_ConnectionString);
            try
            {
                string str_query = "SELECT " + Selection_Str + " FROM " + Name_Data_Table + "  WHERE " + Col_Name + " @WhereString " + ExtraText;
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                var cmd = new SqlCommand(str_query, objConnection);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = str_query;
                cmd.Parameters.Add("@WhereString", SqlDbType.NVarChar);
                cmd.Parameters["@WhereString"].Value = WhereString + "%";
                using (var objDataAdapter = new SqlDataAdapter(cmd))
                {
                    var ds = new DataSet();
                    objDataAdapter.Fill(ds, "ComboDataSet");                                     // Populate the DataTable
                    if (All_Names.Length > 0)
                    {
                        var dr = ds.Tables["ComboDataSet"].NewRow();
                        dr[0] = All_Names.ToString();
                        ds.Tables["ComboDataSet"].Rows.InsertAt(dr, 0);
                    }

                    cbrSelection.DataSource = ds.Tables["ComboDataSet"];
                    cbrSelection.ValueMember = ds.Tables["ComboDataSet"].Rows[0].Table.Columns[0].ToString();
                    cbrSelection.DisplayMember = ds.Tables["ComboDataSet"].Rows[0].Table.Columns[0].ToString();
                    ReadyComboBox_ParaMRet = true;
                }
            }
            catch (Exception ex)
            {
                ReadyComboBox_ParaMRet = false;
            }

            cbrSelection.DropDownStyle = ComboBoxStyle.DropDownList;

            // Clean up
            objConnection.Dispose();
            objConnection = null;
            return ReadyComboBox_ParaMRet;
        }

        /// <summary>
    ///     Usage :
    ///     <para>&#160;  </para>
    /// </summary>
    /// <param name="The_EPC"></param>
    /// <param name="Which_Type"></param>
    /// <returns></returns>
        public static bool Check_Tag_Databases(string The_EPC, int Which_Type)
        {
            bool Check_Tag_DatabasesRet = default;
            string existing = "";
            try
            {
                if (Which_Type != 1)
                {
                    existing = LookUp_One_Field("Instrument_RFID", " EPC_Nr='" + The_EPC + "'", "Instrument_ID");
                    if (existing != "0" & existing.Length > 0)
                    {
                        Check_Tag_DatabasesRet = true;
                        return Check_Tag_DatabasesRet;
                    }
                }

                if (Which_Type != 2)
                {
                    existing = LookUp_One_Field("Cart_RFID", " EPC_Nr='" + The_EPC + "'", "Cart_ID");
                    if (existing != "0" & existing.Length > 0)
                    {
                        Check_Tag_DatabasesRet = true;
                        return Check_Tag_DatabasesRet;
                    }
                }

                if (Which_Type != 3)
                {
                    existing = LookUp_One_Field("Container_RFID", " EPC_Nr='" + The_EPC + "'", "Container_ID");
                    if (existing != "0" & existing.Length > 0)
                    {
                        Check_Tag_DatabasesRet = true;
                        return Check_Tag_DatabasesRet;
                    }
                }

                if (Which_Type != 4)
                {
                    existing = LookUp_One_Field("Tray_RFID", " EPC_Nr='" + The_EPC + "'", "Tray_ID");
                    if (existing != "0" & existing.Length > 0)
                    {
                        Check_Tag_DatabasesRet = true;
                        return Check_Tag_DatabasesRet;
                    }
                }

                Check_Tag_DatabasesRet = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Issue in Checking ! {0}{1}", Constants.vbCrLf, ex.Message), "Check_Tag_Databases", MessageBoxButtons.OK);
                Check_Tag_DatabasesRet = true;
            }

            return Check_Tag_DatabasesRet;
        }

        /// <summary>
    ///     Usage :
    ///     <para>
    ///         &#160;Dim Tray_Exist As String = LookUpFastInDataBase("dbo.Tray_Description", " Tray_Name='" +
    ///         TextBoxTrayName.Text + "'")
    ///     </para>
    /// </summary>
    /// <param name="Database_Name"></param>
    /// <param name="WhereString"></param>
    /// <returns></returns>
        public static string LookUpFastInDataBase(string Database_Name, string WhereString)
        {
            string LookUpFastInDataBaseRet = default;
            var objConnection = new SqlConnection(Function_Module.SQL_ConnectionString);
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                using (var com1 = objConnection.CreateCommand())
                {
                    com1.CommandType = CommandType.Text;
                    com1.CommandText = "SELECT * FROM " + Database_Name + " WHERE " + WhereString + ";";
                    LookUpFastInDataBaseRet = Conversions.ToString(com1.ExecuteScalar());
                    // First Column !!!!
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem in LookUpInDataBase: " + Constants.vbCrLf + ex.Message, "LookUpInDataBase", MessageBoxButtons.OK);
                LookUpFastInDataBaseRet = "0";
            }

            objConnection.Close();
            return LookUpFastInDataBaseRet;
        }

        /// <summary>
    ///     Usage :
    ///     <para>&#160;LookUp_One_Field("Container_RFID", " EPC_Nr='" + The_EPC + "'", "Container_ID") Zero if NOT Found </para>
    /// </summary>
    /// <param name="Database_Name"></param>
    /// <param name="WhereString"></param>
    /// <param name="Field_Name"></param>
    /// <returns></returns>
        public static string LookUp_One_Field(string Database_Name, string WhereString, string Field_Name)
        {
            string LookUp_One_FieldRet = default;
            var objConnection = new SqlConnection(Function_Module.SQL_ConnectionString);
            try
            {
                LookUp_One_FieldRet = "";
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                using (var com1 = objConnection.CreateCommand())
                {
                    com1.CommandType = CommandType.Text;
                    com1.CommandText = "SELECT TOP 1 * FROM " + Database_Name + " WHERE " + WhereString + ";";
                    using (var reader = com1.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (Information.IsDBNull(reader[Field_Name]))
                                {
                                    LookUp_One_FieldRet = 0.ToString();
                                }
                                else
                                {
                                    LookUp_One_FieldRet = reader[Field_Name].ToString();
                                }
                            }
                        }
                        else
                        {
                            LookUp_One_FieldRet = 0.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Issue in ... : " + ex.Message, "LookUp_One_Field", MessageBoxButtons.OK);
                LookUp_One_FieldRet = "";
            }

            objConnection.Close();
            return LookUp_One_FieldRet;
        }

        /// <summary>
    ///     Usage :
    ///     <para>&#160;Dim Check_Exist As String = "" </para>
    ///     <para>
    ///         &#160;Check_Exist = LookUpInDataBase("Reader_Description", "Reader_Name ='" + Function_Module.The_Reader_Name +
    ///         "'", "Reader_ID")
    ///     </para>
    ///     <para>&#160;Nothing = Not Found - An Issue ! </para>
    /// </summary>
    /// <param name="Database_Name"></param>
    /// <param name="WhereString"></param>
    /// <param name="Field_Name"></param>
    /// <returns></returns>
        public static string LookUpInDataBase(string Database_Name, string WhereString, string Field_Name)
        {
            string LookUpInDataBaseRet = default;
            var objConnection = new SqlConnection(Function_Module.SQL_ConnectionString);
            try
            {
                LookUpInDataBaseRet = "Not Found - An Issue !";
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                using (var com1 = objConnection.CreateCommand())
                {
                    com1.CommandType = CommandType.Text;
                    com1.CommandText = "SELECT * FROM " + Database_Name + " WHERE " + WhereString + ";";
                    using (var reader = com1.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (Information.IsDBNull(reader[Field_Name]))
                                {
                                    LookUpInDataBaseRet = "Not Found - An Issue !";
                                }
                                else
                                {
                                    LookUpInDataBaseRet = reader[Field_Name].ToString();
                                }
                            }
                        }
                        else
                        {
                            LookUpInDataBaseRet = "Not Found - An Issue !";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem in LookUpInDataBase: " + Constants.vbCrLf + ex.Message, "LookUpInDataBase", MessageBoxButtons.OK);
                LookUpInDataBaseRet = "Not Found - An Issue !" + Field_Name + Database_Name;
            }

            objConnection.Close();
            return LookUpInDataBaseRet;
        }

        /// <summary>
    ///     Usage :
    ///     <para>&#160;Dim Check_Exist As String = "" </para>
    ///     <para>
    ///         &#160;Check_Exist = LookUpInDataBase_Empty("Reader_Description", "Reader_Name ='" +
    ///         Function_Module.The_Reader_Name + "'", "Reader_ID")
    ///     </para>
    ///     <para>&#160;Nothing =  Empty String Length=0 </para>
    /// </summary>
    /// <param name="Database_Name"></param>
    /// <param name="WhereString"></param>
    /// <param name="Field_Name"></param>
    /// <returns></returns>

        public static string LookUpInDataBase_Empty(string Database_Name, string WhereString, string Field_Name)
        {
            string LookUpInDataBase_EmptyRet = default;
            var objConnection = new SqlConnection(Function_Module.SQL_ConnectionString);
            try
            {
                LookUpInDataBase_EmptyRet = "";
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                using (var com1 = objConnection.CreateCommand())
                {
                    com1.CommandType = CommandType.Text;
                    com1.CommandText = "SELECT * FROM " + Database_Name + " WHERE " + WhereString + ";";
                    using (var reader = com1.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (Information.IsDBNull(reader[Field_Name]))
                                {
                                    LookUpInDataBase_EmptyRet = "";
                                }
                                else
                                {
                                    LookUpInDataBase_EmptyRet = reader[Field_Name].ToString();
                                }
                            }
                        }
                        else
                        {
                            LookUpInDataBase_EmptyRet = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem in LookUpInDataBase: " + Constants.vbCrLf + ex.Message, "LookUpInDataBase", MessageBoxButtons.OK);
                LookUpInDataBase_EmptyRet = "";
            }

            objConnection.Close();
            return LookUpInDataBase_EmptyRet;
        }

        /// <summary>
    ///     Usage :
    ///     <para>
    ///         &#160; Dim Columns_Text As String = LookUpInDataBase_Columns("Reader_Description", " Reader_ID ='" &
    ///         The_Device_ID & "'")
    ///     </para>
    ///     <para>&#160;Nothing =  WHERE string with out the WHERE word </para>
    /// </summary>
    /// <param name="Database_Name"></param>
    /// <param name="WhereString"></param>
    /// <returns></returns>


        public static string LookUpInDataBase_Columns(string Database_Name, string WhereString)
        {
            string LookUpInDataBase_ColumnsRet = default;
            var objConnection = new SqlConnection(Function_Module.SQL_ConnectionString);
            LookUpInDataBase_ColumnsRet = "";
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                using (var com1 = objConnection.CreateCommand())
                {
                    com1.CommandType = CommandType.Text;
                    com1.CommandText = "SELECT * FROM " + Database_Name + " WHERE " + WhereString + ";";
                    using (var reader = com1.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                for (int i = 0, loopTo = reader.FieldCount - 1; i <= loopTo; i++)
                                {
                                    if (i > 0)
                                    {
                                        LookUpInDataBase_ColumnsRet = LookUpInDataBase_ColumnsRet + " ; " + reader[i].ToString();
                                    }
                                    else
                                    {
                                        LookUpInDataBase_ColumnsRet = reader[i].ToString();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Problem in LookUpInDataBase_Columns: {0}{1}", Constants.vbCrLf, ex.Message), "LookUpInDataBase_Columns", MessageBoxButtons.OK);
                LookUpInDataBase_ColumnsRet = " ; ";
            }

            objConnection.Close();
            return LookUpInDataBase_ColumnsRet;
        }

        /// <summary>
    ///     Usage :
    ///     <para>
    ///         &#160;Check_Exist = LookUpInDataBase_ParaM("Department", "Department_ID =",
    ///         Function_Module.The_Department_ID.ToString, "Department_Name")
    ///     </para>
    /// </summary>
    /// <param name="Database_Name"></param>
    /// <param name="Col_Name"></param>
    /// <param name="WhereString"></param>
    /// <param name="Field_Name"></param>
    /// <param name="More_Columns"></param>
    /// <returns></returns>
        public static string LookUpInDataBase_ParaM(string Database_Name, string Col_Name, string WhereString, string Field_Name, bool More_Columns = false)
        {
            string LookUpInDataBase_ParaMRet = default;
            var objConnection = new SqlConnection(Function_Module.SQL_ConnectionString);
            LookUpInDataBase_ParaMRet = "";
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                using (var com1 = objConnection.CreateCommand())
                {
                    com1.CommandType = CommandType.Text;
                    com1.CommandText = "SELECT * FROM " + Database_Name + "  WHERE " + Col_Name + " @WhereString";
                    com1.Parameters.Add("@WhereString", SqlDbType.NVarChar).Value = WhereString;
                    using (var reader = com1.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (More_Columns)
                                {
                                    for (int i = 1, loopTo = reader.FieldCount - 1; i <= loopTo; i++)
                                        LookUpInDataBase_ParaMRet = LookUpInDataBase_ParaMRet + " " + reader[i].ToString();
                                }
                                else if (Information.IsDBNull(reader[Field_Name]))
                                {
                                    LookUpInDataBase_ParaMRet = "Not Found - An Issue !";
                                }
                                else
                                {
                                    LookUpInDataBase_ParaMRet = reader[Field_Name].ToString();
                                }
                            }
                        }
                        else
                        {
                            LookUpInDataBase_ParaMRet = "Not Found - An Issue !";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Problem in LookUpInDataBase: {0}{1}", Constants.vbCrLf, ex.Message), "LookUpInDataBase", MessageBoxButtons.OK);
                LookUpInDataBase_ParaMRet = "Not Found - An Issue !" + Field_Name + Database_Name;
            }

            objConnection.Close();
            return LookUpInDataBase_ParaMRet;
        }

        /// <summary>
    ///     Usage :
    ///     <para>
    ///         &#160;Dim InsertSQL As String = "(Connect_ID,Log_Type,UserName, Log_Place)  VALUES('" +
    ///         Function_Module.GlobalPersonID + "','LogOUT','" + Function_Module.Program_User + "','" +
    ///         Function_Module.The_Reader_Name + "')"
    ///     </para>
    ///     <para>&#160;Dim UpdatedNumber As Integer = WriteToDatabase("LogIn_Table", InsertSQL, "Log_ID") </para>
    /// </summary>
    /// <param name="TableName"></param>
    /// <param name="InsertString"></param>
    /// <param name="Count_ID"></param>
    /// <returns></returns>
        public static int WriteToDatabase(string TableName, string InsertString, string Count_ID)
        {
            int WriteToDatabaseRet = default;
            var objConnection = new SqlConnection(Function_Module.SQL_ConnectionString);
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                using (var com1 = objConnection.CreateCommand())
                {
                    com1.CommandType = CommandType.Text;
                    com1.CommandText = "INSERT INTO " + TableName + " " + InsertString + ";";
                    int results = com1.ExecuteNonQuery();
                    if (results < 1)
                        throw new Exception("Insert Failed:");
                    com1.CommandType = CommandType.Text;
                    com1.CommandText = "SELECT COUNT(" + Count_ID.ToString() + ") FROM " + TableName + ";";
                    results = Conversions.ToInteger(com1.ExecuteScalar());
                    WriteToDatabaseRet = results;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem ... Correct the input file: " + Constants.vbCrLf + Constants.vbCrLf + ex.Message, "WriteToDatabase", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteToDatabaseRet = 0;
            }

            objConnection.Close();
            return WriteToDatabaseRet;
        }
        
        /// <summary>
    ///     Usage :
    ///     <para>
    ///         &#160;Dim Field_Array() As String = New String() {ComboBoxDescription.SelectedItem(1).ToString,
    ///         ComboBoxDescription.SelectedItem(0).ToString, TextBoxSpecial.Text, Format(Now(), "yyyy-MM-dd HH:mm:ss")}
    ///     </para>
    ///     <para>
    ///         &#160;Dim str_SQL_Write As String = "(Description_ID,  Tray_Name,Special_Text,Date_Changed) " + "VALUES
    ///         (@Field_0,@Field_1,@Field_2,@Field_3)"
    ///     </para>
    ///     <para>
    ///         &#160; Dim The_Index As Integer = Function_Module.Caretag_Common.Functions.WriteToDatabase_ParaM("Tray_Image",
    ///         str_SQL_Write, Field_Array, "Image_ID")
    ///     </para>
    /// </summary>
    /// <param name="TableName"></param>
    /// <param name="InsertString"></param>
    /// <param name="Field_Array"></param>
    /// <param name="Count_ID"></param>
    /// <param name="UseError"></param>
    /// <param name="Use_Identity"></param>
    /// <returns></returns>
        public static int WriteToDatabase_ParaM(string TableName, string InsertString, string[] Field_Array, string Count_ID, bool UseError = true, bool Use_Identity = false)
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
                    using (var command = new SqlCommand("INSERT INTO " + TableName + InsertString + "SELECT CAST(scope_identity() AS int);", objConnection))

                    {
                        int MaxArray = Information.UBound(Field_Array, 1);
                        for (int i = 0, loopTo = MaxArray; i <= loopTo; i++)
                            command.Parameters.AddWithValue("@Field_" + i.ToString(), Field_Array[i].ToString());
                        WriteToDatabase_ParaMRet = Conversions.ToInteger(command.ExecuteScalar());
                        if (WriteToDatabase_ParaMRet < 1)
                            throw new Exception("Insert Scope Failed:");
                    }
                }
                else
                {
                    using (var command = new SqlCommand("INSERT INTO " + TableName + InsertString + "SELECT COUNT(" + Count_ID.ToString() + ") FROM " + TableName + ";", objConnection))

                    {
                        int MaxArray = Information.UBound(Field_Array, 1);
                        for (int i = 0, loopTo1 = MaxArray; i <= loopTo1; i++)
                            command.Parameters.AddWithValue("@Field_" + i.ToString(), Field_Array[i].ToString());
                        WriteToDatabase_ParaMRet = Conversions.ToInteger(command.ExecuteScalar());
                        if (WriteToDatabase_ParaMRet < 1)
                            throw new Exception("Insert Count Failed:");
                    }
                }
            }
            catch (Exception ex)
            {
                if (UseError)
                {
                    MessageBox.Show("Problem in database ... Check server " + Constants.vbCrLf + Constants.vbCrLf + ex.Message, "WriteToDatabase_ParaM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                WriteToDatabase_ParaMRet = 0;
            }

            objConnection.Close();
            return WriteToDatabase_ParaMRet;
        }

        /// <summary>
    ///     Usage :
    ///     <para>&#160;Please use PARAMETER Version  </para>
    ///     <para>&#160;Dim str_SQL As String = " Log_ID = NULL WHERE UserID ='" + Function_Module.GlobalPersonID  </para>
    ///     <para>&#160;If Not Function_Module.Caretag_Common.Functions.UpdateToDatabase("TblPassword", str_SQL) Then </para>
    ///     <para>&#160;        Throw New Exception("Update  TblPassword  Failed:") </para>
    ///     <para>&#160;End If </para>
    /// </summary>
    /// <param name="TableName"></param>
    /// <param name="InsertString"></param>
    /// <param name="Show_Error"></param>
    /// <returns></returns>
        public static bool UpdateToDatabase(string TableName, string InsertString, bool Show_Error = true)
        {
            bool UpdateToDatabaseRet = default;
            var objConnection = new SqlConnection(Function_Module.SQL_ConnectionString);
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
                    UpdateToDatabaseRet = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem in database ... Check server " + Constants.vbCrLf + Constants.vbCrLf + ex.Message, "UpdateToDatabase", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateToDatabaseRet = false;
            }

            objConnection.Close();
            return UpdateToDatabaseRet;
        }

        /// <summary>
    ///     Usage :
    ///     <para>
    ///         &#160;Dim Field_Array() As String = New String() {ComboBoxDescription.SelectedItem(1).ToString,
    ///         ComboBoxDescription.SelectedItem(0).ToString, TextBoxSpecial.Text, Format(Now(), "yyyy-MM-dd HH:mm:ss")}
    ///     </para>
    ///     <para>
    ///         &#160; Dim str_SQL As String = " Description_ID = @Field_0, Tray_Name= @Field_1,Special_Text= @Field_2,
    ///         Date_Changed= @Field_3 WHERE Description_ID ='" + Exist + "'"
    ///     </para>
    ///     <para>&#160;UpdateToDatabase_ParaM("Tray_Image", str_SQL, Field_Array) </para>
    /// </summary>
    /// <param name="TableName"></param>
    /// <param name="InsertString"></param>
    /// <param name="Field_Array"></param>
    /// <param name="UseError"></param>
    /// <returns></returns>
        public static bool UpdateToDatabase_ParaM(string TableName, string InsertString, string[] Field_Array, bool UseError = true)
        {
            bool UpdateToDatabase_ParaMRet = default;
            var objConnection = new SqlConnection(Function_Module.SQL_ConnectionString);
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                using (var command = new SqlCommand("UPDATE " + TableName + " SET " + InsertString, objConnection))
                {
                    int MaxArray = Information.UBound(Field_Array, 1);
                    for (int i = 0, loopTo = MaxArray; i <= loopTo; i++)
                        command.Parameters.AddWithValue("@Field_" + i.ToString(), Field_Array[i].ToString());
                    int results = command.ExecuteNonQuery();
                    if (results < 1)
                        throw new Exception("Update Failed:");
                }

                UpdateToDatabase_ParaMRet = true;
            }
            catch (Exception ex)
            {
                if (UseError)
                {
                    MessageBox.Show("Problem in database ... Check server " + Constants.vbCrLf + Constants.vbCrLf + ex.Message, "UpdateToDatabase", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UpdateToDatabase_ParaMRet = false;
                }
            }

            objConnection.Close();
            return UpdateToDatabase_ParaMRet;

            // Dim Field_Array() As String = New String() {"0"}
            // Dim str_SQL As String = "  Default_Cost =@Field_0 "
            // If Not Surgical_Admin_Class.DashBoardFunctions.UpdateToDatabase_ParaM("Cost_Type", str_SQL, Field_Array, True) Then
            // Throw New Exception("Update  Cost Item   Failed !")
            // End If
        }

        /// <summary>
    ///     Usage :
    ///     <para>&#160; UpdatedNumber = Insert_Procedure(TextBoxTrayName.Text, TextBoxTrayDescrip.Text, False) </para>
    /// </summary>
    /// <param name="Value1"></param>
    /// <param name="Value2"></param>
    /// <param name="Value3"></param>
    /// <returns></returns>
        public static int Insert_Procedure(string Value1, string Value2, bool Value3)
        {
            int Insert_ProcedureRet = default;
            var objConnection = new SqlConnection(Function_Module.SQL_ConnectionString);
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
                    sqlComm.CommandText = "Insert_Tray_Description";
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@pTray_Name", Value1);
                    sqlComm.Parameters.AddWithValue("@pDescrip_Text", Value2);
                    sqlComm.Parameters.AddWithValue("@pTray_Locked", Value3);
                    var CreateTray = sqlComm.ExecuteScalar();
                    Insert_ProcedureRet = Conversions.ToInteger(CreateTray);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem ...  " + Constants.vbCrLf + Constants.vbCrLf + ex.Message, "Insert_Procedure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Insert_ProcedureRet = 0;
            }

            objConnection.Close();
            return Insert_ProcedureRet;
        }

        /// <summary>
    ///     Usage :
    ///     <para>
    ///         &#160;ReadyInstrumentsComboBox(ComboBoxInstr, str_SQL, "", "Instrument_Description ORDER BY
    ///         Description_Name", "-- Choose Instrument Type --")
    ///     </para>
    /// </summary>
    /// <param name="cbrSelection"></param>
    /// <param name="Selection_Str"></param>
    /// <param name="Name_Data_Table"></param>
    /// <param name="str_Filter"></param>
    /// <param name="All_Names"></param>
    /// <returns></returns>
        public static bool ReadyInstrumentsComboBox(ComboBox cbrSelection, string Selection_Str, string Name_Data_Table, string str_Filter = "", string All_Names = "")
        {
            // Dim objConnection As SqlConnection = New SqlConnection(SQL_ConnectionString)
            try
            {
                string str_query = "SELECT " + Selection_Str + " FROM " + Name_Data_Table + str_Filter;
                using (var objDataAdapter = new SqlDataAdapter(str_query, Function_Module.SQL_ConnectionString))
                {
                    var ds = new DataSet();
                    objDataAdapter.Fill(ds, "ComboDataSet");                                     // Populate the DataTable
                    if (All_Names.Length > 0)
                    {
                        var dr = ds.Tables["ComboDataSet"].NewRow();
                        dr[0] = 0;
                        dr[1] = All_Names;
                        ds.Tables["ComboDataSet"].Rows.InsertAt(dr, 0);
                    }
                    

                    foreach (DataRow row in ds.Tables["ComboDataSet"].Rows) // Allways use zero as the main index
                    {
                        var sku = String.Format("{0,-20}", row[0]);

                        row[1] =  sku + row[1] + " " + row[2] + " " + row[3];
                    }

                    cbrSelection.DataSource = ds.Tables["ComboDataSet"];
                    cbrSelection.ValueMember = ds.Tables["ComboDataSet"].Rows[0].Table.Columns[0].ToString();
                    cbrSelection.DisplayMember = ds.Tables["ComboDataSet"].Rows[0].Table.Columns[1].ToString();
                }
            }
            catch (Exception ex)
            {
            }

            cbrSelection.DropDownStyle = ComboBoxStyle.DropDownList;

            return true;
        }

        /// <summary>
    ///     Usage :
    ///     <para>&#160;Full SELECT Command </para>
    /// </summary>
    /// <param name="Check_SQLstr"></param>
    /// <returns></returns>
        public static bool Check_Exist(string Check_SQLstr)
        {
            bool Check_ExistRet = default;
            var objConnection = new SqlConnection(Function_Module.SQL_ConnectionString);
            Check_ExistRet = true;
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                using (var com1 = objConnection.CreateCommand())
                {
                    com1.CommandType = CommandType.Text;
                    com1.CommandText = Check_SQLstr;
                    int results = Conversions.ToInteger(com1.ExecuteScalar());
                    if (results < 1)
                        Check_ExistRet = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem in Check_Exist: " + ex.Message, "Check_Exist", MessageBoxButtons.OK);
                Interaction.Beep();
            }

            objConnection.Close();
            return Check_ExistRet;
        }
        
        
        /// <summary>
    ///     Usage :
    ///     <para>&#160;DeleteContent("Instrument_Maintenance_RFID WHERE EPC_Nr = '" + TextBoxEPC.Text + "'", False) </para>
    /// </summary>
    /// <param name="TableName"></param>
    /// <param name="Error_Message"></param>
    /// <returns></returns>
        public static bool DeleteContent(string TableName, bool Error_Message = false)
        {
            bool DeleteContentRet = default;
            var objConnection = new SqlConnection(Function_Module.SQL_ConnectionString);
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                using (var com1 = objConnection.CreateCommand())
                {
                    com1.CommandType = CommandType.Text;
                    com1.CommandText = "DELETE  FROM " + TableName;
                    int results = com1.ExecuteNonQuery();
                    if (results < 1)
                        throw new Exception("DeleteContent Failed:");
                    DeleteContentRet = true;
                }
            }
            catch (Exception ex)
            {
                if (Error_Message)
                {
                    DeleteContentRet = false;   // Problemos ???
                }
                else
                {
                    DeleteContentRet = true;
                }
            }

            objConnection.Close();
            return DeleteContentRet;
        }

        /// <summary>
    ///     Usage :
    ///     <para>
    ///         &#160;FillDataInDatagridview(DataGridViewErrorLog, "SELECT * FROM View_Reader_Log_Error " + The_Where_str + "
    ///         ORDER BY ErrorLog_ID DESC", True)
    ///     </para>
    /// </summary>
    /// <param name="TheDataGridView"></param>
    /// <param name="selectCommand"></param>
    /// <param name="MakeReadOnly"></param>
    /// <returns></returns>
        public static bool FillDataInDatagridview(ref DataGridView TheDataGridView, string selectCommand, ref bool MakeReadOnly)
        {
            try
            {
                using (var connection = new SqlConnection(Function_Module.SQL_ConnectionString))
                {
                    using (var objDataAdapter = new SqlDataAdapter())
                    {
                        objDataAdapter.SelectCommand = new SqlCommand(selectCommand, connection);
                        connection.Open();
                        var table = new DataTable();
                        table.Locale = CultureInfo.InvariantCulture;
                        table.Clear();
                        objDataAdapter.Fill(table);
                        TheDataGridView.DataSource = table;
                    }
                }
                
                foreach (DataGridViewRow row in TheDataGridView.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell is DataGridViewCheckBoxCell boxCell)
                            boxCell.TrueValue = true;
                    }
                }

                if (MakeReadOnly)
                {
                    foreach (DataGridViewColumn dgvCol in TheDataGridView.Columns)
                        dgvCol.ReadOnly = true;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "FillDataInDatagridview", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        /// <summary>
    ///     Usage :
    ///     <para>&#160;Dim The_DataTable As New DataTable </para>
    ///     <para>&#160;Dim str_SQL As String = "Select DATA_TYPE, TABLE_NAME, COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS " + </para>
    ///     <para>&#160;                        " WHERE  (TABLE_NAME = '" + The_Table + "')" </para>
    ///     <para>&#160;FillDataTable(str_SQL, The_DataTable) </para>
    /// </summary>
    /// <param name="selectCommand"></param>
    /// <param name="The_DataTable"></param>
    /// <returns></returns>
        public static bool FillDataTable(string selectCommand, ref DataTable The_DataTable)
        {
            bool FillDataTableRet = default;
            try
            {
                // TODO    NEW VERSION TO command builder
                using (var connection = new SqlConnection(Function_Module.SQL_ConnectionString))
                {
                    using (var objDataAdapter = new SqlDataAdapter())
                    {
                        objDataAdapter.SelectCommand = new SqlCommand(selectCommand, connection);
                        var builder = new SqlCommandBuilder(objDataAdapter);
                        connection.Open();
                        The_DataTable.Locale = CultureInfo.InvariantCulture;
                        The_DataTable.Clear();
                        objDataAdapter.Fill(The_DataTable);
                        FillDataTableRet = true;
                    }
                }
            }

            // Using objDataAdapter As New SqlDataAdapter(selectCommand, SQL_ConnectionString)
            // Dim table As New DataTable()
            // The_DataTable.Locale = CultureInfo.InvariantCulture
            // The_DataTable.Clear()
            // objDataAdapter.Fill(The_DataTable)
            // FillDataTable = True
            // End Using


            catch (Exception ex)
            {
                MessageBox.Show("Issue in ... FillDataTable: " + ex.Message, "FillDataTable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FillDataTableRet = false;
            }

            return FillDataTableRet;
        }
        
        
        /// <summary>
    ///     Usage :
    ///     <para>&#160;LabelCount.Text =  CStr(Function_Module.Caretag_Common.Functions.CountRecords("Tray_Description")) </para>
    /// </summary>
    /// <param name="SQL_Table"></param>
    /// <returns></returns>
        public static int CountRecords(string SQL_Table)
        {
            int CountRecordsRet = default;
            var objConnection = new SqlConnection(Function_Module.SQL_ConnectionString);
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                var com1 = objConnection.CreateCommand();
                com1.CommandType = CommandType.Text;
                com1.CommandText = "SELECT Count(*) FROM " + SQL_Table + ";";
                int results = Conversions.ToInteger(com1.ExecuteScalar());
                CountRecordsRet = results;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Issue in CountRecords: " + Constants.vbCrLf + ex.Message, "CountRecords", MessageBoxButtons.OK);
                Interaction.Beep();
                CountRecordsRet = 0;
            }

            objConnection.Close();
            return CountRecordsRet;
        }

        /// <summary>
    ///     Usage :
    ///     <para>
    ///         &#160;Dim Where_2 As String = " Reader_Name Like '" + Name_1 + "%' AND SoftwareVersion ='" +
    ///         DataGridView_Update.Lines(The_Index).Cells("Version").Value + "'"
    ///     </para>
    ///     <para>&#160;Dim Count_2 As Integer = CountInDataBase("Reader_Description", Where_2) </para>
    /// </summary>
    /// <param name="Database_Name"></param>
    /// <param name="WhereString"></param>
    /// <returns></returns>
        public static int CountInDataBase(string Database_Name, string WhereString)
        {
            int CountInDataBaseRet = default;
            var objConnection = new SqlConnection(Function_Module.SQL_ConnectionString);
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                using (var com1 = objConnection.CreateCommand())
                {
                    com1.CommandType = CommandType.Text;
                    com1.CommandText = "SELECT COUNT(*) FROM " + Database_Name + " WHERE " + WhereString + ";";
                    int counterRFID = Conversions.ToInteger(com1.ExecuteScalar());
                    CountInDataBaseRet = counterRFID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem in CountInDataBase: " + Constants.vbCrLf + ex.Message, "CountInDataBase", MessageBoxButtons.OK);
                CountInDataBaseRet = 0;
            }

            objConnection.Close();
            return CountInDataBaseRet;
        }

        /// <summary>
    ///     Usage :
    ///     <para>
    ///         &#160;Dim The_SQL As String = "SELECT Count(Instrument_Company) FROM Instrument_Description WHERE
    ///         Instrument_Company LIKE '" + Name_1 + "'"
    ///     </para>
    ///     <para>&#160;Dim Count_2 As Integer = Count_SQL(The_SQL) </para>
    /// </summary>
    /// <param name="SQL_String"></param>
    /// <returns></returns>
        public static int Count_SQL(string SQL_String)
        {
            int Count_SQLRet = default;
            var objConnection = new SqlConnection(Function_Module.SQL_ConnectionString);
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                using (var com1 = objConnection.CreateCommand())
                {
                    com1.CommandType = CommandType.Text;
                    com1.CommandText = SQL_String + ";";
                    int counterRFID = Conversions.ToInteger(com1.ExecuteScalar());
                    Count_SQLRet = counterRFID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem in Count_SQL: " + Constants.vbCrLf + ex.Message, "Count_SQL", MessageBoxButtons.OK);
                Count_SQLRet = 0;
            }

            objConnection.Close();
            return Count_SQLRet;
        }
        
        

        /// <summary>
    ///     Usage :
    ///     <para>&#160;The_Image_ID = DataGridView1.Lines(e.RowIndex).Cells("Description_ID").Value.ToString </para>
    ///     <para>&#160;If The_Image_ID.Trim.Length = 1 Then The_Image_ID = "0" </para>
    ///     <para>&#160;Loading_Image_From_Database("Tray_Image", The_Description_ID, Function_Module.picture) </para>
    /// </summary>
    /// <param name="The_Table"></param>
    /// <param name="TheDescription_ID"></param>
    /// <param name="The_Image"></param>
        public static void Loading_Image_From_Database(string The_Table, string TheDescription_ID, ref Image The_Image)
        {
            var objConnection = new SqlConnection(Function_Module.SQL_ConnectionString);
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                using (var com1 = objConnection.CreateCommand())
                {
                    com1.CommandType = CommandType.Text;
                    com1.CommandText = "SELECT TheImage FROM " + The_Table + " WHERE Description_ID = '" + TheDescription_ID + "';";
                    byte[] pictureData = (byte[])com1.ExecuteScalar();
                    objConnection.Close();
                    if (Information.IsNothing(pictureData))
                    {
                        The_Image = null;
                        return;
                    }

                    using (var stream = new MemoryStream(pictureData))
                    {
                        The_Image = Image.FromStream(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Problem in Loading Image database ...  " & vbCrLf & vbCrLf &
                // ex.Message, "Loading_Image_From_Database", MessageBoxButtons.OK, MessageBoxIcon.Error)

            }
        }

        /// <summary>
    ///     Usage :
    ///     <para>&#160;The_Image_ID = DataGridView1.Lines(e.RowIndex).Cells("Description_ID").Value.ToString </para>
    ///     <para>&#160;If The_Image_ID.Trim.Length = 1 Then The_Image_ID = "0" </para>
    ///     <para>&#160;Loading_TrayImage_From_Database("Tray_Image", The_Image_ID, Function_Module.picture) </para>
    /// </summary>
    /// <param name="The_Table"></param>
    /// <param name="TheDescription_ID"></param>
    /// <param name="The_Image"></param>
        public static void Loading_TrayImage_From_Database(string The_Table, string The_Image_ID, ref Image The_Image)
        {
            var objConnection = new SqlConnection(Function_Module.SQL_ConnectionString);
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                using (var com1 = objConnection.CreateCommand())
                {
                    com1.CommandType = CommandType.Text;
                    com1.CommandText = "SELECT TheImage FROM " + The_Table + " WHERE Image_ID = '" + The_Image_ID + "';";
                    byte[] pictureData = (byte[])com1.ExecuteScalar();
                    objConnection.Close();
                    if (Information.IsNothing(pictureData))
                    {
                        The_Image = null;
                        return;
                    }

                    using (var stream = new MemoryStream(pictureData))
                    {
                        The_Image = new Bitmap(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                string title = "Loading Image from database";
                string message = "Problem in Loading Image database";
                MessageBox.Show(title, message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
    ///     Usage :
    ///     <para>&#160;Dim The_SQL As String = "SELECT The_Logo FROM Steril_Central;" </para>
    ///     <para>
    ///         &#160;Call Function_Module.Caretag_Common.Functions.Loading_Logo_From_Database(The_SQL, False,
    ///         Function_Module.picture)
    ///     </para>
    ///     <para>&#160;PictureBoxLogo.Image = Function_Module.picture </para>
    /// </summary>
    /// <param name="The_SQL_Txt"></param>
    /// <param name="Use_Error"></param>
    /// <param name="The_Image"></param>
        public static void Loading_Logo_From_Database(string The_SQL_Txt, bool Use_Error, ref Image The_Image)
        {
            var objConnection = new SqlConnection(Function_Module.SQL_ConnectionString);
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                using (var com1 = objConnection.CreateCommand())
                {
                    com1.CommandType = CommandType.Text;
                    com1.CommandText = The_SQL_Txt;
                    byte[] pictureData = (byte[])com1.ExecuteScalar();
                    if (Information.IsNothing(pictureData))
                    {
                        The_Image = null;
                        return;
                    }

                    using (var stream = new MemoryStream(pictureData))
                    {
                        The_Image = Image.FromStream(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                if (Use_Error)
                    MessageBox.Show("Problem in Loading Logo database ...  " + Constants.vbCrLf + Constants.vbCrLf + ex.Message, "Loading_Logo_From_Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            objConnection.Close();
        }

        /// <summary>
    ///     Usage :
    ///     <para>&#160;Update_ImageBox_Database("Tray_Image", ComboBoxDescription.SelectedItem(1).ToString, PictureBoxTray) </para>
    /// </summary>
    /// <param name="TableName"></param>
    /// <param name="The_DescriptionID"></param>
    /// <param name="The_PictureBox"></param>
        public static void Update_ImageBox_Database(string TableName, string The_DescriptionID, PictureBox The_PictureBox)
        {
            var objConnection = new SqlConnection(Function_Module.SQL_ConnectionString);
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                var safeImage = new Bitmap(The_PictureBox.Image);
                var command = new SqlCommand("UPDATE " + TableName + " SET TheImage = @Picture WHERE Description_ID ='" + The_DescriptionID + "';", objConnection);

                using (Image pictureX = safeImage)
                {
                    using (var stream = new MemoryStream())
                    {
                        pictureX.Save(stream, ImageFormat.Jpeg);
                        var b = stream.ToArray();
                        // command.Parameters.AddWithValue("@Picture", System.Data.SqlDbType.VarBinary)
                        // command.Parameters("@Picture").Value = stream.GetBuffer()

                        command.Parameters.Add("@Picture", SqlDbType.VarBinary, b.Length).Value = b;
                    }
                }

                command.ExecuteNonQuery();
                objConnection.Close();
            }
            catch (FileNotFoundException IO_Ex)
            {
                MessageBox.Show("Image is NOT Found or Defect ...  " + Constants.vbCrLf + Constants.vbCrLf + IO_Ex.Message, "Update_ImageBox_Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update_ImageBox_Database ...  " + Constants.vbCrLf + Constants.vbCrLf + ex.Message, "Update_ImageBox_Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
    ///     Usage :
    ///     <para>&#160;Saving_Image_Database(TextBoxImageFile.Text, ComboBoxChooseInstrument.SelectedValue.ToString) </para>
    /// </summary>
    /// <param name="The_Image_File"></param>
    /// <param name="The_DescriptionID"></param>
        public static void Saving_Image_Database(string The_Image_File, string The_DescriptionID)
        {
            var objConnection = new SqlConnection(Function_Module.SQL_ConnectionString);
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                using var command = new SqlCommand("begin tran\r\nif exists (select * from Instrument_Image with (updlock,serializable) where Description_ID = @DescriptionID)\r\nbegin\r\n   update Instrument_Image set TheImage = @Picture where Description_ID = @DescriptionID\r\nend\r\nelse\r\nbegin\r\n   INSERT INTO Instrument_Image(TheImage,Description_ID) VALUES(@Picture,@DescriptionID)\r\n   end\r\ncommit tran;", objConnection);

                var picValue = Image.FromFile(The_Image_File).GetFormattedStream(ImageFormat.Png).ToArray();

                command.Parameters.AddWithValue("@Picture", SqlDbType.VarBinary);
                command.Parameters["@Picture"].Value = picValue;
                command.Parameters.AddWithValue("@DescriptionID", The_DescriptionID);
                command.ExecuteNonQuery();
            }
            catch (FileNotFoundException IO_Ex)
            {
                MessageBox.Show("Image File is NOT Found ...  " + Constants.vbCrLf + Constants.vbCrLf + IO_Ex.Message, "Saving_Image_Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Saving_Image_Database ...  " + Constants.vbCrLf + Constants.vbCrLf + ex.Message, "Saving_Image_Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            objConnection.Close();
        }

        /// <summary>
    ///     Usage :
    ///     <para>&#160;Saving_TrayImage_Database(TheImage,Description_ID,Tray_Name,Special_Text) </para>
    /// </summary>
    /// <param name="The_Image_File"></param>
    /// <param name="The_DescriptionID"></param>
        public static void Saving_TrayImage_Database(string The_Image_File, string The_DescriptionID, string The_Name = "", string The_Text = "")
        {
            var objConnection = new SqlConnection(Function_Module.SQL_ConnectionString);
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                using (var command = new SqlCommand("INSERT INTO Tray_Image(TheImage,Description_ID,Tray_Name) VALUES(@Picture,@DescriptionID,@The_Name);", objConnection))

                {
                    var Picture = new SqlParameter("@Picture", SqlDbType.VarBinary);

                    var picValue = Image.FromFile(The_Image_File).GetFormattedStream(ImageFormat.Png).ToArray();

                    command.Parameters.AddWithValue("@Picture", SqlDbType.VarBinary);
                    command.Parameters["@Picture"].Value = picValue;
                    command.Parameters.AddWithValue("@DescriptionID", The_DescriptionID);
                    command.Parameters.AddWithValue("@The_Name", The_Name);
                    command.Parameters.AddWithValue("@The_Text", The_Text);
                    command.ExecuteNonQuery();
                }
            }
            catch (FileNotFoundException IO_Ex)
            {
                MessageBox.Show("Image File is NOT Found ...  " + Constants.vbCrLf + Constants.vbCrLf + IO_Ex.Message, "Saving_TrayImage_Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // TODO something
            catch (Exception ex)
            {
                MessageBox.Show("Saving_Image_Database ...  " + Constants.vbCrLf + Constants.vbCrLf + ex.Message, "Saving_Image_Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            objConnection.Close();
        }

        /// <summary>
    ///     Usage :
    ///     <para>&#160;Dim The_Where As String = " SterilCentral_ID >'0'" </para>
    ///     <para>&#160;Saving_Logo_Database("Steril_Central", "The_Logo", The_Where, TextBoxImageFile.Text, True) </para>
    /// </summary>
    /// <param name="The_Database"></param>
    /// <param name="The_Field"></param>
    /// <param name="The_Where"></param>
    /// <param name="The_Image_File"></param>
    /// <param name="Update"></param>
        public static void Saving_Logo_Database(string The_Database, string The_Field, string The_Where, string The_Image_File, bool Update)
        {
            // The_Logo
            var objConnection = new SqlConnection(Function_Module.SQL_ConnectionString);
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                SqlCommand command;
                if (Update)
                {
                    command = new SqlCommand("UPDATE " + The_Database + " SET " + The_Field + "=@Picture WHERE " + The_Where + ";", objConnection);
                }
                else
                {
                    command = new SqlCommand("INSERT INTO " + The_Database + "(" + The_Field + ") VALUES(@Picture);", objConnection);
                }

                // Dim Picture = New SqlParameter("@Picture", SqlDbType.VarBinary)

                using (var pictureX = Image.FromFile(The_Image_File))
                {
                    using (var stream = new MemoryStream())
                    {
                        pictureX.Save(stream, ImageFormat.Jpeg);
                        command.Parameters.AddWithValue("@Picture", SqlDbType.VarBinary);
                        command.Parameters["@Picture"].Value = stream.ToArray();
                    }
                }

                command.ExecuteNonQuery();
                objConnection.Close();
            }
            catch (FileNotFoundException IO_Ex)
            {
                MessageBox.Show("Image File is NOT Found ...  " + Constants.vbCrLf + Constants.vbCrLf + IO_Ex.Message, "Saving_Logo_Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Saving_Image_Database ...  " + Constants.vbCrLf + Constants.vbCrLf + ex.Message, "Saving_Logo_Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
    ///     Usage :
    ///     <para>
    ///         &#160;Streaming_Image_Database("INSERT INTO Tray_Image(TheImage,Tray_Name) VALUES(@Picture,@DescriptionID);",
    ///         The_FileName, The_Tray_Name)
    ///     </para>
    /// </summary>
    /// <param name="The_SQL_Command"></param>
    /// <param name="The_Image_File"></param>
    /// <param name="The_DescriptionID"></param>
        public static void Streaming_Image_Database(string The_SQL_Command, string The_Image_File, string The_DescriptionID)
        {
            var objConnection = new SqlConnection(Function_Module.SQL_ConnectionString);
            try
            {
                if (objConnection.State == ConnectionState.Closed)
                {
                    objConnection.Open();
                }

                var command = new SqlCommand(The_SQL_Command, objConnection);
                var Picture = new SqlParameter("@Picture", SqlDbType.VarBinary);
                using (var pictureX = Image.FromFile(The_Image_File))
                {
                    using (var stream = new MemoryStream())
                    {
                        pictureX.Save(stream, ImageFormat.Jpeg);
                        command.Parameters.AddWithValue("@Picture", SqlDbType.VarBinary);
                        command.Parameters["@Picture"].Value = stream.ToArray();
                    }
                }

                command.Parameters.AddWithValue("@DescriptionID", The_DescriptionID);
                command.ExecuteNonQuery();
                objConnection.Close();
            }
            catch (FileNotFoundException IO_Ex)
            {
                MessageBox.Show("Image File is NOT Found ...  " + Constants.vbCrLf + Constants.vbCrLf + IO_Ex.Message, "Streaming_Image_Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Streaming_Image_Database ...  " + Constants.vbCrLf + Constants.vbCrLf + ex.Message, "Streaming_Image_Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}