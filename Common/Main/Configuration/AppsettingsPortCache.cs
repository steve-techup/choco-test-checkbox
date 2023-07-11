using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFIDAbstractionLayer;

namespace Caretag_Class.Configuration
{
    public class AppsettingsPortCache : IPortCache
    {
        private readonly AppSettingsBase _appSettingsBase;
        private readonly ConfigurationWriter _configurationWriter;

        public AppsettingsPortCache(AppSettingsBase appSettingsBase, ConfigurationWriter configurationWriter)
        {
            _appSettingsBase = appSettingsBase;
            _configurationWriter = configurationWriter;
        }

        public void SavePorts(List<string> ports)
        {
            _configurationWriter.UpdateConfigurationFile("appsettings.json", "RFID.CachedPorts", ports);
        }

        public List<string> LoadPorts()
        {
            return _appSettingsBase?.RFID.CachedPorts ?? new List<string>();
        }
    }
}
