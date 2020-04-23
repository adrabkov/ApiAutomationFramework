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

        private static readonly By _locator = By.XPath("//h1[@class='page_name']");
        private readonly By postField = By.Id("post_field");
        private readonly By sendPost = By.Id("send_post");
        private readonly By photoLink = By.XPath(string.Format("//div[@id='side_bar_inner']//li{0}/a", MenuItems.Photos));
        private readonly By PostsList = By.XPath("//div[@class='_post_content']//div[contains(@class,'wall_post_text')]");
        private readonly By ItemsMenu = By.XPath("//div[@id='side_bar_inner']//li");
        private readonly By FollowingGroups = By.XPath("//div[contains(@class, 'module_body')]");


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
            WaitForElementIsClickable(postField);
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
                string priceText = text.FindElement(By.XPath("//div[contains(@class,'wall_post_text')]")).Text;
                listWithTextPost.Add(priceText);
            }
            return listWithTextPost;
            }

        public string getListMessage(string time)
        {
            ScrollDownPage();
            List<string> listWithMessages = new List<string>();
            ReadOnlyCollection<IWebElement> productList = FindAllElements(PostsList);
            
            for (int i = 1; i <= productList.Count; i++)
            {
                if (FindExistingElement(By.XPath("//div[@id][" + i + "]/div[@class='_post_content']//div[@class='post_date']/a/span")).Text.Contains(time))
                {

                    var message = FindExistingElement(By.XPath("//div[@id][" + i + "]/div[@class='_post_content']//div[@class='wall_text']/div/div")).Text;

                    listWithMessages.Add(message);
                }
            }
            return listWithMessages[0];
        }

        public CommunitiesPage openCommunitiesTab(int menu) => ClickIWebElement<CommunitiesPage>(listOfMenuItems(ItemsMenu)[menu]);

        public PhotosPage openPhotosTab(int menu) => ClickIWebElement<PhotosPage>(listOfMenuItems(ItemsMenu)[menu]);

        public bool FollowingListIsContains(string filmName)
        {
            bool result = false;
            for (int i = 0; i < listOfMenuItems(FollowingGroups).Count; i++)
            {
                if (listOfMenuItems(FollowingGroups)[i].Text.Contains(filmName))
                {
                    result=true;
                    break;
                }
                else
                    result =false;
            }
            return result;
        }

        private ReadOnlyCollection<IWebElement> listOfMenuItems(By by)
        {
            WaitForElementIsVisible(by, 10);
            ReadOnlyCollection<IWebElement> menu = FindAllElements(by);
            return menu;
        }


    }
}
