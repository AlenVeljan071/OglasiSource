using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OglasiSource.Core.Classes
{
    public class Image
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }

        public byte[] ImageFile { get; set; }

        [JsonProperty("deletehash")]
        public string Deletehash { get; set; }


        [JsonProperty("link")]
        public string Link { get; set; }
    }
}
