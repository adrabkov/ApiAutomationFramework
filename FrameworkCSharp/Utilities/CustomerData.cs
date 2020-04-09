using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkCSharp.Utilities
{
    public class CustomerData
    {
        public static readonly string URL = "https://vk.com/";
        public static readonly string ApiUrl = "https://api.vk.com/method/";
        public static readonly string AuthUrl = "https://oauth.vk.com/access_token?";
        public readonly string email = "375257542569";
        public readonly string password = "qwaszx@1";
        public readonly int userId = 48747902;
        public readonly string access_token = "62893ecf1b57a25b4c8e7e644dc498515dc05581927229baea5940cdf40a097454f69dbf3a1759d911da9";
        public static readonly string appId = "7374459";
        public static readonly string SecureKey = "Kllf3cqNXCCoharDKweH";

        public string GenerateRandomString(int size)
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
