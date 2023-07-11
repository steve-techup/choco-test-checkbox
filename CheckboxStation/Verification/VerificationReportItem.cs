using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CheckboxStation.Reporting
{
    public class VerificationReportItem
    {
        [Display(Name = "Session Count")]
        public int SessionCount { get; set; }
        public string DateTime { get; set; }

        [Display(Name = "Tray UDI")]
        public string TrayUDI { get; set; }

        [Display(Name = "Tray Name")]
        public string TrayName { get; set; }

        [Display(Name = "Article UDI")]
        public string ArticleUDI { get; set; }

        [Display(Name = "Article Sku")]
        public string ArticleSku { get; set; }

        [Display(Name = "Article Name")]
        public string ArticleName { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public int Expected { get; set; }

        [Display(Name = "Found Status")]
        public string FoundStatus { get; set; }
    }
}
