using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using UITests.Pages;

namespace UserManagementServiceUITests.Pages
{
    public class CreateUserPage : BasePage
    {
        public CreateUserPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "first_name_input")]
        private IWebElement _firstName;

        [FindsBy(How = How.Id, Using = "last_name_input")]
        private IWebElement _lastName;

        [FindsBy(How = How.Id, Using = "birth_date_input")]
        private IWebElement _birthDate;

        [FindsBy(How = How.Id, Using = "save_button")]
        private IWebElement _saveButton;

        [FindsBy(How = How.Id, Using = "cancel_button")]
        private IWebElement _cancelButton;

        [FindsBy(How = How.ClassName, Using = ".size-medium")]
        private IWebElement _createUserModal;

        public void SetFirstName(string firstName) 
        {
            _firstName.SendKeys(firstName);
        }

        public void SetLastName(string lastName)
        {
            _lastName.SendKeys(lastName);
        }

        public void SetNameOnModal(string firstName, string lastName) 
        { 
            SetFirstName(firstName); 
            SetLastName(lastName);
        }

        public void SetBirthDate(string birthDate)
        {
            _birthDate.SendKeys(birthDate);
        }

        public void ClickSaveButton() 
        {
            _saveButton.Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            wait.Until(_ => Body.GetAttribute("style").Contains("overflow: auto"));
        }

        public void ClickCancelButton() 
        {
            _cancelButton.Click();
        }

        public bool CheckModalIsOpen() 
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
