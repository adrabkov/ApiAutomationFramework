using FrameworkCSharp.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;

namespace FrameworkCSharp.Driver
{
    public class DriverHolder
    {
        public static IWebDriver driver { get; set; }

        public IWebDriver GetInstance()
        {
            if (driver == null)
            {
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                driver = new ChromeDriver();
            }

            return driver;
        }

        public void Clean()
        {
            driver.Quit();
            driver = null;
        }
    }
}
