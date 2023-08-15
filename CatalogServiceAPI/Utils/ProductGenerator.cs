using CatalogServiceAPI.Models.Requests;

namespace CatalogServiceAPI.Utils
{
    public class ProductGenerator
    {
        public CreateProductRequest GenerateNewProduct()
        {
            return new CreateProductRequest()
            {
                Article = Guid.NewGuid().ToString().ToUpper(),
                Name = "PRODUCT_NAME",
                Manufactor = "PRODUCT_MANUFACTOR"
            };
        }

        public CreateProductRequest GenerateNewProduct(string article)
        {
            return new CreateProductRequest()
            {
                Article = article,
                Name = "PRODUCT_NAME",
                Manufactor = "PRODUCT_MANUFACTOR"
            };
        }
    }
}
