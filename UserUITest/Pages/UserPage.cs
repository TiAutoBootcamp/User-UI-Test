using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;


namespace UserUITest.Pages
{
    public class UserPage:BasePage
    {

       

        [FindsBy(How = How.ClassName, Using = "table")]
        private IWebElement _userTable;

        [FindsBy(How = How.Id, Using = "first_name_search")]
        private IWebElement _firstNameInput;

        [FindsBy(How = How.Id, Using = "last_name_search")]
        private IWebElement _lastNameInput;

        [FindsBy(How = How.Id, Using = "search_product")]
        private IWebElement _searchButton;

        // [FindsBy(How = How.XPath, Using = $"//td[@id='id_column' and contains(.,{_context.UserId})]")]
       // [FindsBy(How = How.XPath, Using = "//td[@id='id_column' and contains(.,'182809')]")]
       // private IWebElement _firstNameUserCell;

        [FindsBy(How = How.XPath, Using = "//*[@id='action_column']//button")]
        private IWebElement _buttonDetails;

        [FindsBy(How = How.ClassName, Using = "blazored-modal")]
        private IWebElement _detailsModal;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'First name:')]")]
        private IWebElement _firstNameField;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Last name:')]")]
        private IWebElement _lastNameField;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Status:')]")]
        private IWebElement _statusField; 

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Birth date:')]")]
        private IWebElement _birthDateField;
        public UserPage(IWebDriver driver, DataContext context):base(driver,context)
        {
            
        }

        public void LoadUserTable(){

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

        public void Check 
    }

}
