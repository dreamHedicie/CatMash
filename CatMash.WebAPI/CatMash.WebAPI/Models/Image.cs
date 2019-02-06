using Newtonsoft.Json;

namespace CatMash.WebAPI.Models
{

    [JsonObject]
    public class Image
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
