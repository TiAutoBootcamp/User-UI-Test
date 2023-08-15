using Newtonsoft.Json;


namespace CatalogServiceAPI.Models.Requests
{
    public class Filter
    {
        [JsonProperty("article")]
        public string Article;

        [JsonProperty("general")]
        public string General;
    }
}
