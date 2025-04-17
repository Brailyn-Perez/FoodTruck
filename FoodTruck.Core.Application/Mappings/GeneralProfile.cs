using AutoMapper;
using FoodTruck.Core.Application.Features.User.Commands.CreateUserCommand;
using FoodTruck.Core.Domain.Entities;

namespace FoodTruck.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region Commands
            CreateMap<CreateUserCommand, User>();
            #endregion
        }
    }
}
