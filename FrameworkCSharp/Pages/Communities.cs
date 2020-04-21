using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkCSharp.Pages
{
    public class Communities : PageBase
    {
        public Communities(IWebDriver webDriver)
           : base(_locator, webDriver) { }

        private static readonly By _locator = By.XPath("//li[@id='groups_groups_tab']/a");


    }
}
