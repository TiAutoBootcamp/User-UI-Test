using UITests.TestData;
using TechTalk.SpecFlow;
using UITests.Context;

namespace Estore.UITests.StepDefinitions
{
    [Binding]
    public sealed class UserSteps
    {
        private readonly DataContext _context;

        public UserSteps(DataContext context)
        {
            _context = context;
        }

        [Given(@"User search product by '(.*)'")]
        [When(@"User search product by '(.*)'")]
        public void WhenUserSearchProductBy(string searchedString)
        {
            switch (searchedString)
            {
                case "Article":
                    _context.MainPage.FillSearchField(_context.ProductRequest.Article);
                    break;
                case "Name":
                    _context.MainPage.FillSearchField(_context.ProductRequest.Name);
                    break;
                case "Manufactor":
                    _context.MainPage.FillSearchField(_context.ProductRequest.Manufactor);
                    break;
                case "":
                    return;
                case "Long string":
                    _context.MainPage.FillSearchField(TestCasesData.LongString);
                    return;
                default:
                    _context.MainPage.FillSearchField(searchedString);
                    break;
            }
            _context.MainPage.ClickSearchButton();
        }
    }
}