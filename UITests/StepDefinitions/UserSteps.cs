using Core;
using Core.Libraries;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using UserServiceAPI.Client;
using UserServiceAPI.Utils;
using WalletServiceAPI.Client;
using WalletServiceAPI.Utils;

namespace UITests.StepDefinitions
{
    [Binding]
    public sealed class UserSteps
    {
        private readonly UserServiceClient _userServiceClient = new UserServiceClient();
        private readonly WalletServiceClient _walletServiceClient = new WalletServiceClient();
        private readonly BalanceChargeGenerator _balanceChargeGenerator = new BalanceChargeGenerator();
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
            _context.CreateUserRequest = _createUser.GenerateCreateUserRequestWithBirthDate(birthDate);
            _context.CreateUserResponse = await _userServiceClient.CreateUser(_context.CreateUserRequest);
            _context.InitialUserId = _context.CreateUserResponse.Body;
        }

        [Given(@"a user first name created with (.*) characters and GUID last name with birth date ([^']*)")]
        public async Task GivenAUserFirstNameCreatedWithCharactersAndGUIDLastNameWithBirthDate_(int length, string birthDate)
        {
            _context.CreateUserRequest = _createUser.GenerateRandomFirstNameWithGuidLastNameRequest(length, birthDate);
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
            var response = await _userServiceClient.SetUserStatus(_context.InitialUserId, status);
            if (response.StatusCode == HttpStatusCode.OK)
                _context.UserStatus = status;
        }

        [Given(@"a user created and active")]
        public async Task GivenAUserCreatedAndActive()
        {
            _context.CreateUserRequest = _createUser.GenerateUserRequest();
            _context.CreateUserResponse = await _userServiceClient.CreateUser(_context.CreateUserRequest);
            _context.InitialUserId = _context.CreateUserResponse.Body;
            var response = await _userServiceClient.SetUserStatus(_context.InitialUserId, true);
            if (response.StatusCode == HttpStatusCode.OK)
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
            _context.CreateUserRequest = _createUser.GenerateRandomFirstNameWithGuidLastNameRequest(7, "12.07.2023");
            _context.CreateUserResponse = await _userServiceClient.CreateUser(_context.CreateUserRequest);
            _context.InitialUserId = _context.CreateUserResponse.Body;
            _context.SetUserStatusResponse = await _userServiceClient.SetUserStatus(_context.InitialUserId, true);

            //Write logic to create transactions
            var request = _balanceChargeGenerator.GenerateBalanceChargeRequest(_context.InitialUserId, 10);
            _context.ChargeResponse = await _walletServiceClient.BalanceCharge(request);
        }

        [Given(@"user is charged with (.*)")]
        public async Task GivenUserIsChargedWithAmount(double amount)
        {
            _context.ChargeAmount = amount;
            var request = _balanceChargeGenerator.GenerateBalanceChargeRequest(_context.InitialUserId, amount);
            _context.ChargeResponse = await _walletServiceClient.BalanceCharge(request);

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
                var request = _balanceChargeGenerator.GenerateBalanceChargeRequest(_context.InitialUserId, i);
                _context.ChargeResponse = await _walletServiceClient.BalanceCharge(request);
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
            _context.TransactionInfo = new TransactionInfo
            {
                IdTransaction = _context.UserPage.TransactionsIds().First(),
                Amount = _context.UserPage.transactionsAmounts().First(),
                Status = _context.UserPage.transactionStatus().First()
            };
        }

        [Given(@"user has reverted the last transaction")]
        public async Task GivenUserHasRevertedTheLastTransaction()
        {
            _context.ReverseTransactionStatusResponse = await _walletServiceClient.RevertTransaction(_context.UserIdTransaction);
            _context.RevertUserIdTransaction = _context.ReverseTransactionStatusResponse.Body;
        }

        [When(@"get the information of the second transaction")]
        public void WhenGetTheInformationOfTheSecondTransaction()
        {
            _context.UserPage.WaitForTableVisible();
            _context.RevertTransactionInfo = new TransactionInfo
            {
                IdTransaction = _context.UserPage.TransactionsIds().Skip(1).First(),
                Amount = _context.UserPage.transactionsAmounts().Skip(1).First(),
                Status = _context.UserPage.transactionStatus().Skip(1).First()
            };
        }


        [When(@"request to get the creation time for user transactions")]
        public async Task WhenRequestTheInformartionOfTheLastTransaction()
        {
            _context.UserPage.WaitForTableVisible();
            var responseData = await _walletServiceClient.GetTransactions(_context.InitialUserId);
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

            var responseData = await _walletServiceClient.GetTransactions(_context.InitialUserId);
            string patternDate = @"\d{4}-\d{2}-\w+:\d{2}:\d{2}";

            string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss";
            string patternId = @"\w+-\w+-\w+-\w+-\w+";
            string patternAmount = @"\d+\.\d+(?=,)";
            string patternStatus = @"(?<=:)\d{1}(?=,)";

            _context.ExpectedTransactionTime = Regex.Matches(responseData.Content, patternDate)
                                 .Cast<Match>()
                                 .Select(match => DateTime.ParseExact(match.Value, DateTimeFormat, CultureInfo.InvariantCulture)).ToList();

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
                    _context.MainPage.FillSearchField(TestDataLibrary.LongString);
                    return;
                default:
                    _context.MainPage.FillSearchField(searchedString);
                    break;
            }
            _context.MainPage.ClickSearchButton();
        }
    }
}