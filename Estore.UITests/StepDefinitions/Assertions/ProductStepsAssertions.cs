using CoreAdditional.Models;
using NUnit.Framework;
using TechTalk.SpecFlow;
using UITests.Context;

namespace Estore.UITests.StepDefinitions.Assertions
{
    [Binding]
    public class ProductStepsAssertions
    {
        private readonly DataContext _context;

        public ProductStepsAssertions(DataContext context)
        {
            _context = context;
        }

        [StepDefinition(@"Products with a certain data are displayed on the page")]
        [StepDefinition(@"The product with a certain data is displayed on the page")]
        public void ProductsWithACertainDataAreDisplayedOnThePage(List<ProductModel> productsInfo)
        {
            _context.MainPage.WaitPageLoading();
            var actualNames = _context.MainPage.GetProductNamesText();
            var actualManufactors = _context.MainPage.GetProductManufactorsText();

            Assert.Multiple(() =>
            {
                CollectionAssert.IsSubsetOf(productsInfo.Select(product => product.Name).ToList(), actualNames);
                CollectionAssert.IsSubsetOf(productsInfo.Select(product => product.Manufactor).ToList(), actualManufactors);
            });
        }

        [Then(@"One created product is existed others not")]
        [Then(@"Some created product are existed one not")]
        public void CreatedProductExistSomeNot(List<ProductModel> productsInfo)
        {
            _context.MainPage.WaitPageLoading();
            var actualNames = _context.MainPage.GetProductNamesText();
            var actualManufactors = _context.MainPage.GetProductManufactorsText();

            Assert.Multiple(() =>
            {
                CollectionAssert.IsSubsetOf(productsInfo
                    .Where(el => el.IsPresented.Equals(true))
                    .Select(product => product.Name)
                    .ToList(), actualNames);
                CollectionAssert.IsSubsetOf(productsInfo
                    .Where(el => el.IsPresented.Equals(true))
                    .Select(product => product.Manufactor)
                    .ToList(), actualManufactors);
                CollectionAssert.IsNotSubsetOf(productsInfo
                    .Where(el => el.IsPresented.Equals(false))
                    .Select(product => product.Name)
                    .ToList(), actualNames);
                CollectionAssert.IsNotSubsetOf(productsInfo
                    .Where(el => el.IsPresented.Equals(false))
                    .Select(product => product.Manufactor)
                    .ToList(), actualManufactors);
            });
        }

        [Then(@"Search button is disabled")]
        public void SearchButtonIsDisabled()
        {
            Assert.IsFalse(_context.MainPage.IsSearchButtonEnabled());
        }
        
        [Then(@"The order of products on the main page are correct")]
        public void TheOrderOfProductsOnTheMainPageAreCorrect()
        {
            _context.MainPage.WaitPageLoading();
            var expectedList = _context.ProductRequestsAndStatuses
                .OrderByDescending(status => status.Item2)
                .ThenBy(request => request.Item1.Article);

            //Can work unstably. It's better to use APi call to get actualList
            var actualNames = _context.MainPage.GetProductNamesText();
            CollectionAssert.AreEqual(actualNames, expectedList.Select(el => el.Item1.Name).ToList());
        }

        [Then(@"Error message '([^']*)' is presented")]
        public void ErrorMessageIsPresented(string errorMessage)
        {
            Assert.AreEqual(errorMessage, _context.MainPage.GetErrorMessage());
        }

        [Then(@"Image source is the same as the (added|new added|default) image")]
        public void ImageSourceIsSameAsAddedOrDefault(string image)
        {
            string expectedImageSource;
            if (image.Equals("default"))
            {
                expectedImageSource = "https://estore-uat.azurewebsites.net/images/no-image-icon.jpeg";
                Assert.AreEqual(expectedImageSource, _context.MainPage.GetImageSource(_context.ProductRequest));
            }
            else if (image.Equals("added") || image.Equals("new added"))
            {
                expectedImageSource = $"data:image/jpg;base64,{Convert.ToBase64String(_context.CurrentProductImage)}";
                Assert.AreEqual(expectedImageSource, _context.MainPage.GetImageSource(_context.ProductRequest));
            }
            else
            {
                throw new ArgumentException("An unknown value is set for the image");
            }            
        }
    }
}
