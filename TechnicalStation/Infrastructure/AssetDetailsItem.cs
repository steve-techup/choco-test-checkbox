using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalStation.Infrastructure
{
    public class AssetDetailsItem
    {
        public long Id { get; set; }
        public string Epc { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Sku { get; set; }
        public string Manufacturer { get; set; }
        public string LotNumber { get; set; }
        public DateTime? ManufacturingDate { get; set; }
    }
}
