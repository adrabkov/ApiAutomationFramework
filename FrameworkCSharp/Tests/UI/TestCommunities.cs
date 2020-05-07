using FrameworkCSharp.Enum;
using FrameworkCSharp.Pages;
using NUnit.Framework;

namespace FrameworkCSharp.Tests.UI
{
    class TestCommunities : BaseTest
    {
        [Test]
        public void addCommunitiesAndCheck()
        {
            var commonPage = Automation.Common
              .inputEmail(_settings.Email)
              .inputPassword(_settings.Password)
              .clickSubmitButton()
              .GetPage<CommonPage>();

            var communities = commonPage.openCommunitiesTab();

            //Find the most popular film group
            communities.FillSearchCommunities("film");
            communities.ClickSearchButton();
            communities.ClickExtraSearchLink();
            communities.ChooseOptionFromDropDown();

            //open found group
            var groupPage = communities.OpenGroup();
            var expectedFilmName = groupPage.getFilmName();
            groupPage.clickFollowButton();
            var myProfile = commonPage.openMyProfileTab();

            //check added group is present on the main page
            Assert.IsTrue(myProfile.FollowingListIsContains(expectedFilmName));
            




        }
    }
}
