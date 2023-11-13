using Estore.Models.Enum;
using NUnit.Framework;
using TechTalk.SpecFlow;
using UITests.Context;

namespace Estore.UITests.StepDefinitions.Assertions
{
    [Binding]
    public class CommonStepsAssertions
    {
        private readonly DataContext _context;

        public CommonStepsAssertions(DataContext context)
        {
            _context = context;
        }

        [Then(@"Info message '(.*)' is presented")]
        public void InfoMessageIsPresented(string infoMessage)
        {
            Assert.AreEqual(infoMessage, _context.CurrentPage.GetInfoMessage(), "Info messages are not equal");
        }

        [Then(@"Login button is displayed")]
        public void LoginButtonIsDisplayed()
        {
            Assert.IsTrue(_context.CurrentPage.WaitLoginLinkLoading(),
                "Login button is not displayed");
        }

        [Then(@"Navigation bar has next items called")]
        public void NavigationBarHasNextItems(IList<string> itemNames)
        {
            CollectionAssert.AreEquivalent(itemNames, _context.CurrentPage.GetNavigationBarTextItems(),
                "Navigation bar doesn't contain all requaired items");
        }

        [Then(@"Welcome message is correct")]
        public void WelcomeMessageIsCorrect()
        {
            var expectedWelcomMessage = _context.CurrentUser.Credentials.Role == UserRole.Admin
                ? $"Welcome, {_context.CurrentUser.Credentials.Email} (Admin)"
                : $"Welcome, {_context.CurrentUser.MainInfo.FirstName} {_context.CurrentUser.MainInfo.LastName} (Customer)";

            Assert.AreEqual(expectedWelcomMessage, _context.CurrentPage.GetWelcomeMessage(),
                "Welcome message is not correct");
        }
    }
}