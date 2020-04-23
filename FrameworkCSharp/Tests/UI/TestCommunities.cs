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
            var feedPage = Automation.Common
              .inputEmail(customerData.email)
              .inputPassword(customerData.password)
              .clickSubmitButton()
              .GetPage<FeedPage>();

            var myProfile = feedPage.openMyProfile();
            var communities = myProfile.openCommunitiesTab((int)MenuItems.Communities);

            //Find the most popular film group
            communities.FillSearchCommunities("film");
            communities.ClickSearchButton();
            communities.ClickExtraSearchLink();
            communities.ChooseOptionFromDropDown();

            //open found group
            var groupPage = communities.OpenGroup();
            var expectedFilmName = groupPage.getFilmName();
            groupPage.clickFollowButton();
            feedPage.openMyProfile();

            //check added group is present on the main page
            Assert.IsTrue(myProfile.FollowingListIsContains(expectedFilmName));
            




        }
    }
}
