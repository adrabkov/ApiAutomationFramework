using FrameworkCSharp.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using WebDriverManager.DriverConfigs.Impl;

namespace FrameworkCSharp.Driver
{
    public class DriverHolder
    {
        public static IWebDriver driver { get; set; }

        private readonly Settings _settings = CommonUtilities.GetSettings(@"..\..\..\QASettings.xml");
        private readonly object _context;

        private Uri _remoteWebDriverClusterUri;

        protected IWebDriver GetDriver()
        {
            if (_settings.Browser.Contains("remote"))
            {
                return GetRemoteDriver(_settings.Browser);
            }
            else
                return GetLocalDriver();
        }

        private IWebDriver GetLocalDriver()
        {
            if (driver == null)
            {
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                driver = new ChromeDriver();
            }

            return driver;
        }

        private IWebDriver GetRemoteDriver(string connectionString)
        {
            Uri uri = null;
            string browser = null;
            string version = null;
            var options = connectionString.Split('|');
            var caps = new Dictionary<string, string>();

            foreach (var option in options)
            {
                var optionParts = option.Split('=');

                if (optionParts.Length != 2)
                    continue;

                var opt = optionParts[0];
                var val = optionParts[1];

                switch (opt)
                {
                    case "uri":
                        uri = new Uri(val);
                        break;
                    case "browser":
                        browser = val;
                        break;
                    case "version":
                        version = val;
                        break;
                    case "capabilities":
                        if (val.Contains(","))
                        {
                            var settings = val.Split(';');

                            foreach (var setting in settings)
                            {
                                var settingParts = setting.Split(',');

                                if (settingParts.Length != 2)
                                    continue;

                                var settingKey = settingParts[0];
                                var settingValue = settingParts[1];

                                caps.Add(settingKey, settingValue);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            _remoteWebDriverClusterUri = uri;

            var capabilities = new DesiredCapabilities(browser, version, new Platform(PlatformType.Any));

            foreach (var cap in caps)
            {
                var key = cap.Key;
                var val = cap.Value;

                bool settingBool = false;
                int settingInt = -1;

                if (Boolean.TryParse(val, out settingBool))
                    capabilities.SetCapability(key, settingBool);
                else if (Int32.TryParse(val, out settingInt))
                    capabilities.SetCapability(key, settingInt);
                else
                    capabilities.SetCapability(key, val);
            }

            if (_context != null && _context is string)
                capabilities.SetCapability("name", _context);

            var driver = new RemoteWebDriver(_remoteWebDriverClusterUri, capabilities, TimeSpan.FromMinutes(10));
            driver.FileDetector = new LocalFileDetector();
            return driver;
        }

        protected void Clean()
        {
            driver.Quit();
            driver = null;
        }
    }
}
