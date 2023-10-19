using TechTalk.SpecFlow;
using UITests.Context;

namespace Estore.UITests.StepDefinitions.Assertions
{
    [Binding]
    public class LoginStepsAssertions
    {
        private readonly DataContext _context;

        public LoginStepsAssertions(DataContext context)
        {
            _context = context;
        }

        [Then(@"All elements are displayed correctly for the admin role")]
        public void ThenAllElementsAreDisplayedCorrectlyForTheAdminRole()
        {
            throw new PendingStepException();
        }

        [Then(@"All elements are displayed correctly for the unauthorized view")]
        public void ThenAllElementsAreDisplayedCorrectlyForTheUnauthorizedView()
        {
            throw new PendingStepException();
        }

        [Then(@"All elements are displayed correctly for the customer role")]
        public void ThenAllElementsAreDisplayedCorrectlyForTheCustomerRole()
        {
            throw new PendingStepException();
        }
    }
}
