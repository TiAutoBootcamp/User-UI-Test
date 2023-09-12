using TechTalk.SpecFlow;
using UITests;
using UserServiceAPI.Utils;

namespace UserManagementServiceUITests.StepDefinitions
{
    [Binding]
    public sealed class CreateUser
    {
        private readonly UserGenerator _createUser = new UserGenerator();
        private readonly DataContext _context;

        public CreateUser(DataContext context)
        {
            _context = context;
        }
        [When(@"click on the add user button")]
        [Given(@"a user open the create user modal")]
        public void GivenAUserOpenTheCreateUserModal()
        {
            _context.UserPage.ClickAddUserButton();
        }

        [When(@"I write a name on the fields")]
        public void WhenIWriteANameOnTheFields()
        {
            _context.CreateUserRequest = _createUser.GenerateCreateUserRequestWithBirthDate(string.Empty);

            _context.CreateUser.SetNameOnModal(_context.CreateUserRequest.FirstName, _context.CreateUserRequest.LastName);
        }

        [When(@"click on the save button")]
        public void WhenClickOnTheSaveButton()
        {
            _context.CreateUser.ClickSaveButton();
        }

        [When(@"click on the close button")]
        public void WhenClickOnTheCloseButton()
        {
            _context.CreateUser.ClickCancelButton();
        }
    }
}