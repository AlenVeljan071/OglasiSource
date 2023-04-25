using MediatR;
using OglasiSource.Api.Cqrs.Commands.Image;
using OglasiSource.Core.Interfaces;

namespace OglasiSource.Api.Handlers.Advertisements
{
    public class DeleteImageHandler : IRequestHandler<DeleteImageCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteImageHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
        {
            var image = await _unitOfWork.Repository<Core.Entities.SavedImage>()!.GetByIdAsync(request.Id);
            _unitOfWork.Repository<Core.Entities.SavedImage>()?.Delete(image!);
            await _unitOfWork.Complete();

            return new Unit();
        }
   
    }
}
