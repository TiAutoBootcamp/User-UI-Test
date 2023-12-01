using Estore.Models.Request.Catalog;
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

        [FindsBy(How = How.ClassName, Using = "me-auto")]
        private IWebElement _errorMessage;

        [FindsBy(How = How.ClassName, Using = "mud-grid-item")]
        private IList<IWebElement > _products;
                
        private By _productImage = By.TagName("img");

        private By _productName = By.TagName("b");

        private By _productManufactor = By.XPath("//b/ancestor::h4/preceding-sibling::h4");

        public MainPage(IWebDriver driver) : base(driver)
        {
            Title = "Estore";
            Wait.Until(d => d.Title == Title);
        }

        public void WaitProductsLoading()
        {            
            Wait.Until((_) => _elementSection.Displayed);
        }

        public void WaitSeachFieldDisplayed()
        {
            Wait.Until((_) => _searchField.Displayed);
        }

        public void WaitAmountOfExpectedProducts(int amount)
        {
            Wait.Until((_) => _productNames.Count >= amount);
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

        public string GetErrorMessage()
        {
            return _errorMessage.Text;
        }

        public bool IsProductDisplayed(AddProductRequest createdProduct)
        {
            return Wait.Until(_ =>
            {
                try
                {
                    return _products.Any(product =>
                        product.FindElement(_productName).Text.Contains(createdProduct.Name) &&
                        product.FindElement(_productManufactor).Text.Contains(createdProduct.Manufactor));
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            });
        }

        public string GetImageSource(AddProductRequest createdProduct)
        {
            return _products
                .Where(product =>
                    product.FindElement(_productName).Text.Contains(createdProduct.Name) &&
                    product.FindElement(_productManufactor).Text.Contains(createdProduct.Manufactor))
                .Select(product => product.FindElement(_productImage).GetAttribute("src"))
                .Single();            
        }
    }
}
