﻿using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using UITests.Pages;

namespace Estore.UITests.Pages
{
    public class LoginPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "input[type = 'email']")]
        private IWebElement _emailInputField;

        [FindsBy(How = How.CssSelector, Using = "input[type = 'password']")]
        private IWebElement _passwordInputField;

        [FindsBy(How = How.CssSelector, Using = "button[type='button']")]
        private IWebElement _loginButton;

        [FindsBy(How = How.XPath, Using = "//input[@type='email']/parent::div/parent::div/following-sibling::div/p")]
        private IWebElement _errorEmailMessage;

        [FindsBy(How = How.XPath, Using = "//input[@type='password']/parent::div/parent::div/following-sibling::div/p")]
        private IWebElement _errorPasswordMessage;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            Title = "Estore - Login";
            Wait.Until(d => d.Title == Title);
        }

        public bool LoginPageIsClosed()
        {
            return Wait.Until(d => d.Title != Title);
        }

        public void FillEmailField(string email)
        {
            _emailInputField.Click();
            _emailInputField.SendKeys(email);
        }

        public void FillPasswordField(string password)
        {
            _passwordInputField.Click();
            _passwordInputField.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(_loginButton)).Click();
        }

        public void FillEmailAndPasswordFields(string email, string password)
        {
            FillEmailField(email);
            FillPasswordField(password);
        }       

        public void FillEmailAndPasswordFieldsAndClickLoginButton(string email, string password)
        {
            FillEmailField(email);
            FillPasswordField(password);
            ClickLoginButton();
        }

        public bool IsLoginButtonDisabled()
        {
            return !_loginButton.Enabled;
        }

        public string GetErrorEmailMessage()
        {
            return _errorEmailMessage.Text;
        }

        public string GetErrorPasswordMessage()
        {
            ClickOnSpecificPlace();
            return _errorPasswordMessage.Text;
        }
    }
}