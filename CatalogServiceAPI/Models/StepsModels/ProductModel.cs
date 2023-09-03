using Core.Enums;

namespace CatalogServiceAPI.Models.StepsModels
{
    public class ProductModel
    {
        public string Name;

        public string Manufactor;

        public ProductStatus ProductStatus = ProductStatus.Active;
    }
}
