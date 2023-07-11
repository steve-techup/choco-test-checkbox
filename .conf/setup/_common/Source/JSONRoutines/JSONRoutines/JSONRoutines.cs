using System.Collections.Generic;
using System.Runtime.InteropServices;
using RGiesecke.DllExport;
using System.IO;
using System.Security.Policy;
using TinyJson;

namespace JSONRoutines
{
    public class JSONRoutines
    {
        private static void ReplaceToken(string path, Dictionary<string, object> json, string value)
        {
            if (path.Contains(".")) //Continue descent
            {
                ReplaceToken(path.Split('.')[1], (Dictionary<string, object>)json[path.Split('.')[0]], value);
            }
            else
            {
                json[path] = value;
            }
        }

        [DllExport("ReplaceJSONValue", CallingConvention = CallingConvention.StdCall)]
        public static void ReplaceJSONValue([MarshalAs(UnmanagedType.LPWStr)] string filename, [MarshalAs(UnmanagedType.LPWStr)] string JSONPath, [MarshalAs(UnmanagedType.LPWStr)] string newValue)
        {
            try
            {
                // Init variables
                var json = File.ReadAllText(filename);

                var updated = ReplaceToken(json, JSONPath, newValue);

                // Save file
                File.WriteAllText(filename, updated);
            }
            catch
            {
            }
        }

        public static string ReplaceToken(string json, string JSONPath, string newValue)
        {
            var config = (Dictionary<string, object>)JSONParser.FromJson<object>(json);

            // Update value
            ReplaceToken(JSONPath, config, newValue);

            return config.ToJson();
        }
    }
}
