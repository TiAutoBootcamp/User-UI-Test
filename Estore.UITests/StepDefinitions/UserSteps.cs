using UITests.TestData;
using TechTalk.SpecFlow;
using CoreAdditional.Providers;
using UITests.Context;
using Estore.Models.Response.Wallet;
using System.Text.RegularExpressions;
using System.Globalization;
using CoreAdditional.Utils;

namespace UITests.StepDefinitions
{
    [Binding]
    public sealed class UserSteps
    {
        private readonly UserServiceProvider _userProvider;
        private readonly WalletServiceProvider _walletProvider;
        private readonly UserRequestGenerator _userGenerator;
        private readonly DataContext _context;

        public UserSteps(
            UserServiceProvider userProvider,
            WalletServiceProvider walletProvider,
            UserRequestGenerator userGenerator,
            DataContext context)
        {            
            _userProvider = userProvider;
            _walletProvider = walletProvider;
            _userGenerator = userGenerator;
            _context = context;
        }

        [Given(@"User search product by '(.*)'")]
        [When(@"User search product by '(.*)'")]
        public void WhenUserSearchProductBy(string searchedString)
        {
            switch (searchedString)
            {
                case "Article":
                    _context.MainPage.FillSearchField(_context.ProductRequest.Article);
                    break;
                case "Name":
                    _context.MainPage.FillSearchField(_context.ProductRequest.Name);
                    break;
                case "Manufactor":
                    _context.MainPage.FillSearchField(_context.ProductRequest.Manufactor);
                    break;
                case "":
                    return;
                case "Long string":
                    _context.MainPage.FillSearchField(TestCasesData.LongString);
                    return;
                default:
                    _context.MainPage.FillSearchField(searchedString);
                    break;
            }
            _context.MainPage.ClickSearchButton();
        }

        [Given(@"a user created")]
        public async Task GivenAUserCreated()
        {
            _context.CreateUserRequest = _userGenerator.GenerateUserRequest();
            _context.CreateUserResponse = await _userProvider.RegisterValidUser(_context.CreateUserRequest);
            _context.InitialUserId = _context.CreateUserResponse.Body.Value;
        }

        [Given(@"a user created wih birth date ([^']*)")]
        public async Task WhenIWriteAGuidNameToFirstNameFieldWihBirthDateLikeEmpty(string birthDate)
        {
            if (birthDate[2] == '/')
            {
                char temp1 = birthDate[0];
                char temp2 = birthDate[1];
                char temp3 = birthDate[3];
                char temp4 = birthDate[4];

                birthDate = birthDate.Remove(0, 6);
                birthDate = birthDate.Insert(0, temp3.ToString() + temp4.ToString());
                birthDate = birthDate.Insert(2, temp1.ToString() + temp2.ToString());
                birthDate = birthDate.Insert(2, ".");
                birthDate = birthDate.Insert(5, ".");
            }
            _context.CreateUserRequest = _userGenerator.GenerateCreateUserRequestWithBirthDate(birthDate);
            _context.CreateUserResponse = await _userProvider.RegisterValidUser(_context.CreateUserRequest);
            _context.InitialUserId = _context.CreateUserResponse.Body.Value;
        }

        [Given(@"a user first name created with (.*) characters and GUID last name with birth date ([^']*)")]
        public async Task GivenAUserFirstNameCreatedWithCharactersAndGUIDLastNameWithBirthDate_(int length, string birthDate)
        {
            _context.CreateUserRequest = _userGenerator.GenerateRandomFirstNameWithGuidLastNameRequest(length, birthDate);
            _context.CreateUserResponse = await _userProvider.RegisterValidUser(_context.CreateUserRequest);
            _context.InitialUserId = _context.CreateUserResponse.Body.Value;
        }

        [Given(@"a user with GUID first name and last name (.*) characters and birth date ([^']*)")]
        public async Task GivenAUserWithGUIDFirstNameAndLastNameCharactersAndBirthDate_(int length, string birthDate)
        {
            _context.CreateUserRequest = _userGenerator.GenerateRandomLastNameWithGuidLastNameRequest(length, birthDate);
            _context.CreateUserResponse = await _userProvider.RegisterValidUser(_context.CreateUserRequest);
            _context.InitialUserId = _context.CreateUserResponse.Body.Value;
        }

        [Given(@"a user first name and last name created with (.*) characters with birth date ([^']*)")]
        public async Task GivenAUserFirstNameAndLastNameCreatedWithCharactersWithBirthDate_(int length, string birthDate)
        {
            _context.CreateUserRequest = _userGenerator.GenerateRandomUserRequest(length, birthDate);
            _context.CreateUserResponse = await _userProvider.RegisterValidUser(_context.CreateUserRequest);
            _context.InitialUserId = _context.CreateUserResponse.Body.Value;
        }

        [When(@"I write a name on the filter")]
        public void WhenIWriteAGuidNameToFirstNameField()
        {
            _context.UserPage.SearchUser(_context.CreateUserRequest.FirstName, _context.CreateUserRequest.LastName);
        }

