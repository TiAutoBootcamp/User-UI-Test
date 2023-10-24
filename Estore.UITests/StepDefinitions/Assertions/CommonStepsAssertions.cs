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

        [Then(@"Info message '([^']*)' is presented")]
        public void ThenInfoMessageIsPresented(string infoMessage)
        {
            Assert.AreEqual(infoMessage, _context.CurrentPage.GetInfoMessage());
        }

        [Then(@"Create user modal should be close")]
        public void ThenCreateUserModalShouldBeClose()
        {
            Assert.IsFalse(_context.CreateUser.CreateUserModalIsOpen());
        }
    }
}
