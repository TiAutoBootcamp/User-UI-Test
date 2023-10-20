using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace UITests.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver _driver;
        protected WebDriverWait _wait;

        private By _pageLoaderLocator = By.XPath("//*[@class = 'mud-progress-circular-circle mud-progress-indeterminate']");

        [FindsBy(How = How.CssSelector, Using = "[href='/login']")]
        private IWebElement _loginLink;

        [FindsBy(How = How.ClassName, Using = "mud-menu-activator")]
        private IWebElement _accountButton;

        [FindsBy(How = How.ClassName, Using = "nav-item")]
        private IList<IWebElement> _leftNavigationBarItems;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(), 'Sign Out')]")]
        private IWebElement _signOutButton;        

        [FindsBy(How = How.TagName, Using = "body")]
        protected IWebElement Body { get; set; }

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(50));
            PageFactory.InitElements(driver, this);
        }

        public void WaitPageLoading()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(_pageLoaderLocator));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public void WaitLoginLinkLoading()
        {
            _wait.Until((_) => _loginLink.Displayed); ;            
        }
        public void ClickOnSpecificPlace()
        {
            Actions actions = new Actions(_driver);
            actions.MoveByOffset(10, 10);
            actions.Click();
            actions.Perform();
        }

        public void RefreshPage()
        {
            _driver.Navigate().Refresh();
        }

        public void MoveTo(IWebElement element)
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(element).Perform();
        }

        public void MoveToAccountButton()
        {
            MoveTo(_accountButton);
        }

        public void ClickLoginLink()
        {
            _loginLink.Click();
        }

        public void ClickSignOutButton()
        {
            _wait.Until((_) => _signOutButton.Displayed);
            _signOutButton.Click();
        }

        public string GetWelcomeMessage()
        {
            RefreshPage();
            _wait.Until((_) => _accountButton.Displayed);
            return _accountButton.Text;
        }

        public List<string> GetLeftNavigationBarTextItems()
        {
            return _leftNavigationBarItems.Select(el => el.Text).ToList();
        }
    }
}
