using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalStation.Configuration
{
    public class TechnicalStationAppSettings
    {
        public bool AccessPasswordEnabled { get; set; }
        public bool? ResetEnabled { get; set; }
        public int MinimumStrength { get; set; }
        public int NextInternalId { get; set; }
    }
}
