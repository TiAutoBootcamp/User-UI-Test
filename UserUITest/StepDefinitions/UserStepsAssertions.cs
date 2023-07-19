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
            Assert.IsTrue(_context.ModalDisplayed);
        }

        [Then(@"the information on the modal match with the user")]
        public void ThenTheInformationOnTheModalMatchWithTheUser()
        {
            Assert.Multiple(()=>{
                Assert.That(_context.UserModalInformation.FirstName, Is.EqualTo(_context.CreateUserRequest.FirstName));
               // Assert.That(_context.UserModalInformation.LastName, Is.EqualTo(_context.CreateUserRequest.LastName));
               // Assert.That(_context.UserModalInformation.Status, Is.EqualTo(_context.UserStatus));
               // Assert.That(_context.UserModalInformation.BirthDate, Is.EqualTo(_context.BirthDayUser));
            });
        }

        [Then(@"the modal is closed")]
        public void ThenTheModalIsClosed()
        {
            Assert.IsFalse(_context.ModalDisplayed);
        }

    }
}