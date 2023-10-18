using CoreAdditional.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Estore.UITests.StepDefinitions.Base
{
    [Binding]
    public class Transformations
    {
        [StepArgumentTransformation]
        public List<ProductModel> TableToProductsInfo(Table table) =>
              table.CreateSet<ProductModel>().ToList();
    }
}
