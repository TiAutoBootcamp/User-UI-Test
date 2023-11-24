using Estore.CoreAdditional.Extensions;
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

        public AddProductRequest GenerateNewProduct()
        {
            return new AddProductRequest()
            {
                Article = Guid.NewGuid().ToString().ToUpper(),
                Name = Guid.NewGuid().ToString(),
                Manufactor = Guid.NewGuid().ToString()
            };
        }

        public MultipartFormDataContent GenerateAddImageRequest(string article, string filePath)
        {
            var formData = new MultipartFormDataContent();
            if (article != null)
            {
                formData.Add(new StringContent(article), "article");
            }
            if (!string.IsNullOrEmpty(filePath))
            {
                var fileName = filePath.Split('\\').Last();
                formData.Add(new ByteArrayContent(FileExtension.GetByteArray(filePath)), "data", fileName);
            }

            return formData;
        }
    }
}