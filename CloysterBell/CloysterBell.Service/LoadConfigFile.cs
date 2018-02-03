using CloysterBell.Contract;
using Newtonsoft.Json;
using System.IO;

namespace CloysterBell.Service
{
    public class LoadConfigFile
    {
        public Config GetConfigFromFile()
        {
            using (StreamReader jsonReader = new StreamReader("Config/config.json"))
            {
                string configJson = jsonReader.ReadToEnd();
                return JsonConvert.DeserializeObject<Config>(configJson);
            }
        }
    }
}
