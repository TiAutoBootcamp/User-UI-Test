using Estore.CoreAdditional.Extensions;
using Estore.Models.DataModels.User;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using UITests.Pages;

namespace UserManagementServiceUITests.Pages
{
    public class CreateUserPage : BasePage
    {
        public CreateUserPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.ClassName, Using = "bm-title")]
        private IWebElement _title;

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

        [FindsBy(How = How.ClassName, Using = "mud-button-root")]
        private IWebElement _registerButton;

        [FindsBy(How = How.ClassName, Using = "bm-close")]
        private IWebElement _closeButton;

        [FindsBy(How = How.ClassName, Using = "mud-input-label")]
        private IList<IWebElement> _labels; 

        public void FillFirstNameInputField(string firstName, bool isMoveFocus = false) 
        {
            _firstNameInputField.ClickAndSendKeysViaActions(firstName);
            MoveFocus(isMoveFocus);
        }

        public void FillLastNameInputField(string lastName, bool isMoveFocus = false)
        {
            _lastNameInputField.ClickAndSendKeysViaActions(lastName);
            MoveFocus(isMoveFocus);
        }

        public void FillEmailInputField(string email, bool isMoveFocus = false)
        {
            _emailInputField.ClickAndSendKeysViaActions(email);
            MoveFocus(isMoveFocus);
        }

        public void FillPasswordInputField(string password, bool isMoveFocus = false)
        {
            _passwordInputField.ClickAndSendKeysViaActions(password);
            MoveFocus(isMoveFocus);
        }

        public void FillRepeatPasswordInputField(string password, bool isMoveFocus = false)
        {
            _repeatPasswordInputField.ClickAndSendKeysViaActions(password);
            MoveFocus(isMoveFocus);
        }

        public void FillModalWindow(UserModel user)
        {
            FillFirstNameInputField(user.MainInfo.FirstName);
            FillLastNameInputField(user.MainInfo.LastName);
            FillEmailInputField(user.Credentials.Email);
            FillPasswordInputField(user.Credentials.Password);
            FillRepeatPasswordInputField(user.Credentials.Password, true);            
        }

        public void ClickRegisterButton() 
        {
            Wait.Until((_) => _registerButton.Enabled);
            _registerButton.Click();
            Thread.Sleep(2000);
        }

        public void ClickCloseButton()
        {
            Wait.Until((_) => _closeButton.Enabled);
            _closeButton.Click();
        }

        public IList<string> GetInputFieldLabels()
        {
            return _labels.Select(el => el.Text).ToList();
        }

        public bool IsRegisterButtonDisabled()
        {
            return Wait.Until(_ => !_registerButton.Enabled);
            //return !_registerButton.Enabled;
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

        public void ClearFirstNameField(bool isMoveFocus = false)
        {
            _firstNameInputField.ClearViaActions();
            MoveFocus(isMoveFocus);            
        }

        public void ClearLastNameField(bool isMoveFocus = false)
        {
            _lastNameInputField.ClearViaActions();
            MoveFocus(isMoveFocus);
        }

        public void ClearEmailField(bool isMoveFocus = false)
        {
            _emailInputField.ClearViaActions();
            MoveFocus(isMoveFocus);
        }

        public void ClearPasswordField(bool isMoveFocus = false)
        {
            _passwordInputField.ClearViaActions();
            MoveFocus(isMoveFocus);
        }

        public void ClearRepeatPasswordField(bool isMoveFocus = false)
        {
            _repeatPasswordInputField.ClearViaActions();
            MoveFocus(isMoveFocus);
        }

        public void MoveFocus(bool isMoveFocus = false)
        {
            if (isMoveFocus)
            {
                _title.Click();
            }
        }
    }
}