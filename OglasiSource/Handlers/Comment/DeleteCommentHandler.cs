using MediatR;
using OglasiSource.Api.Cqrs.Commands.Comment;
using OglasiSource.Core.Interfaces;

namespace OglasiSource.Api.Handlers.Comment
{
    public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCommentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _unitOfWork.Repository<Core.Entities.Comment>()!.GetByIdAsync(request.Id);
            _unitOfWork.Repository<Core.Entities.Comment>()?.Delete(comment!);
            await _unitOfWork.Complete();

            return new Unit();
        }
    }
}
