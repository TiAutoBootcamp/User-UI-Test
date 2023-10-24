using Estore.Models.DataModels.User;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using UITests.Pages;

namespace UserManagementServiceUITests.Pages
{
    public class CreateUserPage : BasePage
    {
        public CreateUserPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "add_user_button")]
        private IWebElement _addUserButton;

        [FindsBy(How = How.XPath, Using = "//label[contains(.,'First name')]")]
        private IWebElement _firstNameInputField;

        [FindsBy(How = How.XPath, Using = "//label[contains(.,'Last name')]")]
        private IWebElement _lastNameInputField;

        [FindsBy(How = How.XPath, Using = "//label[contains(.,'Email')]")]
        private IWebElement _emailInputField;

        [FindsBy(How = How.XPath, Using = "//label[contains(.,'Password')]")]
        private IList<IWebElement> _passwordInputFields;

        [FindsBy(How = How.ClassName, Using = ".me-auto")]
        private IList<IWebElement> _inputHelperText;

        [FindsBy(How = How.Id, Using = "birth_date_input")]
        private IWebElement _birthDate;

        [FindsBy(How = How.Id, Using = ".mud-button-label")]
        private IWebElement _registerButton;

        [FindsBy(How = How.Id, Using = ".bm-close")]
        private IWebElement _cancelButton;

        [FindsBy(How = How.ClassName, Using = ".blazored-modal")]
        private IWebElement _createUserModal;

        public void FillFirstNameInputField(string firstName) 
        {
            _firstNameInputField.Click();
            _firstNameInputField.SendKeys(firstName);
        }

        public void FillLastNameInputField(string lastName)
        {
            _lastNameInputField.Click();
            _lastNameInputField.SendKeys(lastName);
        }

        public void FillEmailInputField(string email)
        {
            _emailInputField.Click();
            _emailInputField.SendKeys(email);
        }

        public void FillPasswordInputField(string password)
        {
            _passwordInputFields.First().Click();
            _passwordInputFields.First().SendKeys(password);
        }

        public void FillRepeatPasswordInputField(string password)
        {
            _passwordInputFields.Last().Click();
            _passwordInputFields.Last().SendKeys(password);
        }

        public void FillModalWindowAndClickRegisterButton(string firstName, string lastName, string email, 
            string password, string? repeatPassword) 
        {
            FillFirstNameInputField(firstName);
            FillLastNameInputField(lastName);
            FillEmailInputField(email);
            FillPasswordInputField(password);
            FillRepeatPasswordInputField(repeatPassword ?? password);
            ClickRegisterButton();
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
            _registerButton.Click();
            Wait.Until(_ => Body.GetAttribute("style").Contains("overflow: auto"));
        }

        public void ClickCancelButton() 
        {
            _cancelButton.Click();
        }

        public void ClickAddUserButton()
        {
            _addUserButton.Click();
        }

        public bool CreateUserModalIsOpen() 
        {
            try
            {
                return _createUserModal.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
