using OglasiSource.Core.Classes;
using OglasiSource.Core.Entities;
using OglasiSource.Core.Enums;

namespace OglasiSource.Core.Interfaces
{
    public interface IImgurUploadService
    {
        Task<Image> UploadImage(string base64Image, string name, string title, int trainerId);
    }
}
