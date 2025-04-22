using AutoMapper;
using FoodTruck.Core.Application.Interfaces.Persistence;
using FoodTruck.Core.Application.Wrappers;
using MediatR;

namespace FoodTruck.Core.Application.Features.User.Commands.UpdateUserCommand
{
    public class UpdateUserCommand : IRequest<Response<int>>
    {

    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response<int>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public Task<Response<int>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
