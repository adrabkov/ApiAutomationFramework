using FrameworkCSharp.Utilities;
using FrameworkCSharp.Utilities.API;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkCSharp.Tests.API
{
    class test : BaseTest
    {
        [Test]
        public void CreateCommentForPost()
        {
            //string token = VkApi.VK_GetServerToken(customerData.appId, customerData.SecureKey);
            //apiUtilities.WallPost(token, customerData.GenerateRandomString(15));
        }

        [Test]
        public void GetUserNameById()
        {
            var id = apiRequests.DeleteFriend(customerData.access_token, 210700286);
        }

    }
}
