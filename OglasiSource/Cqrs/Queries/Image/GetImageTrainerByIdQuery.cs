using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OglasiSource.Core.Responses.Image;
using OglasiSource.Infrastructure.Data.Context;

namespace OglasiSource.Api.Cqrs.Queries.Image
{
    public class GetImageTrainerByIdQuery : IRequest<ImageResponse>
    {
        public int Id { get; set; }

        public class GetImageTrainerByIdQueryValidator : AbstractValidator<GetImageTrainerByIdQuery>
        {
            private readonly DbReadContext _readContext;

            public GetImageTrainerByIdQueryValidator(DbReadContext readContext)
            {
                _readContext = readContext;

                this.ClassLevelCascadeMode = CascadeMode.Stop;

                RuleFor(x => x.Id).NotEmpty()
                       .MustAsync(async (id, cancellation) =>
                       {
                           return await _readContext.SavedImages.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken: cancellation);
                       }).WithMessage("Image id not valid.");
            }
        }
    }
}
