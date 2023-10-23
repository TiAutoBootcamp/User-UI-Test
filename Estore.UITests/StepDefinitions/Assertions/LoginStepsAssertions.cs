using NUnit.Framework;
using TechTalk.SpecFlow;
using UITests.Context;

namespace Estore.UITests.StepDefinitions.Assertions
{
    [Binding]
    public class LoginStepsAssertions
    {
        private readonly DataContext _context;

        public LoginStepsAssertions(DataContext context)
        {
            _context = context;
        }

        [Then(@"All elements are displayed correctly for the admin role")]
        public void ThenAllElementsAreDisplayedCorrectlyForTheAdminRole()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(_context.WelcomeMessage, _context.CurrentPage.GetWelcomeMessage());
            });
        }

        [Then(@"All elements are displayed correctly for the unauthorized view")]
        public void ThenAllElementsAreDisplayedCorrectlyForTheUnauthorizedView()
        {
            Assert.Multiple(() =>
            {
                
            });
        }

        [Then(@"All elements are displayed correctly for the customer role")]
        public void ThenAllElementsAreDisplayedCorrectlyForTheCustomerRole()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(_context.WelcomeMessage, _context.CurrentPage.GetWelcomeMessage());
            });
        }


        [Then(@"Login page is closed")]
        public void ThenLoginPageIsClosed()
        {
            Assert.AreNotEqual("Login", _context.Driver.Title);
        }

        [Then(@"Login button is not clickable")]
        public void ThenLoginButtonIsNotClickable()
        {
            Assert.IsTrue(_context.LoginPage.IsLoginButtonNotClickable());
        }

        [Then(@"Welcome message is correct")]
        public void ThenWelcomeMessageIsCorrect()
        {
            var expectedWelcomMessage = _context.CurrentUser.Credentials.Role == Models.Enum.UserRole.Admin
                ? _context.WelcomeMessage = $"Welcome, {_context.CurrentUser.Credentials.Email}! (Admin)"
                : _context.WelcomeMessage = $"Welcome, {_context.CurrentUser.MainInfo.FirstName} " +
                $"{_context.CurrentUser.MainInfo.LastName}! (Customer)";

            Assert.AreEqual(expectedWelcomMessage, _context.CurrentPage.GetWelcomeMessage());
        }

        [Then(@"Login button is displayed")]
        public void ThenLoginButtonIsDisplayed()
        {
            Assert.IsTrue(_context.CurrentPage.WaitLoginLinkLoading());
        }

        [Then(@"Navigation bar has next (.*)")]
        public void ThenNavigationBarHasNext(string itemNames)
        {
            var expectedItems = itemNames.Split(" - ").ToArray();
            CollectionAssert.AreEquivalent(expectedItems, _context.CurrentPage.GetNavigationBarTextItems());
        }

        [Then(@"A prompt message '([^']*)' is presented")]
        public void ThenAPromptMessageIsPresented(string message)
        {
            var actualMessage = _context.LoginPage.GetPromtMessage();
            Assert.AreEqual(message, actualMessage);
        }

        [When(@"User fills (.*) and (.*) field")]
        public void WhenUserFillsFields(string email, string password)
        {
            throw new PendingStepException();
        }
    }
}
