using NUnit.Framework;
using TechTalk.SpecFlow;
using UITests.Context;

namespace UserManagementServiceUITests.StepDefinitions
{
    [Binding]
    public sealed class CreateUserAssertions
    {
        private readonly DataContext _context;

        public CreateUserAssertions(DataContext context)
        {
            _context = context;
        }

        [Then(@"the basic information on the modal match with the set data")]
        public void ThenTheBasicInformationOnTheModalMatchWithTheSetData()
        {
            Assert.Multiple(() => {

                Assert.That(_context.UserInfo.FirstName, Is.EqualTo(_context.CreateUserRequest.FirstName));
                Assert.That(_context.UserInfo.LastName, Is.EqualTo(_context.CreateUserRequest.LastName));
                Assert.That(_context.UserInfo.IsActive, Is.EqualTo(_context.UserStatus));
                Assert.That(_context.UserInfo.BirthDate, Is.EqualTo(_context.CreateUserRequest.BirthDate));
            });
        }
    }
}