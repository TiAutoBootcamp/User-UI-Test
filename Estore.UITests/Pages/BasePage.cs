using OpenQA.Selenium;
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

        [FindsBy(How = How.TagName, Using = "body")]
        protected IWebElement Body { get; set; }

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            PageFactory.InitElements(driver, this);
        }

        public void WaitPageLoading()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(_pageLoaderLocator));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
    }
}
