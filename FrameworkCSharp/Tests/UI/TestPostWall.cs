using FrameworkCSharp.Enum;
using FrameworkCSharp.Pages;
using FrameworkCSharp.Utilities;
using NUnit.Framework;

namespace FrameworkCSharp.Tests.UI
{
    class TestPostWall : BaseTest
    {
        [Test]
        public void CreatePostOnWallAndCheckAndDelete()
        {
            string messageForWall = CommonUtilities.GenerateRandomString(20);
            string messageForComment = CommonUtilities.GenerateRandomString(10);
            var postId = apiRequests.WallPost(_settings.AccessToken, messageForWall).post_id.ToString();

            var commonPage = Automation.Common
               .inputEmail(_settings.Email)
               .inputPassword(_settings.Password)
               .clickSubmitButton()
               .GetPage<CommonPage>();

            //creating post on the wall and checking
            var myProfilePage = commonPage.openMyProfileTab((int)MenuItems.My_profile);
            var messageFromWall = myProfilePage.GetTextFromPost(postId);
            Assert.AreEqual(messageForWall, messageFromWall);

            //adding comment for post and checking
            apiRequests.CreateCommentForPost(_settings.AccessToken, postId, messageForComment);
            var messageFromComment = myProfilePage.GetTextFromComments(postId);
            Assert.AreEqual(messageFromComment, messageForComment);

            //deleting post from wall and checking
            apiRequests.DeletePost(_settings.AccessToken, postId);
            driver.Navigate().Refresh();
            Assert.IsFalse(myProfilePage.PostIsDisplayed(postId));

        }
    }
}
