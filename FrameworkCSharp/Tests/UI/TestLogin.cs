using FrameworkCSharp.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkCSharp.Tests.UI
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class TestLogin : BaseTest
    {
        [Test]
        public void successfulLoginAndLogOutTest()
        {
            var commonPage = Automation.Common
                .inputEmail(_settings.Email)
                .inputPassword(_settings.Password)
                .clickSubmitButton()
                .GetPage<CommonPage>();

            Assert.IsTrue(commonPage.ProfileNameIsDisplayed(), "");

            commonPage.clickTopMenu();
            var loginPage = commonPage.clickLogOutButton();
            Assert.IsTrue(loginPage.loginButtonIsDisplayed(), "");
        }
    }
}
