using System;
using System.IO;
using System.Reflection;
using System.Text;
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

        public static string GenerateRandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                //Генерируем число являющееся латинским символом в юникоде
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                //Конструируем строку со случайно сгенерированными символами
                builder.Append(ch);
            }
            return builder.ToString();
        }

    }
}
