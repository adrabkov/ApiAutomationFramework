using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkCSharp.Pages
{
    public class GroupPage : PageBase
    {
        public GroupPage(IWebDriver webDriver)
           : base(_locator, webDriver) { }

        private static readonly By _locator = By.XPath("//div[@id='public']/div[@class='page_block']");

        private readonly By filmName = By.XPath("//div[@class='page_top']/h1");
        private readonly By followButton = By.Id("page_actions_btn");

        public string getFilmName() => GetText(filmName);

        public void clickFollowButton() => ClickElementBy(followButton);




    }
}
