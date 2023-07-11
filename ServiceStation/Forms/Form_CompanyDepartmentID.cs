using System;
using System.Windows.Forms;
using Caretag_Class.EventReporting;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Service_Station
{
    public partial class Form_CompanyDepartmentID
    {
        private readonly EventReporter _eventReporter;

        public Form_CompanyDepartmentID(EventReporter eventReporter)
        {
            _eventReporter = eventReporter;
            InitializeComponent();
            _ComboBoxDepartment.Name = "ComboBoxDepartment";
            _ButtonExit.Name = "ButtonExit";
            _ButtonCancel.Name = "ButtonCancel";
        }

        private bool IsLoaded = false;

        private void FrmCompanyDepartmentID_Load(object sender, EventArgs e)
        {
            try
            {
                LabelDepartmentID.Text = 0.ToString();
                const string str_SQL = " Department_ID,Department_Name ";
                Caretag_Class.SQLUtil.ReadyComboBox(ComboBoxDepartment, str_SQL, "", "Department ORDER BY Department_Name ", "-- Choose Department --");
                // ComboBoxDepartment.Enabled = False

                IsLoaded = true;
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while loading the page", "An error occurred while loading the page", "ServiceStation-35", true, true);
            }
        }

        private void ComboBoxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsLoaded)
                return;
            try
            {
                LabelDepartmentID.Text = ComboBoxDepartment.SelectedValue.ToString();
                ButtonExit.Text = "Close";
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while changing the selected index", "An error occurred while changing the selected index", "ServiceStation-36", true, true);
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ComboBoxDepartment.SelectedIndex < 1)
                {
                    ComboBoxDepartment.Focus();
                    return;
                }

                Caretag_Class.Function_Module.The_Department_ID = Conversions.ToInteger(LabelDepartmentID.Text);
                Close();
            }
            catch (Exception ex)
            {
                _eventReporter.ReportError(ex, "An error occurred while clicking the exit button", "An error occurred while clicking the exit button", "ServiceStation-37", true, true);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Caretag_Class.Function_Module.The_Compamy_ID = 0;
            Caretag_Class.Function_Module.The_Department_ID = 0;
            Close();
        }
    }
}