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
            var commonPage = Automation.Common
              .inputEmail(_settings.Email)
              .inputPassword(_settings.Password)
              .clickSubmitButton()
              .GetPage<CommonPage>();

            //upload photo
            var photos = commonPage.openPhotosTab();
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
