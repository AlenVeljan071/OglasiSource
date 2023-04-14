using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OglasiSource.Core.Classes
{
    public class RequestError
    {
        [JsonProperty("error")]
        public object Error { get; set; }
        [JsonProperty("request")]
        public string Request { get; set; }
        [JsonProperty("method")]
        public string Method { get; set; }
    }
}
