using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OglasiSource.Core.Constants;
using OglasiSource.Core.Interfaces;
using OglasiSource.Core.Responses;
using OglasiSource.Infrastructure.Data.Context;

namespace OglasiSource.Api.Cqrs.Commands.Comment
{
    public class CreateCommentCommand : IRequest<CreateResponse>
    {
        public int EntityTypeCommentId { get; set; }
        public int EntityTypeId { get; set; }
        public string CommentContent { get; set; }


        public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
        {
            private readonly DbWriteContext _writeContext;
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly ITokenService _tokenService;

            public CreateCommentCommandValidator(DbWriteContext writeContext, IHttpContextAccessor httpContextAccessor, ITokenService tokenService)
            {
                _writeContext = writeContext;
                _httpContextAccessor = httpContextAccessor;
                _tokenService = tokenService;

                ClassLevelCascadeMode = CascadeMode.Stop;

                int companyUserId = _tokenService.ReadUserId(_httpContextAccessor.HttpContext!.Request.Headers["Authorization"][0]!);
               

                RuleFor(x => x.EntityTypeCommentId).NotEmpty()
                       .MustAsync(async (id, cancellation) =>
                       {
                           return await _writeContext.EntityTypeComment.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken: cancellation);

                       }).WithMessage("EntityTypeCommentId type id not valid.");

                When(x => x.EntityTypeCommentId == DictionaryExtensions.GetValues(Core.Constants.Constants.EntityTypeComment).First(c => c.Name == Core.Constants.Constants.User).Id, () =>
                {
                    RuleFor(x => x.EntityTypeId)
                       .MustAsync(async (id, cancellation) =>
                       {
                           return await _writeContext.ApplicationUser.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken: cancellation);

                       }).WithMessage("User with this id doesn't exist.");
                });

                RuleFor(x => x.CommentContent)
                    .NotEmpty()
                    .Length(0, 112)
                    .WithMessage("Comment should have 112 chars at most.");
            }
        }
    }
}
