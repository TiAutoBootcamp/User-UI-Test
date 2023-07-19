using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UserUITest.Pages;

namespace UserUITest.StepDefinitions
{
    [Binding]
    public sealed class UserStepsAssertions
    {

     

        private readonly DataContext _context;
    
        public UserStepsAssertions(DataContext context)
        {
            _context = context;
           // _userPage = new UserPage(_driver, _context);

        }

        [Then(@"a modal with details is opened")]
        public void ThenAModalWithDetailsIsOpened()
        {
            //_userPage.DetailsModalDisplayed();
            Assert.IsTrue(_context.ModalDisplayed);
        }

    }
}