using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using UITests.Pages;
using static System.Net.Mime.MediaTypeNames;

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

        [FindsBy(How = How.ClassName, Using = "mud-input-helper-text")]
        private IList<IWebElement> _inputHelper;
        
        private By _loginButtonLocator = By.CssSelector("[type='button']");

        public LoginPage(IWebDriver driver) : base(driver)
        {
            Title = "Login";
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

        public void FillEmailAndPasswordFields(string email, string password)
        {
            FillEmailField(email);
            FillPasswordField(password);
        }

        public void ClickLoginButton()
        {
            ClickOnSpecificPlace();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_loginButton)).Click();
            _wait.Until(driver => !driver.Url.Contains("/login"));
        }

        public bool IsLoginButtonNotClickable()
        {
            return !_loginButton.Enabled;
        }

        public List<string> GetPromtMessage()
        {
            ClickOnSpecificPlace();
            return _inputHelper.Select(el => el.Text).ToList();
        }
    }
}
