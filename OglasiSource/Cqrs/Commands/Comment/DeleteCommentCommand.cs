using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OglasiSource.Infrastructure.Data.Context;

namespace OglasiSource.Api.Cqrs.Commands.Comment
{
    public class DeleteCommentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }

    public class DeleteBrokerReviewCommandValidator : AbstractValidator<DeleteCommentCommand>
    {
        private readonly DbWriteContext _writeContext;
        public DeleteBrokerReviewCommandValidator(DbWriteContext writeContext)
        {
            _writeContext = writeContext;

            RuleFor(x => x.Id).NotEmpty()
                  .MustAsync(async (id, cancellation) =>
                  {
                      return await _writeContext.Comment.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken: cancellation);

                  }).WithMessage("Comment id not valid.");
        }
    }
}
