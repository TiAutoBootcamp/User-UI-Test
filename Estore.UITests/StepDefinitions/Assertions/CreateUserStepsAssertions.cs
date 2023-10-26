using NUnit.Framework;
using TechTalk.SpecFlow;
using UITests.Context;

namespace Estore.UITests.StepDefinitions.Assertions
{
    [Binding]
    public class CreateUserStepsAssertions
    {
        private readonly DataContext _context;

        public CreateUserStepsAssertions(DataContext context)
        {
            _context = context;
        }        

        [Then(@"Create user modal window contains fields:")]
        public void CreateUserModalWindowContainsFields(IList<string> fieldNames)
        {
            CollectionAssert.AreEquivalent(fieldNames, _context.CreateUser.GetInputFieldLabels(),
                "Create modal window doesn't contain all requaired fields");
        }

        [Then(@"Register button should be disabled")]
        public void RegisterButtonShouldBeDisabled()
        {
            Assert.IsTrue(_context.CreateUser.IsRegisterButtonDisabled(),
                "Register button is enabled");
        }

        [Then(@"Help message under ""(.*)"" field should be ""(.*)""")]
        public void HelpMessageUnderFieldShouldBe(string fieldName, string message)
        {
            switch (fieldName)
            {
                case "First name":
                    Assert.AreEqual(message, _context.CreateUser.GetFirstNameHelpMessage(),
                        "Help messages are not equal");
                    break;
                case "Last name":
                    Assert.AreEqual(message, _context.CreateUser.GetLastNameHelpMessage(),
                        "Help messages are not equal");
                    break;
                case "Email":
                    Assert.AreEqual(message, _context.CreateUser.GetEmailHelpMessage(),
                        "Help messages are not equal");
                    break;
                case "Password":
                    Assert.AreEqual(message, _context.CreateUser.GetPasswordHelpMessage(),
                        "Help messages are not equal");
                    break;
                case "Repeat password":
                    Assert.AreEqual(message, _context.CreateUser.GetRepeatPasswordHelpMessage(),
                        "Help messages are not equal");
                    break;
                default:
                    Assert.Fail("Unknown field name");
                    break;
            }
        }

        [Then(@"New customer appeared in the users list")]
        public void NewCustomerAppearedInTheUsersList()
        {
            _context.UserPage.SearchUser(_context.CurrentUser);
            var searchedUser = _context.UserPage.GetSearchedUsers().FirstOrDefault();
            Assert.Multiple(() =>
            {
                Assert.AreEqual(_context.CurrentUser.MainInfo.FirstName, searchedUser.MainInfo.FirstName, "User doesn't appear");
                Assert.AreEqual(_context.CurrentUser.MainInfo.LastName, searchedUser.MainInfo.LastName, "User doesn't appear");
            });            
        }
    }
}