using AutoMapper;
using MediatR;
using OglasiSource.Api.Cqrs.Commands.Advertisement;
using OglasiSource.Core.Interfaces;
using OglasiSource.Core.Responses;

namespace OglasiSource.Api.Handlers.Advertisements
{
    public class CreateAdvertisementsHandler : IRequestHandler<CreateAdvertisementCommand, CreateResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateAdvertisementsHandler(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenService = tokenService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<CreateResponse> Handle(CreateAdvertisementCommand request, CancellationToken cancellationToken)
        {
            int companyUserId = _tokenService.ReadUserId(_httpContextAccessor.HttpContext!.Request.Headers["Authorization"][0]!);
            var advertisement = _mapper.Map<CreateAdvertisementCommand, Core.Entities.Advertisement>(request);
            advertisement.ApplicationUserId = companyUserId;
            _unitOfWork.Repository<Core.Entities.Advertisement>()?.Add(advertisement);
          
            await _unitOfWork.Complete();

            return new CreateResponse { Id = advertisement.Id };
        }
    }
}
