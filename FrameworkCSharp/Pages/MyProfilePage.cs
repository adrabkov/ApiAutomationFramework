using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkCSharp.Pages
{
    public class MyProfilePage : PageBase
    {
        public MyProfilePage(IWebDriver webDriver)
           : base(_locator, webDriver) { }

        private static readonly By _locator = By.XPath("//div[@class='top_profile_name']");

        public string GetTextFromPost(string postId)
        {
            By postBody = By.XPath("//div[@id='wpt588855326_" + postId + "']/div");
            return GetText(postBody);
        }

        public bool PostIsDisplayed(string postId)
        {
            //IWebElement postBody = FindExistingElement(By.XPath("//div[@id='wpt588855326_" + postId + "']/div"));

            return IsElementExists(By.XPath("//div[@id='wpt588855326_" + postId + "']/div"));
        }

        public string GetTextFromComments(string commentId)
        {
            By commentBody = By.XPath("//div[@id='post588855326_" + commentId + "']//div[@class='wall_reply_text']");
            return GetText(commentBody);
        }

    }
}
