using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckboxStation.Services.Bridge
{
    public class BulkRequest
    {
        public string[] TagIDs { get; set; }
        public int AppInstanceId { get; set; }
        public DateTime Date { get; set; }
        public int TotalCount { get; set; }
    }
}
