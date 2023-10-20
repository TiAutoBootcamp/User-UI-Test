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
    }
}
