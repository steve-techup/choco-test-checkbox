using System.Globalization;
using System.Text.Json.Serialization;

namespace OnScreenKeyboard.Models
{
    public class OnScreenKeyboardConfig
    {
        [JsonPropertyName("AutoHideDelayInMsec")]
        public int AutoHideDelayInMsec { get; set; }

        [JsonPropertyName("Enabled")]
        public bool Enabled { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("ToolButtonVisibility")]
        public ToolButtonVisibility ToolButtonVisibility { get; set; }

        [JsonPropertyName("Culture")]
        public CultureInfo Culture { get; set; }

        public OnScreenKeyboardConfig()
        {
            Enabled = false;
            AutoHideDelayInMsec = 1000;
            ToolButtonVisibility = ToolButtonVisibility.Always;
        }
    }
}