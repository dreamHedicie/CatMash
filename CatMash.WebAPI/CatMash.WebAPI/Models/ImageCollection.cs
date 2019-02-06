using Newtonsoft.Json;
using System.Collections.Generic;

namespace CatMash.WebAPI.Models
{
    [JsonObject]
    public class ImageCollection
    {
        [JsonProperty("images")]
        public IEnumerable<Image> Images { get; set; }
    }
}
