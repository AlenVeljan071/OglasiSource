using AutoMapper;
using MediatR;
using OglasiSource.Api.Cqrs.Commands.Comment;
using OglasiSource.Core.Interfaces;

namespace OglasiSource.Api.Handlers.Comment
{
    public class UpdateCommentHandler : IRequestHandler<UpdateCommentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateCommentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _unitOfWork.Repository<Core.Entities.Comment>()!.GetByIdAsync(request.Id);
            _mapper.Map<UpdateCommentCommand, Core.Entities.Comment>(request, comment!);
            _unitOfWork.Repository<Core.Entities.Comment>()?.Update(comment!);
            await _unitOfWork.Complete();

            return new Unit();
        }
    }
}
