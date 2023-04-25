using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OglasiSource.Api.Cqrs.Commands.Advertisement;
using OglasiSource.Core.Interfaces;
using OglasiSource.Infrastructure.Data.Context;

namespace OglasiSource.Api.Cqrs.Commands.Image
{
    public class DeleteImageCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public class DeleteImageCommandValidator : AbstractValidator<DeleteImageCommand>
        {
            private readonly DbWriteContext _writeContext;
            public DeleteImageCommandValidator(DbWriteContext writeContext)
            {
                _writeContext = writeContext;

                this.ClassLevelCascadeMode = CascadeMode.Stop;
                RuleFor(x => x.Id).NotEmpty()
                      .MustAsync(async (id, cancellation) =>
                      {
                          return await _writeContext.SavedImages.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken: cancellation);
                      }).WithMessage("Images with this id doesn't exists.");
            }
        }
    }
}
