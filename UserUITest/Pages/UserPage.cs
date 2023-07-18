using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;


namespace UserUITest.Pages
{
    public class UserPage
    {

        protected readonly IWebDriver _driver;
        private  readonly DataContext _context;

        [FindsBy(How = How.ClassName, Using = "table")]
        private IWebElement _userTable;

        [FindsBy(How = How.Id, Using = "first_name_search")]
        private IWebElement _firstNameInput;

        [FindsBy(How = How.Id, Using = "last_name_search")]
        private IWebElement _lastNameInput;

        [FindsBy(How = How.Id, Using = "search_product")]
        private IWebElement _searchButton;

        // [FindsBy(How = How.XPath, Using = $"//td[@id='id_column' and contains(.,{_context.UserId})]")]
        [FindsBy(How = How.XPath, Using = "//td[@id='id_column' and contains(.,'182809')]")]
        private IWebElement _firstNameUserCell;

        [FindsBy(How = How.Id, Using ="//td[@id='id_column'][contains(.,'182809')]/following-sibling::*[@id='action_column']//button")]
        private IWebElement _buttonDetails;

  

        public UserPage(IWebDriver driver, DataContext context)
        {
            _driver = driver;
            _context = context;
            PageFactory.InitElements(driver, this);
        }

        public void LoadUserTable(){

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(50));
            wait.Until((_) => _userTable.Displayed);
         
        }

        public void SearchUser(string firstName, string secondName)
        {
            //_firstNameInput.SendKeys(firstName);
            _lastNameInput.SendKeys(secondName);    
            _searchButton.Click();

        }

        public void ClickDeatilsButton() { 
            _buttonDetails.Click();
        }
    }

}
