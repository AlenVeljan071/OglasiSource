using OglasiSource.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OglasiSource.Infrastructure.Data.Repository
{
    public class ImgurApiClient : IImgurApiClient
    {
        HttpClient _client;

        public ImgurApiClient(HttpClient httpClient)
        {
            this._client = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }


    }
}
