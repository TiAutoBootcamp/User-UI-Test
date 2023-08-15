using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogServiceAPI.Models.Requests
{
    public class GetAllProducts
    {
        [JsonProperty("take")]
        public int Take;

        [JsonProperty("pageNumber")]
        public string PageNumber;

        [JsonProperty("filter")]
        public Filter Filter;
    }
}
