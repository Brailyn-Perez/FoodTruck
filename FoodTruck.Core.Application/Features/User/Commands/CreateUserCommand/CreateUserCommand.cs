using AutoMapper;
using FoodTruck.Core.Application.Interfaces.Persistence;
using FoodTruck.Core.Application.Wrappers;
using MediatR;

namespace FoodTruck.Core.Application.Features.User.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<Response<int>>
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string Rol { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<int>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var newRecord = _mapper.Map<Domain.Entities.User>(request);
            await _repository.AddAsync(newRecord);
            return new Response<int>(1);

        }
    }
}
