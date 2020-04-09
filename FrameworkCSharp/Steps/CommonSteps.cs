using FrameworkCSharp.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkCSharp.Steps
{
    public class CommonSteps : StepsBase
    {
        private readonly SignInPage _signInPage;

        public CommonSteps(SignInPage signInPage, IWebDriver webDriver)
            : base(signInPage, webDriver)
        {
            _signInPage = signInPage;
        }

        public CommonSteps inputEmail(string userName)
        {
            _signInPage.inputLogin(userName);
            return this;
        }

        public CommonSteps inputPassword(string password)
        {
            _signInPage.inputPassword(password);
            return this;
        }

        public CommonSteps clickSubmitButton()
        {
            _signInPage.clickLogIn();
            return this;
        }
    }
}
