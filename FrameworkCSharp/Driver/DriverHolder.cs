using FrameworkCSharp.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;

namespace FrameworkCSharp.Driver
{
    class DriverHolder
    {
        public static IWebDriver driver { get; set; }

        public DriverHolder()
        {
            driver = GetInstance();
        }

        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                driver = new ChromeDriver();
            }

            return driver;
        }

        public static void Clean()
        {
            driver.Quit();
            driver = null;
        }
    }
}
