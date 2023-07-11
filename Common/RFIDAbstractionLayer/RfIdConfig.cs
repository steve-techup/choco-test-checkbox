using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RFIDAbstractionLayer
{
    public class RfIdConfig
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ReaderType ReaderType { get; set; }
        public string ReaderIpAddress { get; set; }
        public bool AutoRead { get; set;}
        public List<string> CachedPorts { get; set; }
    }
}