using FrameworkCSharp.Pages;
using NUnit.Framework;

namespace FrameworkCSharp.Tests.UI
{
    public class TestSendFriendRequest : BaseTest
    {
        [Test]
        public void FindFriendAndSendFriendRequest()
        {
            string nameFriend = "Drabkov";
            var commonPage = Automation.Common
                .inputEmail(_settings.Email)
                .inputPassword(_settings.Password)
                .clickSubmitButton()
                .GetPage<CommonPage>();

            commonPage.inputSearchText(nameFriend);
            var friendsPage = commonPage.openSearchResultPage();
            Assert.IsTrue(friendsPage.getPageName().Contains(nameFriend), "");
            friendsPage.clickAddFriendButton();
            Assert.AreEqual(friendsPage.getTextButton(), "Request sent", "Request is not sent");
        }
    }
}
