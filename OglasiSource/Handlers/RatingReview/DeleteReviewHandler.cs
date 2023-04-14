using MediatR;
using OglasiSource.Api.Cqrs.Commands.RatingReview;
using OglasiSource.Core.Entities;
using OglasiSource.Core.Interfaces;

namespace TOglasiSourceruckAssist.Api.Handlers.RatingReview
{
    public class DeleteReviewHandler : IRequestHandler<DeleteReviewCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteReviewHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _unitOfWork.Repository<Review>()!.GetByIdAsync(request.Id);

            _unitOfWork.Repository<Review>()?.Delete(review!);
            await _unitOfWork.Complete();

            return new Unit();
        }

    }
}
