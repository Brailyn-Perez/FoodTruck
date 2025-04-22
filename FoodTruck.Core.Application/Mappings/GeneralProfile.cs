using AutoMapper;
using FoodTruck.Core.Application.DTOs.Category;
using FoodTruck.Core.Application.Features.Category.Commands.CreateCategoryCommand;
using FoodTruck.Core.Application.Features.Category.Commands.UpdateCategoryCommand;
using FoodTruck.Core.Application.Features.User.Commands.CreateUserCommand;
using FoodTruck.Core.Domain.Entities;

namespace FoodTruck.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {

            #region DTOS
            CreateMap<Category, CategoryDTO>();
            #endregion

            #region Commands
            CreateMap<CreateUserCommand, User>();
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();
            #endregion
        }
    }
}
