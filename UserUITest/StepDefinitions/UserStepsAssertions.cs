using NUnit.Framework;

namespace UserUITest.StepDefinitions
{
    [Binding]
    public sealed class UserStepsAssertions
    {
        private readonly DataContext _context;
    
        public UserStepsAssertions(DataContext context)
        {
            _context = context;
        }

        [Then(@"a modal with details is opened")]
        public void ThenAModalWithDetailsIsOpened()
        {
            Assert.IsTrue(_context.ModalDisplayed);
        }

        [Then(@"the information on the modal match with the complete user name, ([^']*) and ([^']*)")]
        public void ThenTheInformationOnTheModalMatchWithTheUser(bool expectedStatus , string expectedBirthDate)
        {
            if (expectedBirthDate == "empty") { _context.CreateUserRequest.BirthDate = string.Empty; }
            _context.UserStatus = expectedStatus;
          
            Assert.Multiple(()=>{
                Assert.That(_context.IdModal, Is.EqualTo(_context.UserId));
                Assert.That(_context.FirstNameModal, Is.EqualTo(_context.CreateUserRequest.FirstName));
                Assert.That(_context.LastNameModal, Is.EqualTo(_context.CreateUserRequest.LastName));
                Assert.That(_context.StatusModal, Is.EqualTo(_context.UserStatus));
                Assert.That(_context.BirthDateModal, Is.EqualTo(_context.CreateUserRequest.BirthDate));
            });
        }

        [Then(@"the modal is closed")]
        public void ThenTheModalIsClosed()
        {
            Assert.IsFalse(_context.ModalDisplayed);
        }
    }
}