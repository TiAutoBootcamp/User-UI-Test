using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UITests.Pages
{
    public class MainPage : BasePage
    {        
        [FindsBy(How = How.CssSelector, Using = ".content.px-4")]
        private IWebElement _elementSection;

        [FindsBy(How = How.CssSelector, Using = "[aria-label = 'press click to search']")]
        private IWebElement _searchButton;

        [FindsBy(How = How.XPath, Using = "//*[@inputmode ='text' ]")]
        private IWebElement _searchField;

        [FindsBy(How = How.TagName, Using = "b")]
        private IList<IWebElement> _productNames;

        [FindsBy(How = How.XPath, Using = "//b/ancestor::h4/preceding-sibling::h4")]
        private IList<IWebElement> _productManufactors;

        [FindsBy(How = How.ClassName, Using = "mud-snackbar-content-message")]
        private IWebElement _infoMessageWindow;

        [FindsBy(How = How.ClassName, Using = "me-auto")]
        private IWebElement _errorMessage;

        [FindsBy(How = How.CssSelector, Using = "[href='/login']")]
        private IWebElement _loginButton;

        [FindsBy(How = How.CssSelector, Using = "[tabindex='0']")]
        private IWebElement _accountButton;
        

        public MainPage(IWebDriver driver) : base(driver)
        {            
        }

        public void WaitProductsLoading()
        {
            _wait.Until((_) => _elementSection.Displayed);
        }

        public void WaitAmountOfExpectedProducts(int amount)
        {
            _wait.Until((_) => _productNames.Count >= amount);
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

        public void ClickLoginButton()
        {
            _loginButton.Click();
        }

        public void MoveToAccountButton()
        {
            MoveTo(_accountButton);
        }
    }
}
