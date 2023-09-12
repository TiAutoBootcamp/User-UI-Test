using Newtonsoft.Json;

namespace CatalogServiceAPI.Models.Requests
{
    public class CreateProductRequest
    {
        [JsonProperty("article")]
        public string Article;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("manufactor")]
        public string Manufactor;
    }
}
