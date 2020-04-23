using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

namespace FrameworkCSharp.Pages
{
    public class CommunitiesPage : PageBase
    {
        public CommunitiesPage(IWebDriver webDriver)
           : base(_locator, webDriver) { }

        private static readonly By _locator = By.XPath("//li[@id='groups_groups_tab']/a");

        private readonly By SearchCommunities = By.Id("groups_list_search");
        private readonly By SearchButton = By.XPath("//button[contains(@class, 'ui_search_button_search')]");
        private readonly By ExtraSearchLink = By.XPath("//a[@class='ui_header_ext_search']");
        private readonly By OrderDropDown = By.XPath("//div[@id='sort_filter']//td[@class='selector_dropdown']");
        private readonly By DropDownItem = By.XPath("//*[contains(@id, 'option_list_options_container')][2]");
        private readonly By FilmLink = By.XPath("//div[@id='results']//div[@class='labeled title']");

        public void FillSearchCommunities(string film) => SendKeys(SearchCommunities, film);

        public void ClickSearchButton() => ClickElementBy(SearchButton);

        public void ClickExtraSearchLink() => ClickElementBy(ExtraSearchLink);

        public void ChooseOptionFromDropDown()
        {
            ClickElementBy(OrderDropDown);
            ClickElementBy(DropDownItem);
        }
        
        public GroupPage OpenGroup()
        {
            Thread.Sleep(1000);
            ReadOnlyCollection<IWebElement> sortedGroupList = FindAllElements(FilmLink);
            return ClickIWebElement<GroupPage>(sortedGroupList[0]);
        }





    }
}
