using FrameworkCSharp.Pages;
using FrameworkCSharp.Utilities;
using NUnit.Framework;

namespace FrameworkCSharp.Tests.UI
{
    public class PostTest : BaseTest
    {
           [Test]
           public void CreatePostAndGetListPostsAndFindSomePosts()
        {
            var messageForPost = CommonUtilities.GenerateRandomString(10);

            var feedPage = Automation.Common
              .inputEmail(_settings.Email)
              .inputPassword(_settings.Password)
              .clickSubmitButton()
              .GetPage<FeedPage>();

            //creating post on the wall
            var myProfile = feedPage.openMyProfile();
            myProfile.CreatePost(messageForPost);

            //check that the post with the correct text appeared on the wall
            var list = myProfile.getPostList();
            Assert.IsTrue(list.Contains(messageForPost), "post with the correct test is not displayed on the wall");

            //find all posts for the specified period
            var listMessages = myProfile.getListMessage("24");
            Assert.IsTrue(listMessages.Count != 0, "nothing found for the specified time");

        }
    }
}
