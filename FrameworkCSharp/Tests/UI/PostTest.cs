using FrameworkCSharp.Pages;
using NUnit.Framework;

namespace FrameworkCSharp.Tests.UI
{
    class PostTest : BaseTest
    {
           [Test]
           public void CreatePostAndGetListPostsAndFindSomePosts()
        {
            var messageForPost = customerData.GenerateRandomString(10);

            var feedPage = Automation.Common
              .inputEmail(customerData.email)
              .inputPassword(customerData.password)
              .clickSubmitButton()
              .GetPage<FeedPage>();

            //creating post on the wall
            var myProfile = feedPage.openMyProfile();
            myProfile.CreatePost(messageForPost);

            //check that the post with the correct text appeared on the wall
            var list = myProfile.getPostList();
            Assert.AreEqual(messageForPost, list[0], "post with the correct test is not displayed on the wall");

            //find all posts for the specified period
            myProfile.getListMessage("yesterday");
        }
    }
}
