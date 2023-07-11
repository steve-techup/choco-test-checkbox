using System.Drawing.Printing;

namespace PackingStation
{
    public partial class XtraReportPackToday
    {
        private int total;

        public XtraReportPackToday()
        {
            InitializeComponent();
            _XrLabel6.Name = "XrLabel6";
            _XrLabel_Report_Tray.Name = "XrLabel_Report_Tray";
        }

        private void XrLabel6_BeforePrint(object sender, PrintEventArgs e)
        {
            total += 1;
        }

        private void XrLabel_Report_Tray_BeforePrint(object sender, PrintEventArgs e)
        {
            XrLabel_Report_Tray.Text = string.Format(" Total Tray's : {0}", total);
        }
    }
}