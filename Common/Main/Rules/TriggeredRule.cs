using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caretag_Class.Rules
{
    public record TriggeredRule
    {
        public string EPC { get; set; }
        public int Cycles { get; set; }
        public int MaintenanceInterval { get; set; }
        public string RuleDescription { get; set; }
        public long RuleId { get; set; }
        public string InstrumentSKU { get; set; }
        public DateTime? MaintenancePeriodStart { get; set; }
        public bool AlreadySentToService { get; set; }
    }
}
