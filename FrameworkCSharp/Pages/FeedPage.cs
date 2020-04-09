using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkCSharp.Pages
{
    class FeedPage : PageBase
    {
        public FeedPage(IWebDriver webDriver)
           : base(_locator, webDriver) { }

        private static readonly By _locator = By.Id("post_field");

        private readonly By myProfileLink = By.XPath("//li[@id='l_pr']/a");

        public MyProfilePage openMyProfile() => ClickElementBy<MyProfilePage>(myProfileLink);

    }
}
