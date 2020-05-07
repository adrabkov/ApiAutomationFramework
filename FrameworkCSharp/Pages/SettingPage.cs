using OpenQA.Selenium;

namespace FrameworkCSharp.Pages
{
    public class SettingPage : PageBase
    {
        public SettingPage(IWebDriver webDriver)
           : base(_locator, webDriver) { }

        private static readonly By _locator = By.Id("ui_rmenu_general");

        private readonly By hideGiftsSection = By.XPath("//label[@for='settings_hide_gifts']");
        private readonly By settingsStatusDefault = By.XPath("//label[@for='settings_status_default']");
        private readonly By settingsWall = By.XPath("//label[@for='settings_no_wall_replies']");
        private readonly By ssettingsA11y = By.XPath("//label[@for='settings_a11y']");


        public void clickHideGiftSection() => ClickElementBy(hideGiftsSection);

    }
}