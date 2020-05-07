using FrameworkCSharp.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkCSharp.Tests.UI
{
    public class TestChangeSettings : BaseTest
    {
        [Test]
        public void editSettingsTest()
        {
            var commonPage = Automation.Common
              .inputEmail(_settings.Email)
              .inputPassword(_settings.Password)
              .clickSubmitButton()
              .GetPage<CommonPage>();

            commonPage.clickTopMenu();
            var settings = commonPage.openSettingPage();
            settings.clickHideGiftSection();
        }
    }
}
