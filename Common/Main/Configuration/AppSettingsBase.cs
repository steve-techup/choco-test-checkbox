using RFIDAbstractionLayer;

namespace Caretag_Class.Configuration
{
    public class ConnectionStrings
    {
        public string SQLServer { get; set; }
    }

    public class AppSettingsBase
    {
        public string UILanguage { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
        public RfIdConfig RFID { get; set; }
        public string StationUniqueID { get; set; } //Used to be 'ReaderID' - uniquely defines the local install for use in logfiles. 
        public string VendorName { get; set; }
        public bool ApplySqlMigrations { get; set; }
    }
}
