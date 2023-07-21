using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Interactions.Internal;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System.Text.RegularExpressions;

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

        [FindsBy(How = How.ClassName, Using = "bm-title")]
        private IWebElement _idField;

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
        }

        public int GetId() { 
            var tittle = _idField.Text;
            Match match = Regex.Match(tittle, @"\d+");
            return Int32.Parse(match.Value);
        }
        public string GetFirtsName()
        {
            return _firstNameField.Text ?? string.Empty;
        }

        public string GetLastName()
        {
            return _lastNameField.Text ?? string.Empty;
        }

        public bool GetStatusUser()
        {
            bool status = (_statusField.Text == "Active");
            return status;
        }

        public string GetBirthDate()
        {
           string _birthDate = _birthDateField.Text ?? string.Empty;
            return _birthDate;
        }
        public void  GetAllTheModalInformatio() {  
           _context.IdModal = GetId();
           _context.FirstNameModal = GetFirtsName();
           _context.LastNameModal = GetLastName();
           _context.StatusModal = GetStatusUser();
           _context.BirthDateModal = GetBirthDate();

        }

        public void ClickOnPrimaryCloseButton() {
            _primaryCloseButton.Click();
        }

        public void ClickOnSecondaryCloseButton()
        {
            _secondaryCloseButton.Click();
        }

        public void PressEscKey() {
            Actions actions = new Actions(_driver);
            actions.SendKeys(Keys.Escape);
            actions.Perform();
        }

        public void ClickOnSpecificPosition()
        {
            Actions actions = new Actions(_driver);
            actions.MoveByOffset(10, 10);
            actions.Click();
            actions.Perform();
        }

        public void CheckModalIsDisplayed()
        {
            try
            {
                Actions actions = new Actions(_driver);
                actions.MoveToElement(_detailsModal);
                actions.Perform();
                _context.ModalDisplayed = _detailsModal.Displayed;
      
            }
            catch (Exception e)
            {
                _context.ModalDisplayed = false;
            }

        }
    }

}