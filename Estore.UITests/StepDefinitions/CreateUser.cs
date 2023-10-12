using CoreAdditional.Utils;
using TechTalk.SpecFlow;
using UITests.Context;

namespace UserManagementServiceUITests.StepDefinitions
{
    [Binding]
    public sealed class CreateUser
    {
        private readonly UserRequestGenerator _userGenerator;
        private readonly DataContext _context;

        public CreateUser(
            UserRequestGenerator userGenerator,
            DataContext context)
        {
            _userGenerator = userGenerator;
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
            _context.CreateUserRequest = _userGenerator.GenerateCreateUserRequestWithBirthDate(string.Empty);
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