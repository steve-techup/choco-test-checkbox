using Caretag_Class.Configuration;

namespace PackingStation.Configuration
{
    public class PackingStationAppSettings
    {
        public bool KeepLines { get; set; }
        public bool EnableSound { get; set; }
        public string LabelName { get; set; }
        public PackingStationFeatures Features { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
    }
}
