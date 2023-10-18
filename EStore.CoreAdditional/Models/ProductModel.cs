using Estore.Models.Enum;

namespace CoreAdditional.Models
{
    public class ProductModel
    {
        public string Name { get; set; }

        public string Manufactor { get; set; }

        public bool IsPresented { get; set; }

        public ProductStatus ProductStatus = ProductStatus.Active;
    }
}
