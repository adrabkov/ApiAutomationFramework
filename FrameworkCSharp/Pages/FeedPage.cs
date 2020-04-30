using FrameworkCSharp.Enum;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkCSharp.Pages
{
    public class FeedPage : PageBase
    {
        public FeedPage(IWebDriver webDriver)
           : base(_locator, webDriver) { }

        private static readonly By _locator = By.Id("post_field");

        private readonly By myProfileLink = By.XPath("//div[@id='side_bar_inner']//li[1]");



    }
}
