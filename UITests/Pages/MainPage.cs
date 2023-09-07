using Core.Extentions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using UserUITest.Pages;

namespace UserManagementServiceUITests.Pages
{
    public class MainPage : BasePage
    {
        private WebDriverWait _wait;

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

        [FindsBy(How = How.ClassName, Using = "mud-snackbar-content-message")]
        private IWebElement _infoMessageWindow;

        [FindsBy(How = How.ClassName, Using = "me-auto")]
        private IWebElement _errorMessage;

        [FindsBy(How = How.ClassName, Using = "mud-progress-circular-svg")]
        private IWebElement _pageLoader;

        private By _pageLoaderLocator = By.ClassName("mud-progress-circular-svg");

        public MainPage(IWebDriver driver) : base(driver)
        {
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
        }

        public void WaitProductsLoading()
        {
            _wait.Until((_) => _elementSection.Displayed);
        }

        public void WaitPageLoading()
        {
            // _wait.Until((_) => !_pageLoader.Displayed);
            //_wait.Until(ExpectedConditions.InvisibilityOfElementLocated(_pageLoaderLocator));
            //_wait.Until(ExpectedConditions.StalenessOf(_pageLoader));
            _wait.WaitUntilElementDisappears(_pageLoaderLocator);
        }

        public void WaitAmountOfExpectedProducts(int amount)
        {
            _wait.Until((_) => _productNames.Count == amount);
        }

        public void FillSearchField(string searchedString)
        {
            _searchField.SendKeys(Keys.LeftShift + Keys.Home);
            _searchField.SendKeys(searchedString);
        }

        public void ClickSearchButton()
        {
            _searchButton.Click();
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

        public string GetInfoMessage()
        {
            return _infoMessageWindow.Text;
        }

        public string GetErrorMessage()
        {
            return _errorMessage.Text;
        }
    }
}
