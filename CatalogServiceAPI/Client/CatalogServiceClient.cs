using CatalogServiceAPI.Models.Requests;
using Core.Client;
using Core.Models.Base;
using Core.Extentions;

namespace CatalogServiceAPI.Client
{
    public class CatalogServiceClient : BaseClient
    {
        public CatalogServiceClient(string baseUrl = "https://catalogservice-uat.azurewebsites.net") : base(baseUrl)
        {
        }

        public async Task<CommonResponse<object>> CreateProduct(CreateProductRequest request)
        {
            var response = await SendPostRequest("/Catalog/CreateProduct", request);
            return await response.ToCommonResponse<object>();
        }

        public async Task<CommonResponse<object>> SetProductStatus(string article, int newStatus)
        {
            var response = await SendPutRequestWithoutContent($"/Catalog/SetProductStatus?article={article}&status={newStatus}");
            return await response.ToCommonResponse<object>();
        }

        public async Task<CommonResponse<object>> UpdateProductPrice(string article, double price)
        {
            var response = await SendPutRequestWithoutContent($"/Catalog/UpdateProductPrice?article={article}&price={price}");
            return await response.ToCommonResponse<object>();
        }

        public async Task<CommonResponse<object>> DeleteProductInfo(string article)
        {
            var response = await SendDeleteRequest($"/Catalog/DeleteProductInfo?article={article}");
            return await response.ToCommonResponse<object>();
        }
    }
}
