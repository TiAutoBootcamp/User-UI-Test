using Estore.Models.Enum;
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
            var expectedWelcomMessage = _context.CurrentUser.Credentials.Role == UserRole.Admin
                ? $"Welcome, {_context.CurrentUser.Credentials.Email}! (Admin)"
                : $"Welcome, {_context.CurrentUser.MainInfo.FirstName} {_context.CurrentUser.MainInfo.LastName}! (Customer)";

            Assert.AreEqual(expectedWelcomMessage, _context.CurrentPage.GetWelcomeMessage());
        }

        [Then(@"Login button is displayed")]
        public void ThenLoginButtonIsDisplayed()
        {
            Assert.IsTrue(_context.CurrentPage.WaitLoginLinkLoading());
        }

        [Then(@"Navigation bar has next items called (.*)")]
        public void ThenNavigationBarHasNextItems(string names)
        {
            var expectedItems = names.Split(" - ").ToArray();
            CollectionAssert.AreEquivalent(expectedItems, _context.CurrentPage.GetNavigationBarTextItems());
        }

        [Then(@"A prompt message '([^']*)' for '([^']*)' field is presented")]
        public void ThenAPromptMessageIsPresented(string message, string fieldName)
        {
            switch (fieldName)
            {
                case "email":
                    Assert.AreEqual(message, _context.LoginPage.GetErrorEmailMessage());
                    break;
                case "password":
                    Assert.AreEqual(message, _context.LoginPage.GetErrorPasswordMessage());
                    break;
                default:
                    Assert.Fail("Unknown field name");                    
                    break;
            }            
        }
    }
}
