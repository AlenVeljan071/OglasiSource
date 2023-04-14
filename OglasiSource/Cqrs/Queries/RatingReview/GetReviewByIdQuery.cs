using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OglasiSource.Core.Responses.RatingReview;
using OglasiSource.Infrastructure.Data.Context;

namespace OglasiSource.Api.Cqrs.Queries.RatingReview
{
    public class GetReviewByIdQuery : IRequest<ReviewResponse>
    {
        public int Id { get; set; }
    }

    public class GetReviewByIdCommandValidator : AbstractValidator<GetReviewByIdQuery>
    {
        private readonly DbReadContext _readContext;
        public GetReviewByIdCommandValidator(DbReadContext readContext)
        {
            _readContext = readContext;
            RuleFor(x => x.Id).NotEmpty()
                  .MustAsync(async (id, cancellation) =>
                  {
                      return await _readContext.Review.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken: cancellation);
                  }).WithMessage("Review with this id doesn't exists.");
        }
    }
}
