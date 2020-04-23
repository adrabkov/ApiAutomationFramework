using FrameworkCSharp.Utilities;
using OpenQA.Selenium;
using System.Threading;

namespace FrameworkCSharp.Pages
{
    public class PhotosPage : PageBase
    {
        public PhotosPage(IWebDriver webDriver)
           : base(_locator, webDriver) { }

        private static readonly By _locator = By.XPath("//div[@id='photos_albums_block']//div[@class='ui_crumb']");
        private readonly By addPhotosInput = By.XPath("//div[@id='photos_albums_block']//input");
        private readonly By spinner = By.XPath("//div[@class='ui_progress_back']");
        private readonly By photoLocator = By.XPath("//div[contains(@id, 'photo_edit_row')]");
        private readonly By deleteIcon = By.Id("delete");

        public void uploadImage()
        {
            Thread.Sleep(2000);
            UploadFile(addPhotosInput, CommonUtilities.getPath("test.jpg"));
            WaitUntilElementIsVisible(spinner, 10);
        }

        public bool downloadedPhotoIsDisplayed() {
            try
            {
                return FindVisibleElement(photoLocator).Displayed;
            }
            catch (System.Exception)
            {
                return false;
            }
        } 

        public void deletePhoto()
        {
            Move(deleteIcon);
            ClickElementBy(deleteIcon);
        }
    }
}