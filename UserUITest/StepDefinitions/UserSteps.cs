using System.Net;
using UserServiceAPI.Client;
using UserServiceAPI.Utils;

namespace UserUITest.StepDefinitions
{
    [Binding]
    public sealed class UserSteps
    {  
        private readonly UserServiceClient _userServiceClient = new UserServiceClient();
        private readonly UserGenerator _createUser = new UserGenerator();
        private readonly DataContext _context;
        
        public UserSteps(DataContext context)
        {
            _context = context;
        }

        [Given(@"a user created")]
        public async Task GivenAUserCreated()
        {
            _context.CreateUserRequest = _createUser.GenerateUserRequest();
            _context.CreateUserResponse = await _userServiceClient.CreateUser(_context.CreateUserRequest);
            _context.InitialUserId = _context.CreateUserResponse.Body;
        }

        [Given(@"a user created wih birth date ([^']*)")]
        public async Task WhenIWriteAGuidNameToFirstNameFieldWihBirthDateLikeEmpty(string birthDate)
        {
            _context.CreateUserRequest = _createUser.GenerateCreateUserRequestWithBirthDate(birthDate);
            _context.CreateUserResponse = await _userServiceClient.CreateUser(_context.CreateUserRequest);
            _context.InitialUserId = _context.CreateUserResponse.Body;
        }

        [Given(@"a user first name created with (.*) characters and GUID last name with birth date ([^']*)")]
        public async Task GivenAUserFirstNameCreatedWithCharactersAndGUIDLastNameWithBirthDate_(int length, string birthDate)
        {
            _context.CreateUserRequest = _createUser.GenerateRandomFirstNameWithGuidLastNameRequest(length,birthDate);
            _context.CreateUserResponse = await _userServiceClient.CreateUser(_context.CreateUserRequest);
            _context.InitialUserId = _context.CreateUserResponse.Body;
        }

        [Given(@"a user with GUID first name and last name (.*) characters and birth date ([^']*)")]
        public async Task GivenAUserWithGUIDFirstNameAndLastNameCharactersAndBirthDate_(int length, string birthDate)
        {
            _context.CreateUserRequest = _createUser.GenerateRandomLastNameWithGuidLastNameRequest(length, birthDate);
            _context.CreateUserResponse = await _userServiceClient.CreateUser(_context.CreateUserRequest);
            _context.InitialUserId = _context.CreateUserResponse.Body;
        }

        [Given(@"a user first name and last name created with (.*) characters with birth date ([^']*)")]
        public async Task GivenAUserFirstNameAndLastNameCreatedWithCharactersWithBirthDate_(int length, string birthDate)
        {
            _context.CreateUserRequest = _createUser.GenerateRandomUserRequest(length, birthDate);
            _context.CreateUserResponse = await _userServiceClient.CreateUser(_context.CreateUserRequest);
            _context.InitialUserId = _context.CreateUserResponse.Body;
        }

        [When(@"I write a name on the filter")]
        public void WhenIWriteAGuidNameToFirstNameField()
        {
            _context.UserPage.SearchUser(_context.CreateUserRequest.FirstName, _context.CreateUserRequest.LastName);
        }    

        [When(@"click on the search button")]
        public void WhenClickOnTheSearchButton()
        {
            _context.UserPage.ClickSearchButton(); ;
        }

        [When(@"click on the details button")]
        public void WhenClickOnTheDetailsButton()
        {
            Thread.Sleep(500);
            _context.UserPage.ClickDetailsButton();
            
        }

        [When(@"get all the information from the modal")]
        public void WhenGetAllTheInformationFromTheModal()
        {
            _context.UserInfo = _context.UserPage.GetAllTheModalInformatio();
        }

        [When(@"click on the primary close button")]
        public void WhenClickOnThePrimaryCloseButton()
        {
            _context.UserPage.ClickOnPrimaryCloseButton();
        }

        [When(@"click on the secondary close button")]
        public void WhenClickOnTheSecondaryCloseButton()
        {
            _context.UserPage.ClickOnSecondaryCloseButton();
        }

        [Given(@"change the user status to ([^']*)")]
        [Given(@"change second time the user status to ([^']*)")]
        [Given(@"change third time the user status to ([^']*)")]
        public async Task  GivenChangeTheUserStatusToActive(bool status)
        {
            var response = await _userServiceClient.SetUserStatus(_context.InitialUserId, status);
            if (response.StatusCode == HttpStatusCode.OK)
                _context.UserStatus = status;
        }

        [When(@"click out side the modal")]
        public void WhenClickOutSideTheModal()
        {
            _context.UserPage.ClickOnSpecificPosition();
        }

        [When(@"get all the tiitle fields on the modal")]
        public void WhenGetAllTheTiitleFieldsOnTheModal()
        {
            // _tittleModalFields.
            _context.TittleModalFields = _context.UserPage.GetFieldsTittle();
        }

        [Then(@"the modal is closed")]
        [When(@"wait for user details modal closed")]
        public void WhenUserDetailsIsClosed()
        {
            _context.UserPage.WaitForUserDetailsModalClosed();
        }
    }
}