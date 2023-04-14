using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OglasiSource.Infrastructure.Data.Context;

namespace OglasiSource.Api.Cqrs.Commands.RatingReview
{
    public class UpdateReviewCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Comment { get; set; }
    }

    public class UpdateReviewCommandValidator : AbstractValidator<UpdateReviewCommand>
    {
        private readonly DbWriteContext _writeContext;
        public UpdateReviewCommandValidator(DbWriteContext writeContext)
        {
            _writeContext = writeContext;

            RuleFor(x => x.Id).NotEmpty()
                   .MustAsync(async (id, cancellation) =>
                   {
                       return await _writeContext.Review.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken: cancellation);
                   }).WithMessage("Review id not valid.");

            RuleFor(x => x.Comment).NotEmpty();
        }
    }
}

