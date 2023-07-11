using System;

namespace RFIDAbstractionLayer
{
    public class DeviceInformation
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Version { get; set; }
        public string Serial { get; set; }

        public override string ToString()
        {
            string result = "Brand: \t" + Brand + Environment.NewLine +
                            "Model: \t" + Model + Environment.NewLine +
                            "Version: \t" + Version + Environment.NewLine +
                            "Serial: \t" + Serial;

            return result;
        }

        public static DeviceInformation CreateEmpty()
        {
            return CreateEmpty("Unknown");
        }
        public static DeviceInformation CreateEmpty(string brand)
        {
            return new DeviceInformation { Brand = brand, Model = "Unknown", Serial = "Unknown", Version = "Unknown" };
        }
    }
}
