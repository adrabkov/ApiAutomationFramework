using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
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

        public IWebDriver GetRemoteDriver(DriverOptions driverOptions)
        {
            driver = new RemoteWebDriver(new Uri("http://http://192.168.150.98:4444//wd/hub"), driverOptions);
            return driver;
        }

        public void Clean()
        {
            driver.Quit();
            driver = null;
        }
    }
}
