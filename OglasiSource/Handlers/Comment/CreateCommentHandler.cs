using AutoMapper;
using MediatR;
using OglasiSource.Api.Cqrs.Commands.Comment;
using OglasiSource.Core.Interfaces;
using OglasiSource.Core.Responses;

namespace OglasiSource.Api.Handlers.Comment
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, CreateResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateCommentHandler(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenService = tokenService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<CreateResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            int companyUserId = _tokenService.ReadUserId(_httpContextAccessor.HttpContext!.Request.Headers["Authorization"][0]!);
            var comment = _mapper.Map<CreateCommentCommand, Core.Entities.Comment>(request);
            comment.ApplicationUserId = companyUserId;
            _unitOfWork.Repository<Core.Entities.Comment>()?.Add(comment);
            await _unitOfWork.Complete();

            return new CreateResponse { Id = comment.Id };
        }
    }
}
