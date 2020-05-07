using OpenQA.Selenium;

namespace FrameworkCSharp.Pages
{
    public class EditInfoPage : PageBase
    {
        public EditInfoPage(IWebDriver webDriver)
           : base(_locator, webDriver) { }

        private static readonly By _locator = By.Id("profile_editor");

        private readonly By firstName = By.Id("pedit_first_name");
        private readonly By lastName = By.Id("pedit_last_name");
        private readonly By rightMenu = By.XPath("//div[@id = 'narrow_column']/div/a");

        public void openSettingsItem(int number)
        {
            var items = GetlistOfElements(rightMenu);
            ClickWebElementBy(rightMenu, items[number]);
        }

        public void EditFirstName(string name) => SendKeys(firstName, name);
        public void EditLastName(string name) => SendKeys(lastName, name);

    }
}
