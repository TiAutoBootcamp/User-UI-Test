namespace UserManagementServiceUITests.StepDefinitions
{
    [Binding]
    public class ProductStepsAssertions
    {
        private readonly DataContext _context;

        public ProductStepsAssertions(DataContext context)
        {
            _context = context;
        }

        [Then(@"The product with a certain data is displayed on the page")]
        public void ThenTheProductWithACertainDataIsDisplayedOnThePage()
        {
            //TODO: add assertion after UI implementation
        }

        [Then(@"Main page  has no elements")]
        public void ThenMainPageHasNoElements()
        {
            //TODO: add assertion after UI implementation
        }

        [Then(@"Error message is presented")]
        public void ThenErrorMessageIsPresented()
        {
            //TODO: add assertion after UI implementation
        }
    }
}
