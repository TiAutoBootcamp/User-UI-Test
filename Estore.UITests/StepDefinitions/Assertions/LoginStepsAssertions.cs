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
        public void LoginPageIsClosed()
        {
            Assert.IsTrue(_context.LoginPage.LoginPageIsClosed(),
                "Login page is not closed");
        }

        [Then(@"Login button is disabled")]
        public void LoginButtonIsDisabled()
        {
            Assert.IsTrue(_context.LoginPage.IsLoginButtonDisabled(),
                "LoginButtonIsEnabled");
        }        

        [Then(@"A help message '([^']*)' for '([^']*)' field is presented")]
        public void AHelpMessageIsPresented(string message, string fieldName)
        {
            switch (fieldName)
            {
                case "email":
                    Assert.AreEqual(message, _context.LoginPage.GetErrorEmailMessage(),
                        "Help message is not correct");
                    break;
                case "password":
                    Assert.AreEqual(message, _context.LoginPage.GetErrorPasswordMessage(),
                        "Help message is not correct");
                    break;
                default:
                    Assert.Fail("Unknown field name");                    
                    break;
            }            
        }
    }
}