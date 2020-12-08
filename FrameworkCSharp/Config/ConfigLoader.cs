using FrameworkCSharp;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using IO = System.IO;

namespace CAD.CD.Search.TestFramework.Config
{
    class ConfigLoader
    {
        public static dynamic LoadJson(string configName)
        {
            var dirPath = Assembly.GetExecutingAssembly().Location;
            dirPath = Path.GetDirectoryName(dirPath);
            using (StreamReader r = new StreamReader(dirPath + "/Config/" + configName + ".json"))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject(json);
            }
        }

        public static Settings GetSettings(string fileName)
        {
            var dirPath = Assembly.GetExecutingAssembly().Location;
            dirPath = Path.GetDirectoryName(dirPath);
            var serializer = new XmlSerializer(typeof(Settings));
            using (IO.FileStream settingsStream = new IO.FileStream(dirPath + "/" + fileName + ".xml", IO.FileMode.Open))
            {
                return (Settings)serializer.Deserialize(settingsStream);
            }
        }
    }
}
