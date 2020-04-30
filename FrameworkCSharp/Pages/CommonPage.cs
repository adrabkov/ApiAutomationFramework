using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FrameworkCSharp.Pages
{
    public class CommonPage : PageBase
    {
        public CommonPage(IWebDriver webDriver)
           : base(_locator, webDriver) { }

        private static readonly By _locator = By.Id("ts_input");

        private readonly By searchField = By.Id("ts_input");
        private readonly By friendPage = By.XPath("//a[contains(@class, 'ts_contact')]");
        private readonly By ItemsMenu = By.XPath("//div[@id='side_bar_inner']//li");


        public void inputSearchText(string name)
        {
            ClickElementBy(searchField);
            SendKeys(searchField, name);
        }

        public SearchResultPage openSearchResultPage()
        {
            var list = GetlistOfElements(friendPage);
            return ClickIWebElement<SearchResultPage>(list[0]);
        }

        public MyProfilePage openMyProfileTab(int menu) => ClickIWebElement<MyProfilePage>(listOfMenuItems(ItemsMenu)[menu]);
        public CommunitiesPage openCommunitiesTab(int menu) => ClickIWebElement<CommunitiesPage>(listOfMenuItems(ItemsMenu)[menu]);

        public PhotosPage openPhotosTab(int menu) => ClickIWebElement<PhotosPage>(listOfMenuItems(ItemsMenu)[menu]);

        public MessagesPage openMessageTab(int menu) => ClickIWebElement<MessagesPage>(listOfMenuItems(ItemsMenu)[menu]);

        public FriendsPage openFriendTab(int menu) => ClickIWebElement<FriendsPage>(listOfMenuItems(ItemsMenu)[menu]);




        private ReadOnlyCollection<IWebElement> listOfMenuItems(By by)
        {
            WaitForElementIsVisible(by, 10);
            ReadOnlyCollection<IWebElement> menu = FindAllElements(by);
            return menu;
        }

    }
}
