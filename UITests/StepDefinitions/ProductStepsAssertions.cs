using CatalogServiceAPI.Models.StepsModels;
using NUnit.Framework;

namespace UserManagementServiceUITests.StepDefinitions
{
    [Binding]
    public class ProductStepsAssertions
    {
        private readonly DataContext _context;

        public ProductStepsAssertions(DataContext context)
        {
            _context = context;
        }

        [Then(@"The product with a certain data is displayed on the page")]
        public void ThenTheProductWithACertainDataIsDisplayedOnThePage(List<ProductModel> productsInfo)
        {
                _context.MainPage.WaitAmountOfExpectedProducts(productsInfo.Count);
                var actualNames = _context.MainPage.GetProductNamesText();
                var actualManufactors = _context.MainPage.GetProductManufactorsText();
                Assert.IsTrue(productsInfo.Count == actualNames.Count);
                Assert.Multiple(() =>
                {
                    CollectionAssert.AreEqual(actualNames, productsInfo.Select(product => product.Name).ToList());
                    CollectionAssert.AreEqual(actualManufactors, productsInfo.Select(product => product.Manufactor).ToList());
                });
        }

        [Then(@"Search button is disabled")]
        public void ThenSearchButtonIsDisabled()
        {
            Assert.IsFalse(_context.MainPage.IsSearchButtonEnabled());
        }


        [Then(@"Error message '([^']*)' is presented")]
        public void ThenErrorMessageIsPresented(string errorMessage)
        {
           // Assert.IsTrue(errorMessage.Equals());
        }

    }
}
