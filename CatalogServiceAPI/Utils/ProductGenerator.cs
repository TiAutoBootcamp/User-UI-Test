using CatalogServiceAPI.Models.Requests;

namespace CatalogServiceAPI.Utils
{
    public class ProductGenerator
    {
        public CreateProductRequest GenerateNewProduct(string name = "PRODUCT_NAME", string manufactor  = "PRODUCT_MANUFACTOR")
        {
            return new CreateProductRequest()
            {
                Article = Guid.NewGuid().ToString().ToUpper(),
                Name = name,
                Manufactor = manufactor
            };
        }
    }
}
