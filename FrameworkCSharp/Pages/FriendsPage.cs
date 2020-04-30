using OpenQA.Selenium;

namespace FrameworkCSharp.Pages
{
    public class FriendsPage : PageBase
    {
        public FriendsPage(IWebDriver webDriver)
           : base(_locator, webDriver) { }

        private static readonly By _locator = By.Id("#friends_import_header");
        private readonly By searchFriendField = By.Id("search_query");

    }
}