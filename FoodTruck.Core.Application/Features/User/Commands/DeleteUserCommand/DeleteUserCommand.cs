using AutoMapper;
using FoodTruck.Core.Application.Interfaces.Persistence;
using FoodTruck.Core.Application.Wrappers;
using MediatR;

namespace FoodTruck.Core.Application.Features.User.Commands.DeleteUserCommand
{
    public class DeleteUserCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Response<int>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IUserRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public Task<Response<int>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
