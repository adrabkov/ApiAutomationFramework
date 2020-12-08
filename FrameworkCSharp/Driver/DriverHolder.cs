using CAD.CD.Search.TestFramework.Config;
using FrameworkCSharp;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverManager.DriverConfigs.Impl;

namespace CAD.CD.Search.TestFramework.Driver
{
    public class DriverHolder
    {
        private readonly Settings _settings = ConfigLoader.GetSettings("QASettings");
        private IWebDriver _currentWebDriver;
        private WebDriverWait _wait;

        public IWebDriver Current
        {
            get
            {
                if (_currentWebDriver == null)
                {
                    _currentWebDriver = GetWebDriver();
                }

                return _currentWebDriver;
            }
        }

        public WebDriverWait Wait
        {
            get
            {
                if (_wait == null)
                {
                    this._wait = new WebDriverWait(Current, TimeSpan.FromSeconds(20));
                }
                return _wait;
            }
        }

        private IWebDriver GetWebDriver()
        {
            string remoteAddressConfigSetting = null;
            var browserName = _settings.Browser;
            string testRemotelyConfigSetting = ConfigLoader.LoadJson("testConfig")["TestRemotely"];
            var testRemotely = testRemotelyConfigSetting == null ? false : Boolean.Parse(testRemotelyConfigSetting);

            switch (browserName)
            {

                case "Chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    if (testRemotely)
                    {
                        return new RemoteWebDriver(new Uri(remoteAddressConfigSetting), chromeOptions.ToCapabilities(), TimeSpan.FromMinutes(5));
                    }
                    else
                    {
                        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                        return new ChromeDriver();
                    }

                case "Firefox":
                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    if (testRemotely)
                    {
                        return new RemoteWebDriver(new Uri(remoteAddressConfigSetting), firefoxOptions.ToCapabilities(), TimeSpan.FromMinutes(5));
                    }
                    else
                    {
                        new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                        return new FirefoxDriver();
                    }

                default:
                    throw new NotSupportedException("not supported browser: <null>");
            }
        }

        public void Quit()
        {
            _currentWebDriver?.Quit();
        }
    }
}
