using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OglasiSource.Core.Classes
{
    public class CreateAlbum
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
        //[JsonProperty("deletehash")]
        //public string DeleteHash { get; set; }
    }
}
