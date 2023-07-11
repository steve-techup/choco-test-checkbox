using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;

namespace AdminStation.ViewModels.DataTypeViewModels
{
    public class CostLogReportLine
    {
        [DisplayName("Tray name")]
        public string TrayName { get; set; }
        public decimal? Price { get; set; }
        public DateTime? Timestamp { get; set; }
    }
}
