using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OglasiSource.Core.Interfaces;
using OglasiSource.Core.Responses.Comment;
using OglasiSource.Infrastructure.Data.Context;

namespace OglasiSource.Api.Cqrs.Queries.Comment
{
    public class GetCommentByIdQuery : IRequest<CommentResponse>
    {
        public int Id { get; set; }
    }

    public class GetCommentByIdCommandValidator : AbstractValidator<GetCommentByIdQuery>
    {
        private readonly DbReadContext _readContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITokenService _tokenService;

        public GetCommentByIdCommandValidator(DbReadContext readContext, ITokenService tokenService, IHttpContextAccessor httpContextAccessor)
        {
            _readContext = readContext;
            _httpContextAccessor = httpContextAccessor;
            _tokenService = tokenService;

            int userId = _tokenService.ReadUserId(_httpContextAccessor.HttpContext!.Request.Headers["Authorization"][0]);

            RuleFor(x => x.Id).NotEmpty()
                 .MustAsync(async (id, cancellation) =>
                 {
                     return await _readContext.Comment.AsNoTracking().AnyAsync(x => x.Id == id && x.ApplicationUserId == userId, cancellationToken: cancellation);

                 }).WithMessage("Comment with this id doesn't exists.");
        }
    }
}
