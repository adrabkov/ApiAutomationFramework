using FrameworkCSharp.Enum;
using FrameworkCSharp.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkCSharp.Tests.UI
{
    class TestCommunities : BaseTest
    {
        [Test]
        public void addCommunitiesAndCheck()
        {
            var feedPage = Automation.Common
              .inputEmail(customerData.email)
              .inputPassword(customerData.password)
              .clickSubmitButton()
              .GetPage<FeedPage>();

            var myProfile = feedPage.openMyProfile();
            myProfile.openCommunitiesTab((int)MenuItems.Communities);

        }
    }
}
