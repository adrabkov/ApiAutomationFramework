using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkCSharp.Pages
{
    public class SignInPage : PageBase
    {
        public SignInPage(IWebDriver webDriver)
            : base(_locator, webDriver) { }

        private static readonly By _locator = By.Id("index_login_button");
        private readonly By loginField = By.Id("index_email");
        private readonly By passwordField = By.Id("index_pass");
        private readonly By submitButton = By.Id("index_login_button");

        public void inputLogin(string email) => SendKeys(loginField, email);

        public void inputPassword(string password) => SendKeys(passwordField, password);

        public void clickSign() => Click(submitButton);

        public MyProfilePage clickLogIn() => ClickElementBy<MyProfilePage>(submitButton);



    }
}
