using FrameworkCSharp.Pages;
using NUnit.Framework;

namespace FrameworkCSharp.Tests.UI
{
    class TestPostWall : BaseTest
    {
        [Test]
        public void CreatePostOnWallAndCheckAndDelete()
        {
            string messageForWall = customerData.GenerateRandomString(20);
            string messageForComment = customerData.GenerateRandomString(10);
            var postId = apiRequests.WallPost(customerData.access_token, messageForWall).post_id.ToString();

            var feedPage = Automation.Common
               .inputEmail(customerData.email)
               .inputPassword(customerData.password)
               .clickSubmitButton()
               .GetPage<FeedPage>();

            //creating post on the wall and checking
            var myProfilePage = feedPage.openMyProfile();
            var messageFromWall = myProfilePage.GetTextFromPost(postId);
            Assert.AreEqual(messageForWall, messageFromWall);

            //adding comment for post and checking
            apiRequests.CreateCommentForPost(customerData.access_token, postId, messageForComment);
            var messageFromComment = myProfilePage.GetTextFromComments(postId);
            Assert.AreEqual(messageFromComment, messageForComment);

            //deleting post from wall and checking
            apiRequests.DeletePost(customerData.access_token, postId);
            driver.Navigate().Refresh();
            Assert.IsFalse(myProfilePage.PostIsDisplayed(postId));

        }
    }
}
