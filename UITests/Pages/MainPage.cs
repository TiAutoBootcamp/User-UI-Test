using Core.Extentions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System.Diagnostics;

namespace UITests.Pages
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

        private By _pageLoaderLocator = By.XPath("//*[@class = 'mud-progress-circular-circle mud-progress-indeterminate']");
        // private By _pageLoaderLocator2 = By.TagName("circle");

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
            // var _wait2 = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            // _wait.Until((_) => !_pageLoader.Displayed);
            //_wait2.Until(ExpectedConditions.InvisibilityOfElementLocated(_pageLoaderLocator));
            //_wait.Until(ExpectedConditions.StalenessOf(_pageLoader));
            //_wait.WaitUntilElementDisappears(_pageLoaderLocator);
            //_wait.Until(driver => driver.FindElements(_pageLoaderLocator).Count() == 0);

            //var sw_className = new Stopwatch();
            //sw_className.Start();
            //var pageLoader = _driver.FindElement(_pageLoaderLocator);
            //var elapsed = sw_className.Elapsed;
            //sw_className.Stop();

            //var sw_className = new Stopwatch();
            //sw_className.Start();
            //var pageLoader = _driver.FindElements(_pageLoaderLocator);
            //var elapsed = sw_className.Elapsed;
            //sw_className.Stop();

            // _pageLoader.WaitForElementToBeInvisible();

            bool isRun = true;

            var dict = new Dictionary<TimeSpan, int>();

            var sw = new Stopwatch();

            sw.Start();



            while (isRun)

                do
                {

                    var count = _driver.FindElements(_pageLoaderLocator).Count();

                    dict.Add(sw.Elapsed, count);

                    Thread.Sleep(new TimeSpan(0, 0, 0, 0, 20));

                    if (sw.Elapsed.Seconds > 10)

                    {

                        isRun = false;

                        sw.Stop();

                    }

                }
                while (isRun);

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
