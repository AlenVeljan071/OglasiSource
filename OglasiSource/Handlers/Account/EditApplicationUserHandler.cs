using AutoMapper;
using MediatR;
using OglasiSource.Api.Cqrs.Commands.Account;
using OglasiSource.Core.Interfaces;

namespace OglasiSource.Api.Handlers.Account
{
    public class EditApplicationUserHandler : IRequestHandler<EditAccountCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EditApplicationUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(EditAccountCommand request, CancellationToken cancellationToken)
        {

            var applicationUser = await _unitOfWork.Repository<Core.Entities.ApplicationUser>()!.GetByIdAsync(request.Id);
            _mapper.Map<EditAccountCommand, Core.Entities.ApplicationUser>(request, applicationUser!);
            _unitOfWork.Repository<Core.Entities.ApplicationUser>()!.Update(applicationUser!);
            await _unitOfWork.Complete();
            return new Unit();
        }
    }
}
