using MediatR;
using OglasiSource.Api.Cqrs.Commands.RatingReview;
using OglasiSource.Core.Entities;
using OglasiSource.Core.Interfaces;

namespace OglasiSource.Api.Handlers.RatingReview
{
    public class UpdateReviewHandler : IRequestHandler<UpdateReviewCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateReviewHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _unitOfWork.Repository<Review>()!.GetByIdAsync(request.Id);
            review!.Comment = request.Comment;

            _unitOfWork.Repository<Review>()?.Update(review!);
            await _unitOfWork.Complete();

            return new Unit();
        }

    }
}
