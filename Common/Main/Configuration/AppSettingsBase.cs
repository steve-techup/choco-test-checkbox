using OnScreenKeyboard.Models;
using RFIDAbstractionLayer;
using System.Globalization;

namespace Caretag_Class.Configuration
{
    public class ConnectionStrings
    {
        public string SQLServer { get; set; }
    }
    public class AppDataConfig
    {
        public string AppInstanceId { get; set; }
    }

    public class AppSettingsBase
    {
        public string UILanguage { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
        public RfIdConfig RFID { get; set; }
        public string StationUniqueID { get; set; } //Used to be 'ReaderID' - uniquely defines the local install for use in logfiles. 
        public bool ApplySqlMigrations { get; set; }
        public bool UseApi { get; set; } = true;
        public string ApiUrl { get; set; }
        public AppDataConfig AppData { get; set; }
        public int DefaultTrayAssetTypeId { get; set; }
        public int DefaultContainerAssetTypeId { get; set; }
        public int DefaultTrolleyAssetTypeId { get; set; }
        public int DefaultSterilizationCartAssetTypeId { get; set; }
        public OnScreenKeyboardConfig OnScreenKeyboardConfig { get; set; }
    }
}
