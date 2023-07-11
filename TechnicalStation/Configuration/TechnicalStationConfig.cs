using Caretag_Class.Configuration;
using Org.BouncyCastle.Bcpg.OpenPgp;
using RFIDAbstractionLayer;

namespace TechnicalStation.Configuration
{
    public class TechnicalStationConfig
    {
        public string StationName { get; set; }
        public TechnicalStationAppSettings AppSettings { get; set; }
        public RfIdConfig RFID { get; set; }
    }
}
