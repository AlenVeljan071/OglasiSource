using AutoMapper;
using MediatR;
using OglasiSource.Api.Cqrs.Commands.Advertisement;
using OglasiSource.Core.Interfaces;

namespace OglasiSource.Api.Handlers.Advertisements
{
    public class UpdateAdvertisementPriceHandler : IRequestHandler<UpdateAdvertisementPriceCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAdvertisementPriceHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAdvertisementPriceCommand request, CancellationToken cancellationToken)
        {

            var advertisement = await _unitOfWork.Repository<Core.Entities.Advertisement>()!.GetByIdAsync(request.Id);
            _mapper.Map<UpdateAdvertisementPriceCommand, Core.Entities.Advertisement>(request, advertisement!);
            _unitOfWork.Repository<Core.Entities.Advertisement>()!.Update(advertisement!);
            await _unitOfWork.Complete();
            return new Unit();
        }
    }
}
