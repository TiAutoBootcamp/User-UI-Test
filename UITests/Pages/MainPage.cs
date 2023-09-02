using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System.Xml.Linq;
using UserUITest.Pages;

namespace UserManagementServiceUITests.Pages
{
    public class MainPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = ".content.px-4")]
        private IWebElement _elementSection;

        [FindsBy(How = How.CssSelector, Using = "[aria-label = 'press click to search']")]
        private IWebElement _searchButton;

        [FindsBy(How = How.XPath, Using = "//*[@inputmode ='text' ]")]
        private IWebElement _searchField;

        [FindsBy(How = How.XPath, Using = "//b")]
        private IList<IWebElement> _productNames;

        [FindsBy(How = How.XPath, Using = "//b/ancestor::h4/preceding-sibling::h4")]
        private IList<IWebElement> _productManufactors;
       

        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public void WaitProductsLoading()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(50));
            wait.Until((_) => _elementSection.Displayed);
        }

        public void WaitAmountOfExpectedProducts(int amount)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(50));
            wait.Until((_) => _productNames.Count == amount);
        }

        public void FillSearchField(string searchedString)
        {
            _searchField.SendKeys(Keys.LeftShift + Keys.Home);
            _searchField.SendKeys(searchedString);
        }

        public void ClickSearchButton()
        {
            //WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(50));
            //wait.Until((_) => _searchButton.Enabled);

            //DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driver);
            //fluentWait.Timeout = TimeSpan.FromSeconds(5);
            //fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            //fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            //fluentWait.Until((_) => _searchButton.Enabled);

            //Actions actions = new Actions(_driver);
            //actions.MoveToElement(_searchButton).DoubleClick().Perform();

            IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
            executor.ExecuteScript("arguments[0].click();", _searchButton);

           // _searchButton.Click();
        }

        public List<string> GetProductNamesText()
        { 
            return _productNames.Select(el => el.Text).ToList();
        }

        public List<string> GetProductManufactorsText()
        {
            return _productManufactors.Select(el => el.Text).ToList();
        }

        public bool IsSearchButtonEnabled()
        {
            return _searchButton.Enabled;
        }
    }
}
