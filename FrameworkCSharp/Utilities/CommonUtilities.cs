using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using IO = System.IO;

namespace FrameworkCSharp.Utilities
{
    public class CommonUtilities
    {
        public static Settings GetSettings(string path)
        {
            var serializer = new XmlSerializer(typeof(Settings));
            using (IO.FileStream settingsStream = new IO.FileStream(path, IO.FileMode.Open))
            {
                return (Settings)serializer.Deserialize(settingsStream);
            }
        }

        public static string getPath(string fileName) => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
        


    }
}
