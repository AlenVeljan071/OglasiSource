using AutoMapper;
using MediatR;
using OglasiSource.Api.Cqrs.Queries.Account;
using OglasiSource.Core.Interfaces.Repositories;
using OglasiSource.Core.Responses.Account;
using OglasiSource.Core.Specifications.Account;

namespace OglasiSource.Api.Handlers.Account
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, ApplicationUserResponse>
    {
        private readonly IReadGenericRepository<Core.Entities.ApplicationUser> _readGenericRepository;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IReadGenericRepository<Core.Entities.ApplicationUser> readGenericRepository, IMapper mapper)
        {
            _readGenericRepository = readGenericRepository;
            _mapper = mapper;
        }

        public async Task<ApplicationUserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _readGenericRepository.GetEntityWithSpec(new ApplicationUserSpecification(request.Id));
            var response = _mapper.Map<Core.Entities.ApplicationUser, ApplicationUserResponse>(user!);
           
            return response;
        }
    }
}
