using Estore.Models.Request.Catalog;

namespace CoreAdditional.Utils
{
    public class CatalogRequestGenerator
    {
        public AddProductRequest GenerateNewProduct(string name = "@@PRODUCT_NAME@@", string manufactor = "@@PRODUCT_MANUFACTOR@@")
        {
            return new AddProductRequest()
            {
                Article = Guid.NewGuid().ToString().ToUpper(),
                Name = name,
                Manufactor = manufactor
            };
        }
    }
}