using Core.Enums;

namespace CatalogServiceAPI.Models.StepsModels
{
    public class ProductModel
    {
        public string Name;

        public string Manufactor;

        public bool isPresented;

        public ProductStatus ProductStatus = ProductStatus.Active;
    }
}
