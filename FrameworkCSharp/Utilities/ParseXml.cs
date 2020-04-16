using System.Xml.Serialization;
using IO = System.IO;

namespace FrameworkCSharp.Utilities
{
    public class ParseXml
    {
        public static Settings GetSettings(string path)
        {
            var serializer = new XmlSerializer(typeof(Settings));
            using (System.IO.FileStream settingsStream = new IO.FileStream(path, IO.FileMode.Open))
            {
                return (Settings)serializer.Deserialize(settingsStream);
            }
        }
    }
}
