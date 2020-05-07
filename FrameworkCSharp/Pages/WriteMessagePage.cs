using FrameworkCSharp.Utilities;
using OpenQA.Selenium;

namespace FrameworkCSharp.Pages
{
    public class WriteMessagePage : PageBase
    {
        public WriteMessagePage(IWebDriver webDriver)
           : base(_locator, webDriver) { }

        private static readonly By _locator = By.Id("im_editable0");
        private readonly By sendButton = By.XPath("//button[contains(@class, 'im-send-btn_send')]");
        private readonly By listMessages = By.XPath("//div[contains(@class, 'im-mess--text')]");
        private readonly By moreItemsLabel = By.XPath("//span[@class='ms_item_more_label']");
        private readonly By addPhoto = By.XPath("//a[@class='ms_item ms_item_photo _type_photo']");
        private readonly By choosePhotoPopUp = By.XPath("//div[@class='box_title']");
        private readonly By addFileInput = By.XPath("//input[@id='choose_doc_upload']");
        private readonly By addPhotoInput = By.XPath("//input[@id='choose_photo_upload']");
        private readonly By progressBar = By.Name("ui_progress_bar");

        public void InputMessage(string text) => SendKeys(_locator, text);

        public void ClickSendButton()
        {
            WaitForElementIsClickable(sendButton);
            ClickElementBy(sendButton);
        }

        public bool IsMessageSent(string text)
        {
            bool result=false;
            var list = GetlistOfElements(listMessages);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Text.Equals(text))
                {
                    result = true;
                    break;
                }
                else
                    result = false;
            }
            return result;
        }

        public void addAttachment()
        {
            ClickElementBy(moreItemsLabel);
            ClickElementBy(addPhoto);
            WaitForElementVisible(choosePhotoPopUp);
            UploadFile(addPhotoInput, CommonUtilities.getPath("test.jpg"));
        }
    }
}