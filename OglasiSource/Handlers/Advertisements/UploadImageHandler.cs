using AutoMapper;
using MediatR;
using OglasiSource.Api.Cqrs.Commands.Image;
using OglasiSource.Core.Interfaces;
using OglasiSource.Core.Interfaces.Repositories;

namespace OglasiSource.Api.Handlers.Trainer
{
    public class UploadImageHandler : IRequestHandler<UploadImageCommand, Core.Classes.Image>
    {
        private readonly IImgurUploadService _imgurService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITokenService _tokenService;
        private readonly IReadGenericRepository<Core.Entities.Advertisement> _readGenericRepository;
        public UploadImageHandler(IImgurUploadService imgurService, IHttpContextAccessor httpContextAccessor, ITokenService tokenService, IReadGenericRepository<Core.Entities.Advertisement> readGenericRepository)
        {
            _imgurService = imgurService;
            _httpContextAccessor = httpContextAccessor;
            _tokenService = tokenService;
            _readGenericRepository = readGenericRepository;
        }
        public async Task<Core.Classes.Image> Handle(UploadImageCommand request, CancellationToken cancellationToken)
        {
            var advertisement = await _readGenericRepository.GetByIdAsync(request.AdvertisementId);
            var name = "AutoOglasiSource";
            var response = await _imgurService.UploadImage(request.Image, name, name, advertisement!.Id);
            return response;
        }
   
    }
}
