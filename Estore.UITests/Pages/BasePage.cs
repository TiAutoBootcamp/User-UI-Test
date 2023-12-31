﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace UITests.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver Driver;
        protected WebDriverWait Wait;
        public string Title { get; protected set; }

        private By _pageLoaderLocator = By.XPath("//*[@class = 'mud-progress-circular-circle mud-progress-indeterminate']");

        [FindsBy(How = How.CssSelector, Using = "[href='/login']")]
        private IWebElement _loginLink;

        [FindsBy(How = How.ClassName, Using = "mud-menu")]
        private IWebElement _accountButton;

        [FindsBy(How = How.ClassName, Using = "nav-item")]
        private IList<IWebElement> _leftNavigationBarItems;

        [FindsBy(How = How.Id, Using = "logout_button")]
        private IWebElement _signOutButton;

        [FindsBy(How = How.ClassName, Using = "mud-snackbar-content-message")]
        private IWebElement _infoMessageWindow;

        [FindsBy(How = How.CssSelector, Using = "[href='users']")]
        private IWebElement _usersNavigationButton;

        [FindsBy(How = How.ClassName, Using = "mud-list-item-gutters")]
        private IList<IWebElement> _dropdownListItems;
        
        [FindsBy(How = How.Id, Using = "orders_button")]
        private IWebElement _ordersButton;

        [FindsBy(How = How.TagName, Using = "body")]
        protected IWebElement Body { get; set; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(50));
            PageFactory.InitElements(driver, this);            
        }

        public void WaitPageLoading()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(_pageLoaderLocator));
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public bool WaitLoginLinkLoading()
        {
            return Wait.Until((_) => _loginLink.Displayed);            
        }

        public void ClickOnSpecificPlace()
        {
            Actions actions = new Actions(Driver);
            actions.MoveByOffset(10, 10);
            actions.Click();
            actions.Perform();
        }

        public void MoveTo(IWebElement element)
        {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public void MoveToAccountButton()
        {
            Wait.Until((_) => _accountButton.Displayed);
            MoveTo(_accountButton);
        }

        public void ClickLoginLink()
        {
            _loginLink.Click();
        }

        public void ClickUsersNavigationButton()
        {
            _usersNavigationButton.Click();
        }

        public void ClickSignOutButton()
        {
            Wait.Until((_) => _signOutButton.Displayed);
            _signOutButton.Click();
        }

        public string GetWelcomeMessage()
        {
            Wait.Until((_) => _accountButton.Displayed);
            return _accountButton.Text;
        }

        public List<string> GetNavigationBarTextItems()
        {
            return _leftNavigationBarItems.Select(el => el.Text).ToList();
        }

        public string GetInfoMessage()
        {
            Wait.Until ((_) => _infoMessageWindow.Displayed);
            return _infoMessageWindow.Text;
        } 
        
        public void ClickOrdersButton()
        {
            _ordersButton.Click();
        }

        public IList<string> GetButtonsInDropdownList()
        {
            return _dropdownListItems.Select(el => el.Text).ToList();
        }

        public string GetTokenFromLocalStorage()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            string customerToken = (string)js.ExecuteScript("return localStorage.getItem('jwt-access-token');");
            return customerToken.Substring(1, customerToken.Length - 2);
        }
    }
}