        [When(@"click on the search button")]
        public void WhenClickOnTheSearchButton()
        {
            _context.UserPage.ClickSearchButton();
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
            _context.UserInfo = _context.UserPage.GetAllTheModalInformation();
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
        public async Task GivenChangeTheUserStatusToActive(bool status)
        {
            var response = await _userProvider.SetUserStatus(_context.InitialUserId, status);
            if (response.IsSuccesfull)
                _context.UserStatus = status;
        }

        [Given(@"a user created and active")]
        public async Task GivenAUserCreatedAndActive()
        {
            _context.CreateUserRequest = _userGenerator.GenerateUserRequest();
            _context.CreateUserResponse = await _userProvider.RegisterValidUser(_context.CreateUserRequest);
            _context.InitialUserId = _context.CreateUserResponse.Body.Value;
            var response = await _userProvider.SetUserStatus(_context.InitialUserId, true);
            if (response.IsSuccesfull)
                _context.UserStatus = true;
        }


        [When(@"click out side the modal")]
        public void WhenClickOutSideTheModal()
        {
            _context.UserPage.ClickOnSpecificPosition();
        }

        [When(@"get all the tiitle fields on the modal")]
        public void WhenGetAllTheTiitleFieldsOnTheModal()
        {
            _context.TittleModalFields = _context.UserPage.GetFieldsTittle();
        }

        [Then(@"the modal is closed")]
        [When(@"wait for user details modal closed")]
        public void WhenUserDetailsIsClosed()
        {
            _context.UserPage.WaitForUserDetailsModalClosed();
        }

        [Given(@"a user with transactions is created")]
        public async Task GivenAUserWithTransactionsIsCreated()
        {
            _context.CreateUserRequest = _userGenerator.GenerateRandomFirstNameWithGuidLastNameRequest(7, "12.07.2023");
            _context.CreateUserResponse = await _userProvider.RegisterValidUser(_context.CreateUserRequest);
            _context.InitialUserId = _context.CreateUserResponse.Body.Value;
            _context.SetUserStatusResponse = await _userProvider.SetUserStatus(_context.InitialUserId, true);

            //Write logic to create transactions
           _context.ChargeResponse = await _walletProvider.BalanceCharge(_context.InitialUserId, 10);
        }

        [Given(@"user is charged with (.*)")]
        public async Task GivenUserIsChargedWithAmount(decimal amount)
        {
            _context.ChargeAmount = amount;
            _context.ChargeResponse = await _walletProvider.BalanceCharge(_context.InitialUserId, amount);
        }

        [When(@"click on transactions tab")]
        public void WhenClickOnTransactionsTab()
        {
            _context.UserPage.ClickOnTransactionsTab();
        }

        [Given(@"made multipleTransactions (.*)")]
        public async Task GivenMadeMultipleTransactions(string values)
        {
            int[] array = values.Split(',').Select(int.Parse).ToArray();
            foreach (int i in array)
            {
                _context.ChargeResponse = await _walletProvider.BalanceCharge(_context.InitialUserId, i);
                _context.ChargeAmountRevert = -i;
                _context.ChargeAmount = i;
                _context.UserIdTransaction = _context.ChargeResponse.Body;
                _context.NumberTransactions = array.Length;
            }
        }

        [When(@"get the information of the first transaction")]
        public void WhenGetTheInformationOfTheFirstTransaction()
        {
            _context.UserPage.WaitForTableVisible();
            _context.TransactionInfo = new TransactionInfoResponse
            {
                TransactionId = _context.UserPage.TransactionsIds().First(),
                Amount = _context.UserPage.TransactionsAmounts().First(),
                Status = _context.UserPage.TransactionsStatus().First()
            };
        }

        [Given(@"user has reverted the last transaction")]
        public async Task GivenUserHasRevertedTheLastTransaction()
        {
            _context.RevertUserIdTransaction = await _walletProvider.GetRevertTransactionId(_context.UserIdTransaction);
        }

        [When(@"get the information of the second transaction")]
        public void WhenGetTheInformationOfTheSecondTransaction()
        {
            _context.UserPage.WaitForTableVisible();
            _context.RevertTransactionInfo = new TransactionInfoResponse
            {
                TransactionId = _context.UserPage.TransactionsIds().Skip(1).First(),
                Amount = _context.UserPage.TransactionsAmounts().Skip(1).First(),
                Status = _context.UserPage.TransactionsStatus().Skip(1).First()
            };
        }

        [When(@"request to get the creation time for user transactions")]
        public async Task WhenRequestTheInformartionOfTheLastTransaction()
        {
            _context.UserPage.WaitForTableVisible();
            var responseData = await _walletProvider.GetTransactions(_context.InitialUserId);
            string pattern = @"\d{4}-\d{2}-\w+:\d{2}:\d{2}";

            string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss";

            var CreateTimeValues = Regex.Matches(responseData.Content, pattern)
                                 .Cast<Match>()
                                 .Select(match => DateTime.ParseExact(match.Value, DateTimeFormat, CultureInfo.InvariantCulture));

            _context.ExpectedTransactionTime = CreateTimeValues.ToList();
        }

        [When(@"request to get all the information for all the transactions")]
        public async Task WhenRequestToGetAllTheInformationForAllTheTransactions()
        {
            _context.UserPage.WaitForTableVisible();

            var responseData = await _walletProvider.GetTransactions(_context.InitialUserId);
            string patternDate = @"\d{4}-\d{2}-\w+:\d{2}:\d{2}";

            string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss";
            string patternId = @"\w+-\w+-\w+-\w+-\w+";
            string patternAmount = @"\d+\.\d+(?=,)";
            string patternStatus = @"(?<=:)\d{1}(?=,)";

            _context.ExpectedTransactionTime = Regex.Matches(responseData.Content, patternDate)
                                 .Cast<Match>()
                                 .Select(match => DateTime.ParseExact(match.Value, DateTimeFormat, CultureInfo.InvariantCulture)).ToList();

        }
    }
}