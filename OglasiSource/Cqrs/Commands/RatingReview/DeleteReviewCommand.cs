using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OglasiSource.Infrastructure.Data.Context;

namespace OglasiSource.Api.Cqrs.Commands.RatingReview
{
    public class DeleteReviewCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }

    public class DeleteBrokerReviewCommandValidator : AbstractValidator<DeleteReviewCommand>
    {
        private readonly DbWriteContext _writeContext;
        public DeleteBrokerReviewCommandValidator(DbWriteContext writeContext)
        {
            _writeContext = writeContext;

            RuleFor(x => x.Id).NotEmpty()
                   .MustAsync(async (id, cancellation) =>
                   {
                       return await _writeContext.Review.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken: cancellation);
                   }).WithMessage("Review id not valid.");
        }
    }
}

