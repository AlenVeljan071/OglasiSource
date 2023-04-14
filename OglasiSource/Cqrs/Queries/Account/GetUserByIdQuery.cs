using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OglasiSource.Api.Cqrs.Queries.Advertisement;
using OglasiSource.Core.Responses.Account;
using OglasiSource.Core.Responses.Advertisements;
using OglasiSource.Infrastructure.Data.Context;

namespace OglasiSource.Api.Cqrs.Queries.Account
{
    public class GetUserByIdQuery : IRequest<ApplicationUserResponse>
    {
        public int Id { get; set; }

        public class GetAdvertisementByIdQueryValidator : AbstractValidator<GetAdvertisementByIdQuery>
        {
            private readonly DbReadContext _readContext;

            public GetAdvertisementByIdQueryValidator(DbReadContext readContext)
            {
                _readContext = readContext;

                this.ClassLevelCascadeMode = CascadeMode.Stop;

                RuleFor(x => x.Id).NotEmpty()
                       .MustAsync(async (id, cancellation) =>
                       {
                           return await _readContext.ApplicationUser.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken: cancellation);
                       }).WithMessage("User id not valid.");
            }
        }
    }
}
