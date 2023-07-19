using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using static TechTalk.SpecFlow.Configuration.AppConfig.GeneratorConfigElement;


namespace UserUITest.Pages
{
    public class UserPage : BasePage
    {



        [FindsBy(How = How.ClassName, Using = "table")]
        private IWebElement _userTable;

        [FindsBy(How = How.Id, Using = "first_name_search")]
        private IWebElement _firstNameInput;

        [FindsBy(How = How.Id, Using = "last_name_search")]
        private IWebElement _lastNameInput;

        [FindsBy(How = How.Id, Using = "search_product")]
        private IWebElement _searchButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='action_column']//button")]
        private IWebElement _buttonDetails;

        [FindsBy(How = How.ClassName, Using = "blazored-modal")]
        private IWebElement _detailsModal;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'First name:')]/following-sibling::*")]
        private IWebElement _firstNameField;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Last name:')]/following-sibling::*")]
        private IWebElement _lastNameField;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Status:')]/following-sibling::*")]
        private IWebElement _statusField;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Birth date:')]/following-sibling::*")]
        private IWebElement _birthDateField;

        [FindsBy(How = How.ClassName, Using = "bm-close")]
        private IWebElement _primaryCloseButton;

        [FindsBy(How = How.ClassName, Using = "btn-secondary")]
        private IWebElement _secondaryCloseButton;
        public UserPage(IWebDriver driver, DataContext context) : base(driver, context)
        {

        }

        public void LoadUserTable() {

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(50));
            wait.Until((_) => _userTable.Displayed);

        }

        public void SearchUser(string firstName, string secondName)
        {
            _firstNameInput.SendKeys(firstName);
            _lastNameInput.SendKeys(secondName);

        }

        public void ClickSearchButton() {
            _searchButton.Click();
        }

        public void ClickDeatilsButton() {
            _buttonDetails.Click();
        }

        public void DetailsModalDisplayed() {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(_detailsModal);
            actions.Perform();
            _context.ModalDisplayed = _detailsModal.Displayed;
            //return _context.ModalDisplayed;
        }

        public string GetFirtsName()
        {
            return _firstNameField.Text;
        }

        public string GetLastName()
        {
            return _lastNameField.Text;
        }

        public bool GetStatusUser()
        {
            bool status = (_statusField.Text == "Active");
            return status;
        }

        public string GetBirthDate()
        {
            return _birthDateField.Text;
        }
        public void GetAllTheModalInformatio() {
           // _context.UserModalInformation.BirthDate = GetBirthDate();
            _context.BirthDayUser = GetBirthDate();
          // _context.UserModalInformation.FirstName = GetFirtsName();
          // _context.UserModalInformation.LastName = GetLastName();
          // _context.UserModalInformation.Status = GetStatusUser();
            
        }

        public void ClickOnPrimaryCloseButton() {
            _primaryCloseButton.Click();
        }

        public void ClickOnSecondaryCloseButton()
        {
            _secondaryCloseButton.Click();
            _context.ModalDisplayed = _detailsModal.Enabled;
        }
    }

}
