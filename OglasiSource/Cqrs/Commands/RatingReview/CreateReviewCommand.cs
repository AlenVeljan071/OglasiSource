using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OglasiSource.Core.Interfaces;
using OglasiSource.Core.Responses;
using OglasiSource.Infrastructure.Data.Context;

namespace OglasiSource.Api.Cqrs.Commands.RatingReview
{
    public class CreateReviewCommand : IRequest<CreateResponse>
    {
        public int EntityTypeReviewId { get; set; }
        public int EntityTypeId { get; set; }
        public string Comment { get; set; }
    }

    public class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
    {
        private readonly DbWriteContext _writeContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITokenService _tokenService;

        public CreateReviewCommandValidator(DbWriteContext writeContext, IHttpContextAccessor httpContextAccessor, ITokenService tokenService)
        {
            _writeContext = writeContext;
            _httpContextAccessor = httpContextAccessor;
            _tokenService = tokenService;

            ClassLevelCascadeMode = CascadeMode.Stop;
            int userId = _tokenService.ReadUserId(_httpContextAccessor.HttpContext!.Request.Headers["Authorization"][0]!);

            RuleFor(x => x.EntityTypeReviewId).NotEmpty()
                   .MustAsync(async (id, cancellation) =>
                   {
                       return await _writeContext.EntityTypeReview.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken: cancellation);
                   }).WithMessage("Entity type id not valid.");
           

            RuleFor(x => x.Comment)
                .NotEmpty()
                .WithMessage("Comment must not be empty.");
        }

    }
}
