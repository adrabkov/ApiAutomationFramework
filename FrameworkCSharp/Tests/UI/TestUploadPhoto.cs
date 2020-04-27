using FrameworkCSharp.Enum;
using FrameworkCSharp.Pages;
using NUnit.Framework;

namespace FrameworkCSharp.Tests.UI
{
    class TestUploadPhoto : BaseTest
    {
        [Test]
        public void uploadPhotoAndCheck()
        {
            var myProfile = Automation.Common
              .inputEmail(customerData.email)
              .inputPassword(customerData.password)
              .clickSubmitButton()
              .GetPage<FeedPage>()
              .openMyProfile();

            //upload photo
            var photos = myProfile.openPhotosTab((int)MenuItems.Photos);
            photos.uploadImage();

            //checking the foto is displayed
            var photoIsDisplayed = photos.downloadedPhotoIsDisplayed();
            Assert.IsTrue(photoIsDisplayed);

            //delete photo
            photos.deletePhoto();
            driver.Navigate().Refresh();

            //checking photo is not displayed

            Assert.IsFalse(photos.downloadedPhotoIsDisplayed());
        }
    }
}
