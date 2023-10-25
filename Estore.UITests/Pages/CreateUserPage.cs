using Estore.Models.DataModels.User;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using UITests.Pages;

namespace UserManagementServiceUITests.Pages
{
    public class CreateUserPage : BasePage
    {
        public CreateUserPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//label[contains(.,'First name')]/preceding-sibling::div")]
        private IWebElement _firstNameInputField;

        [FindsBy(How = How.XPath, Using = "//label[contains(.,'First name')]/parent::div/following-sibling::div")]
        private IWebElement _firstNameHelpMessage;

        [FindsBy(How = How.XPath, Using = "//label[contains(.,'Last name')]/preceding-sibling::div")]
        private IWebElement _lastNameInputField;

        [FindsBy(How = How.XPath, Using = "//label[contains(.,'Last name')]/parent::div/following-sibling::div")]
        private IWebElement _lastNameHelpMessage;

        [FindsBy(How = How.XPath, Using = "//label[contains(.,'Email')]/preceding-sibling::div")]
        private IWebElement _emailInputField;

        [FindsBy(How = How.XPath, Using = "//label[contains(.,'Email')]/parent::div/following-sibling::div")]
        private IWebElement _emailHelpMessage;

        [FindsBy(How = How.XPath, Using = "(//label[contains(.,'Password')])[1]/preceding-sibling::div/parent::div")]
        private IWebElement _passwordInputField;

        [FindsBy(How = How.XPath, Using = "(//label[contains(.,'Password')]/parent::div/following-sibling::div)[1]")]
        private IWebElement _passwordHelpMessage;

        [FindsBy(How = How.XPath, Using = "(//label[contains(.,'Password')])[2]/preceding-sibling::div")]
        private IWebElement _repeatPasswordInputField;

        [FindsBy(How = How.XPath, Using = "(//label[contains(.,'Password')]/parent::div/following-sibling::div)[2]")]
        private IWebElement _repetPasswordHelpMessage;

        [FindsBy(How = How.Id, Using = "birth_date_input")]
        private IWebElement _birthDate;

        [FindsBy(How = How.ClassName, Using = "mud-button-root")]
        private IWebElement _registerButton;

        [FindsBy(How = How.ClassName, Using = "bm-close")]
        private IWebElement _closeButton;

        [FindsBy(How = How.ClassName, Using = "mud-input-label")]
        private IList<IWebElement> _labels; 

        public void FillFirstNameInputField(string firstName) 
        {
            _firstNameInputField.Click();
            Actions actions = new Actions(Driver);
            if (!string.IsNullOrEmpty(firstName))
            {
                actions.SendKeys(firstName).Perform();
            }
            actions.SendKeys(Keys.Tab).Perform();
        }

        public void FillLastNameInputField(string lastName)
        {
            _lastNameInputField.Click();
            Actions actions = new Actions(Driver);
            if (!string.IsNullOrEmpty(lastName))
            {
                actions.SendKeys(lastName).Perform();
            }
            actions.SendKeys(Keys.Tab).Perform();
        }

        public void FillEmailInputField(string email)
        {
            _emailInputField.Click();
            Actions actions = new Actions(Driver);
            if (!string.IsNullOrEmpty(email))
            {
                actions.SendKeys(email).Perform();
            }
            actions.SendKeys(Keys.Tab).Perform();
        }

        public void FillPasswordInputField(string password)
        {
            _passwordInputField.Click();
            Actions actions = new Actions(Driver);
            if (!string.IsNullOrEmpty(password))
            {
                actions.SendKeys(password).Perform();                
            }
            actions.SendKeys(Keys.Tab).Perform();                       
        }

        public void FillRepeatPasswordInputField(string password)
        {
            _repeatPasswordInputField.Click();
            Actions actions = new Actions(Driver);
            if (!string.IsNullOrEmpty(password))
            {
                actions.SendKeys(password).Perform();
            }
            actions.SendKeys(Keys.Tab).Perform();
        }

        public void FillModalWindowAndClickRegisterButton(UserModel user)
        {
            FillFirstNameInputField(user.MainInfo.FirstName);
            FillLastNameInputField(user.MainInfo.LastName);
            FillEmailInputField(user.Credentials.Email);
            FillPasswordInputField(user.Credentials.Password);
            FillRepeatPasswordInputField(user.Credentials.Password);
            ClickRegisterButton();
        }

        public void FillBirthDateInputField(string birthDate)
        {
            _birthDate.SendKeys(birthDate);
        }

        public void ClickRegisterButton() 
        {
            Wait.Until((_) => _registerButton.Enabled);
            _registerButton.Click();
        }

        public void ClickCloseButton()
        {
            Wait.Until((_) => _closeButton.Displayed);
            _closeButton.Click();
        }

        public IList<string> GetInputFieldLabels()
        {
            return _labels.Select(el => el.Text).ToList();
        }

        public bool IsRegisterButtonNotClickable()
        {
            return !_registerButton.Enabled;
        }

        public string GetFirstNameHelpMessage()
        {
            return _firstNameHelpMessage.Text;
        }

        public string GetLastNameHelpMessage()
        {
            return _lastNameHelpMessage.Text;
        }

        public string GetEmailHelpMessage()
        {
            return _emailHelpMessage.Text;
        }

        public string GetPasswordHelpMessage()
        {
            return _passwordHelpMessage.Text;
        }

        public string GetRepeatPasswordHelpMessage()
        {
            return _repetPasswordHelpMessage.Text;
        }
    }
}
