using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OglasiSource.Infrastructure.Data.Context;

namespace OglasiSource.Api.Cqrs.Commands.Comment
{
    public class UpdateCommentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string CommentContent { get; set; }

    }

    public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
    {
        private readonly DbWriteContext _writeContext;
        public UpdateCommentCommandValidator(DbWriteContext writeContext)
        {
            _writeContext = writeContext;

            RuleFor(x => x.Id).NotEmpty()
                   .MustAsync(async (id, cancellation) =>
                   {
                       return await _writeContext.Comment.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken: cancellation);

                   }).WithMessage("Comment id not valid.");

            RuleFor(x => x.CommentContent)
                   .NotEmpty()
                   .Length(0, 112)
                   .WithMessage("Comment should have 112 chars at most.");
        }
    }
}
