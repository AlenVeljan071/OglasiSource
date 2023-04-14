using Newtonsoft.Json;
using OglasiSource.Core.Classes;
using OglasiSource.Core.Entities;
using OglasiSource.Core.Interfaces;
using System.Text;

namespace OglasiSource.Infrastructure.Services
{
    public class ImgurUploadService : IImgurUploadService
    {
        private readonly IUnitOfWork _unitOfWork;
        private const string baseUrl = "https://api.imgur.com/3/";
        HttpClient client;


        public ImgurUploadService(IUnitOfWork unitOfWork)
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + "a89637e22eb4af6e8c9c06fc048d5495991d4c42");
            _unitOfWork = unitOfWork;
        }



        public async Task<Image> UploadImage(string base64Image, string name, string title, int advertisementId)
        {
            var jsonData = JsonConvert.SerializeObject(new
            {
                image = base64Image,
                title,
                name
            });

            var jsonContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(baseUrl + "image", jsonContent);
            await CheckHttpStatusCode(response);
            string content = await response.Content.ReadAsStringAsync();

            ResponseRootObject<Image> imgRoot = JsonConvert.DeserializeObject<ResponseRootObject<Image>>(content)!;

            SavedImage image = new SavedImage()
            {
                AdvertisementId = advertisementId,
                Title = imgRoot.Data.Title,
                Link = imgRoot.Data.Link,
            };
            _unitOfWork.Repository<Core.Entities.SavedImage>()?.Add(image);
            await _unitOfWork.Complete();
           
            return imgRoot.Data;
        }

        private async Task CheckHttpStatusCode(HttpResponseMessage responseMessage)
        {
            var content = await responseMessage.Content.ReadAsStringAsync();
            ResponseRootObject<RequestError> errorRoot = null;

            try
            {
                errorRoot = JsonConvert.DeserializeObject<ResponseRootObject<RequestError>>(content)!;
            }
            catch (Exception) { }

            if (errorRoot == null)
                return;

            if ((int)responseMessage.StatusCode / 100 > 2)
            {
                throw new ResponseException(string.Format(" Error: {0} \n Request: {1} \n Verb: {2} ", errorRoot.Data.Error, errorRoot.Data.Request, errorRoot.Data.Method));
            }

            return;
        }

    }
}
