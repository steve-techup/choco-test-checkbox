using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPivotGrid;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Drawing.Imaging;

namespace Caretag_Class.Caretag_Common
{
    public class Functions
    {
        public static void LoadResources(Control parent, string parent_name, ComponentResourceManager component_resource_manager)
        {
            // Load the parent's resources.
            component_resource_manager.ApplyResources(parent, parent_name);
            // ToolTip1.SetToolTip(parent, component_resource_manager.GetString(parent_name & ".ToolTip"))

            // Load each contained control's resources.
            foreach (Control ctl in parent.Controls)
                LoadResources(ctl, ctl.Name, component_resource_manager);
        }

        /// <summary>
        ///     Usage :
        ///     <para>&#160;ScreenDump(Me.Handle) </para>
        /// </summary>
        /// <para>&#160;The File Path is In SystemInfo: Path_To_Files" </para>
        /// <param name="parentHandle"></param>
        /// <returns></returns>
        public static bool ScreenDump(IntPtr parentHandle, bool chooseDirectory = false)
        {
            try
            {
                var currentScreen = Screen.FromHandle(parentHandle).Bounds;
                using var bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                using (var g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(new Point(0, 0), new Point(0, 0), currentScreen.Size);
                }

                if (!chooseDirectory)
                {
                    var scrDir = SQLUtil.LookUpInDataBase("SystemInfo", "ID > 0", "Path_To_Files");
                    if (!Directory.Exists(scrDir))
                    {
                        scrDir = "c:\\Caretag\\Screendumps";
                        if (!Directory.Exists(scrDir))
                            Directory.CreateDirectory(scrDir);

                    }
                    else
                        scrDir += "\\Screendumps";

                    string absolutePath =
                        $"{scrDir}\\Screen_{Function_Module.The_Reader_ID}_{DateAndTime.Now.ToOADate()}.png";
                    bmp.Save(absolutePath, ImageFormat.Png);
                    MessageBox.Show($"Saved screenshot at:\n{absolutePath}", "Screenshot saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    using var sfd = new SaveFileDialog
                    {
                        Filter = "PNG Image|* .png",
                        InitialDirectory = My.MyProject.Computer.FileSystem.SpecialDirectories.MyDocuments
                    };
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        bmp.Save(sfd.FileName, ImageFormat.Png); 
                        MessageBox.Show($"Saved screenshot at:\n{sfd.FileName}", "Screenshot saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + Constants.vbCrLf + ex.Message, "Unhandled error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return true;
        }

        /// <summary>
        ///     Usage :
        ///     <para>&#160;Write_EventLog(String.Format(" Deleted Steri LOGO  ", Function_Module.Program_User)) </para>
        /// </summary>
        /// <param name="Event_Text"></param>
        public static void Write_EventLog(string Event_Text)
        {
            int test1 = SQLUtil.WriteToDatabase("Log_Change", "(Text, User_Name) VALUES('" + Event_Text + "','" + Function_Module.Program_User.ToString() + "')", "Index_ID");
        }

        /// <summary>
        ///     Usage :
        ///     <para>&#160;SaveNumberRecs = WriteCSV_File(FormsDataGridView, MySaveDialog.FileName.ToString) </para>
        ///     <para>&#160; Formated CSV_File with " </para>
        /// </summary>
        /// <param name="FormsDataGridView"></param>
        /// <param name="FileName"></param>
        /// <param name="Example"></param>
        /// <returns></returns>
        public static int WriteCSV_File(DataGridView FormsDataGridView, string FileName, bool Example = false)
        {
            int WriteCSV_FileRet = default;
            try
            {
                int i = 0;
                int j = 0;
                int Example_Count = 0;
                var dt = FormsDataGridView;
                using (var sw = new StreamWriter(FileName))
                {
                    var loopTo = dt.Columns.Count - 1;
                    for (j = 0; j <= loopTo; j++) // Make The Headlines
                    {
                        sw.Write("\"" + dt.Columns[j].HeaderCell.Value.ToString() + "\"");
                        if (j < dt.Columns.Count - 1)
                        {
                            sw.Write(";");
                        }
                    }

                    sw.Write(sw.NewLine);
                    var loopTo1 = dt.Rows.Count - 1;
                    for (i = 0; i <= loopTo1; i++) // Udskrive de enkelte celler
                    {
                        var loopTo2 = dt.Columns.Count - 1;
                        for (j = 0; j <= loopTo2; j++)
                        {
                            if (dt.Rows[i].Cells[j].Value is object)
                            {
                                sw.Write("\"" + dt.Rows[i].Cells[j].Value.ToString() + "\"");
                                if (j < dt.Columns.Count - 1)
                                {
                                    sw.Write(";");
                                }
                            }
                        }

                        sw.Write(sw.NewLine);
                        if (Example & Example_Count > 10)
                        {
                            break;
                        }

                        Example_Count += 1;
                    }

                    WriteCSV_FileRet = i;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The File is NOT saved : ", "File NOT Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteCSV_FileRet = -1;
            }

            return WriteCSV_FileRet;
        }
        
        /// <summary>
        ///     Usage :
        ///     <para>
        ///         &#160;Using objDataAdapter As New SqlDataAdapter("SELECT * FROM " + The_Table,
        ///         Function_Module.SQL_ConnectionString)
        ///     </para>
        ///     <para>&#160;  Dim ds As New DataSet() </para>
        ///     <para>&#160;  Dim Fill1 As Integer = objDataAdapter.Fill(ds, "BackUp")  </para>
        ///     <para>&#160;  Dim dt As DataTable = ds.Tables("BackUp") </para>
        ///     <para>&#160; If NO Header in CSV File Write_Header = FALSE  </para>
        ///     <para>&#160;  CreateCSV_DataTable(dt, Function_Module.BackUp_FilePath) </para>
        ///     <para>&#160;  Create_BackUp = "BackUp: " + Function_Module.BackUp_FilePath </para>
        ///     <para>&#160;End Using </para>
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="strFilePath"></param>
        public static void CreateCSV_DataTable(ref DataTable dt, string strFilePath, bool Write_Header = true)
        {
            try
            {
                using (var sw = new StreamWriter(strFilePath, false))
                {
                    // First we will write the headers. 'DataTable dt = m_dsProducts.Tables[0];
                    int iColCount = dt.Columns.Count;
                    if (Write_Header)
                    {
                        for (int i = 0, loopTo = iColCount - 1; i <= loopTo; i++)
                        {
                            sw.Write(dt.Columns[i]);
                            if (i < iColCount - 1)
                            {
                                sw.Write(";");
                            }
                        }

                        sw.Write(sw.NewLine);
                    }
                    // Now write all the rows.
                    foreach (DataRow dr in dt.Rows)
                    {
                        for (int i = 0, loopTo1 = iColCount - 1; i <= loopTo1; i++)
                        {
                            if (!Convert.IsDBNull(dr[i]))
                            {
                                sw.Write(dr[i].ToString());
                            }

                            if (i < iColCount - 1)
                            {
                                sw.Write(";");
                            }
                        }

                        sw.Write(sw.NewLine);
                    }

                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Issue in CreateCSV_DataTable! {0}{1}", Constants.vbCrLf, ex.Message), "CreateCSV_DataTable", MessageBoxButtons.OK);
            }
        }
        
        public static void ExecuteShutdown(String parameters)
        {

            #if NOSHUTDOWN
            MessageBox.Show("ShutDown requested with the following parameters\n" +
                            "'" + parameters + "'\n" +
                            "Halting execution!", "NoShutDown", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            // Stop execution returning errorcode "ERROR_NOT_SUPPORTED"
            Environment.Exit(50);
            #endif
            
            Process.Start("ShutDown", parameters);

        }
    }
}