using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
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
            int countIds = _context.UserPage.TransactionsIds().Count;
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


        [Then(@"second transaction has the ([^']*) and expected information")]
        public void ThenSecondTransactionHasTheRevertAndExpectedInformation(string state)
        {
            Assert.Multiple(() =>
            {
                Assert.That(_context.ChargeAmount, Is.EqualTo(_context.RevertTransactionInfo.amount));
                Assert.That(_context.UserIdTransaction, Is.EqualTo(_context.RevertTransactionInfo.IdTransaction));
                Assert.That(state, Is.EqualTo(_context.RevertTransactionInfo.Status));
            });
        }

        [Then(@"the first transaction has the revert amount")]
        public void ThenTheFirstTransactionHasTheRevertAmount()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_context.ChargeAmountRevert, Is.EqualTo(_context.TransactionInfo.amount));
                Assert.That(_context.RevertUserIdTransaction, Is.EqualTo(_context.TransactionInfo.IdTransaction));
                Assert.That("Active", Is.EqualTo(_context.TransactionInfo.Status));
            });


        }

    }
}