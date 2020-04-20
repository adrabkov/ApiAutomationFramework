using FrameworkCSharp.Enum;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FrameworkCSharp.Pages
{
    public class MyProfilePage : PageBase
    {
        public MyProfilePage(IWebDriver webDriver)
           : base(_locator, webDriver) { }

        private static readonly By _locator = By.XPath("//div[@class='top_profile_name']");
        private readonly By postField = By.Id("post_field");
        private readonly By sendPost = By.Id("send_post");
        private readonly By photoLink = By.XPath(string.Format("//div[@id='side_bar_inner']//li{0}/a", MenuItems.Photos));
        private readonly By PostsList = By.XPath("//div[@class='_post_content']//div[contains(@class,'wall_post_text')]");


        public string GetTextFromPost(string postId)
        {
            By postBody = By.XPath("//div[@id='wpt588855326_" + postId + "']/div");
            return GetText(postBody);
        }

        public bool PostIsDisplayed(string postId)
        {

            return IsElementExists(By.XPath("//div[@id='wpt588855326_" + postId + "']/div"));
        }

        public string GetTextFromComments(string commentId)
        {
            By commentBody = By.XPath("//div[@id='post588855326_" + commentId + "']//div[@class='wall_reply_text']");
            return GetText(commentBody);
        }

        public void CreatePost(string messagesForPost)
        {
            ClickElementBy(postField);
            SendKeys(postField, messagesForPost);
            ClickElementBy(sendPost);
        }

        public List<string> getPostList()
        {
            ScrollDownPage();
            ReadOnlyCollection<IWebElement> productList = FindAllElements(PostsList);
            List<string> listWithTextPost = new List<string>();

            foreach (IWebElement text in productList)
            {
                string priceText = text.Text;
                listWithTextPost.Add(priceText);
            }
            return listWithTextPost;
            }



    }
}
