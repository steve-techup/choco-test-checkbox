using System.Drawing.Printing;
using Microsoft.VisualBasic.CompilerServices;

namespace PackingStation
{
    public partial class XtraReport_PackList
    {
        public XtraReport_PackList()
        {
            InitializeComponent();
            _XrLabel_Hidden.Name = "XrLabel_Hidden";
        }

        private void XrLabel_Hidden_BeforePrint(object sender, PrintEventArgs e)
        {
            if (Conversions.ToBoolean(GetCurrentColumnValue("Hide_Tray")))
                XrLabel_Hidden.Visible = true;
            else
                XrLabel_Hidden.Visible = false;
        }
    }
}