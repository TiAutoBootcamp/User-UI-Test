using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using UITests.Pages;

namespace Estore.UITests.Pages
{
    public class LoginPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "input[type = 'text']")]
        private IWebElement _emailInputField;

        [FindsBy(How = How.CssSelector, Using = "input[type = 'password']")]
        private IWebElement _passwordInputField;

        [FindsBy(How = How.CssSelector, Using = "[type='button']")]
        private IWebElement _loginButton;        

        public LoginPage(IWebDriver driver) : base(driver)
        {
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
            _loginButton.Click();
        }
    }
}
