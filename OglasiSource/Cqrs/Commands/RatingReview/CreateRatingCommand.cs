using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OglasiSource.Core.Responses.RatingReview;
using OglasiSource.Infrastructure.Data.Context;

namespace OglasiSource.Api.Cqrs.Commands.RatingReview
{
    public class CreateRatingCommand : IRequest<RatingSetResponse>
    {
        public int EntityTypeRatingId { get; set; }
        public int EntityTypeId { get; set; }
        public int Thumb { get; set; }
    }

    public class CreateRatingCommandValidator : AbstractValidator<CreateRatingCommand>
    {
        private readonly DbWriteContext _writeContext;

        public CreateRatingCommandValidator(DbWriteContext writeContext)
        {
            _writeContext = writeContext;

            RuleFor(x => x.EntityTypeRatingId).NotEmpty()
                   .MustAsync(async (id, cancellation) =>
                   {
                       return await _writeContext.EntityTypeRating.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken: cancellation);
                   }).WithMessage("Entity type id not valid.");
           
            RuleFor(x => x.EntityTypeId).NotEmpty()
                   .MustAsync(async (id, cancellation) =>
                   {
                       return await _writeContext.ApplicationUser.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken: cancellation);
                   }).WithMessage("User with this id doesn't exist.");

          

            RuleFor(x => x.Thumb).GreaterThan(-2).LessThan(2).NotEqual(0);
        }
    }
}

