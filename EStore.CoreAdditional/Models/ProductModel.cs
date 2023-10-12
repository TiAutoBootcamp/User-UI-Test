using Estore.Models.Enum;

namespace CoreAdditional.Models
{
    public class ProductModel
    {
        public string Name;

        public string Manufactor;

        public bool isPresented;

        public ProductStatus ProductStatus = ProductStatus.Active;
    }
}
