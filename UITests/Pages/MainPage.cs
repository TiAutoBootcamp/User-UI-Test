using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using UserUITest.Pages;

namespace UserManagementServiceUITests.Pages
{
    public class MainPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "[aria-label = 'press click to search']")]
        private IWebElement _searchButton;

        [FindsBy(How = How.TagName, Using = "inputmode")]
        private IWebElement _searchField;

        [FindsBy(How = How.ClassName, Using = "product")]
        private IWebElement _product;
        

        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public void WaitProductsLoading()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(50));
            wait.Until((_) => _searchButton.Displayed);
        }

        public void FillSearchField(string searchedString)
        {
            _searchField.SendKeys(searchedString);
        }

        public void ClickSearchButton()
        {
            _searchButton.Click();
        }
    }
}
