using OpenQA.Selenium;
using System.Security.Cryptography;
using System.Xml.Serialization;

namespace FrameworkCSharp.Pages
{
    public class SearchResultPage : PageBase
    {
        public SearchResultPage(IWebDriver webDriver)
           : base(_locator, webDriver) { }

        private static readonly By _locator = By.XPath("//h1[@class='page_name']");

        private readonly By pageName = By.XPath("//h1[@class='page_name']");
        private readonly By writeMessageButton = By.XPath("//button[contains(@class, 'profile_btn_cut_left')]");
        private readonly By addFriendButton = By.XPath("//button[contains(@class, 'button_wide')]");
        private readonly By requestSentButton = By.XPath("//div[@id='friend_status']/div/span");
        private readonly By confirmActionWindow = By.XPath("//div[@class='box_title']");
        private readonly By captchaCheckBox = By.XPath("//div[@class='recaptcha-checkbox-border']");
         
        private readonly By mailBox = By.Id("mail_box_editable");
        private readonly By mailBoxSend = By.Id("mail_box_send");

        public string getPageName() => GetText(pageName);

        public string getTextButton()
        {
            WaitForElementVisible(requestSentButton);
            return GetText(requestSentButton);
        }

        public void clickAddFriendButton() => ClickElementBy(addFriendButton);

        public void clickWriteMessage() => ClickElementBy(writeMessageButton);
        public void sendMessage(string text)
        {
            WaitForElementIsClickable(mailBox);
            SendKeys(mailBox, text);
            ClickElementBy(mailBoxSend);
        }
    }
}