using System;
using System.IO;
using System.Reflection;
using System.Text;


namespace FrameworkCSharp.Utilities
{
    public class CommonUtilities
    {
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
