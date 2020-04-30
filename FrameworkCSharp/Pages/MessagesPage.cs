using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FrameworkCSharp.Pages
{
    public class MessagesPage : PageBase
    {
        public MessagesPage(IWebDriver webDriver)
           : base(_locator, webDriver) { }

        private static readonly By _locator = By.Id("ui_rmenu_all");

        private readonly By searchField = By.Id("#im_dialogs_search");
        private readonly By listMessage = By.XPath("//ul[@id='im_dialogs']/li");

        public WriteMessagePage OpenDialog(string name)
        {
            List<IWebElement> friend = new List<IWebElement>();
            var list = GetlistOfElements(listMessage);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Text.Contains(name))
                {
                    friend.Add(list[i]);
                    break;
                }
                else
                    throw new Exception("User with this name not found");
            }
            return ClickIWebElement<WriteMessagePage>(friend[0]);
        } 
    }
}
