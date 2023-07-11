using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caretag_Class.Configuration
{
    public class ConfigurationWriter
    {
        public void UpdateConfigurationFile<T>(string filepath, string jsonpath, T value)
        {
            var appSettingsPath = Path.Combine(Directory.GetCurrentDirectory(), filepath);
            var json = File.ReadAllText(appSettingsPath);
            var obj = JObject.Parse(json);
            var token = obj.SelectToken(jsonpath);
            if (token == null && value != null)
            {
                var newObj = CreateObjectForPath(jsonpath, value);
                obj.Merge(newObj);
            }
            else if (token != null && value == null)
                token.Remove();
            else if (token != null)
                token.Replace(JToken.FromObject(value));
            //Else branch would be token == null && value == null, which would mean no change, so we don't include it

            File.WriteAllText(appSettingsPath,obj.ToString());
        }

        private JObject CreateObjectForPath(string target, object newValue)
        {
            var json = new StringBuilder();

            json.Append(@"{");

            var paths = target.Split('.');

            var i = -1;
            var objCount = 0;

            foreach (var path in paths)
            {
                i++;

                if (paths[i] == "$") continue;

                json.Append('"');
                json.Append(path);
                json.Append('"');
                json.Append(": ");

                if (i + 1 == paths.Length) continue;
                json.Append("{");
                objCount++;
            }

            if (newValue is IEnumerable)
                json.Append(JArray.FromObject(newValue));
            else
                json.Append(JObject.FromObject(newValue));

            for (int level = 1; level <= objCount; level++)
            {
                json.Append(@"}");
            }

            json.Append(@"}");
            var jsonString = json.ToString();
            var obj = JObject.Parse(jsonString);
            return obj;
        }
    }
}
