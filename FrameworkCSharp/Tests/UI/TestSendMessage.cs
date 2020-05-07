using FrameworkCSharp.Enum;
using FrameworkCSharp.Pages;
using FrameworkCSharp.Utilities;
using NUnit.Framework;

namespace FrameworkCSharp.Tests.UI
{
    public class TestSendMessage : BaseTest
    {
        [Test]
        public void SendMessage()
        {
            string textMessage = CommonUtilities.GenerateRandomString(15);
            var commonPage = Automation.Common
                .inputEmail(_settings.Email)
                .inputPassword(_settings.Password)
                .clickSubmitButton()
                .GetPage<CommonPage>();

            var messages = commonPage.openMessageTab();

            var writeMessage = messages.OpenDialog("Drabkov");
            writeMessage.InputMessage(textMessage);
            Assert.IsTrue(writeMessage.IsMessageSent(textMessage), "Message is not send");
        }

        [Test]
        public void SendMessageWithAttachment()
        {
            string textMessage = CommonUtilities.GenerateRandomString(15);
            var commonPage = Automation.Common
                .inputEmail(_settings.Email)
                .inputPassword(_settings.Password)
                .clickSubmitButton()
                .GetPage<CommonPage>();

            var messages = commonPage.openMessageTab();
            var writeMessage = messages.OpenDialog("Drabkov");
            writeMessage.InputMessage(textMessage);
            writeMessage.addAttachment();
            writeMessage.ClickSendButton();
            Assert.IsTrue(writeMessage.IsMessageSent(textMessage), "Message is not send");
        }
    }
}
