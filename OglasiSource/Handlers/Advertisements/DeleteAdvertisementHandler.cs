using MediatR;
using OglasiSource.Api.Cqrs.Commands.Advertisement;
using OglasiSource.Core.Interfaces;

namespace OglasiSource.Api.Handlers.Advertisements
{
    public class DeleteAdvertisementHandler : IRequestHandler<DeleteAdvertisementCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAdvertisementHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteAdvertisementCommand request, CancellationToken cancellationToken)
        {
            var advertisement = await _unitOfWork.Repository<Core.Entities.Advertisement>()!.GetByIdAsync(request.Id);
            _unitOfWork.Repository<Core.Entities.Advertisement>()?.Delete(advertisement!);
            await _unitOfWork.Complete();

            return new Unit();
        }
    }
}
