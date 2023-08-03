using NUnit.Framework;
using System.Linq;

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

        [Then(@"the information on the modal match with the set data")]
        public void ThenTheInformationOnTheModalMatchWithTheUser()
        {      
            Assert.Multiple(()=>{
                Assert.That(_context.UserInfo.Id, Is.EqualTo(_context.InitialUserId));
                Assert.That(_context.UserInfo.FirstName, Is.EqualTo(_context.CreateUserRequest.FirstName));
                Assert.That(_context.UserInfo.LastName, Is.EqualTo(_context.CreateUserRequest.LastName));
                Assert.That(_context.UserInfo.IsActive, Is.EqualTo(_context.UserStatus));
                Assert.That(_context.UserInfo.BirthDate, Is.EqualTo(_context.CreateUserRequest.BirthDate));
            });
        }

        [Then(@"a modal with details is opened")]
        public void ThenAModalWithDetailsIsOpened()
        {
            Assert.IsTrue(_context.UserPage.IsModalDisplayed());
        }

        [Then(@"the fields are correct and ordered")]
        public void ThenTheFieldsAreCorrectAndOrdered()
        {

            List<string> expectedFields = new List<string>
            {
                "First name:",
                "Last name:",
                "Status:",
                "Birth date:"

            };

            CollectionAssert.AreEqual(expectedFields, _context.TittleModalFields);
        }

        [Then(@"transactions tab is clickable")]
        public void ThenTransactionsTabIsClickable()
        {
            Assert.IsTrue(_context.UserPage.IsTransactionsTabClickable());
        }

        [Then(@"transactions table displays transactions")]
        public void ThenTransactionsTableDisplaysTransactions()
        {
            int countIds = _context.UserPage.transactionsIds().Count;
            Assert.IsTrue(countIds > 0);
        }

        [Then(@"no transactions message is displayed")]
        public void ThenNoTransactionsMessageIsDisplayed()
        {
            string expectedMessage = "User does not have transactions";
            Assert.That(_context.UserPage.messageTransactions(), Is.EqualTo(expectedMessage));
        }

        [Then(@"transactions are displayed in descendant order by creation time")]
        public void ThenTransactionsAreDisplayedInDescendantOrderByCreationTime()
        {
            DateTime actualDateTime = (_context.UserPage.transactionsCreateTime()).Max();
            //Assert.That(actualDateTime, Is.EqualTo(expectedMessage));
        }

        [Then(@"the information displayed has the expected information for the transaction")]
        public void ThenTheInformationDisplayedHasTheExpectedInformationForTheTransaction()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_context.ChargeAmount, Is.EqualTo(_context.TransactionInfo.amount));
                Assert.That(_context.ChargeResponse.Body, Is.EqualTo(_context.TransactionInfo.IdTransaction));
            });
         }


        [Then(@"first transaction has the ([^']*) and expected information")]
        public void ThenFirstTransactionHasTheRevertAndExpectedInformation(string state)
        {
            Assert.Multiple(() =>
            {
                Assert.That(_context.ChargeAmount, Is.EqualTo(_context.TransactionInfo.amount));
                Assert.That(_context.ChargeResponse.Body, Is.EqualTo(_context.TransactionInfo.IdTransaction));
                Assert.That(state, Is.EqualTo(_context.TransactionInfo.Status));
            });
        }


    }
}