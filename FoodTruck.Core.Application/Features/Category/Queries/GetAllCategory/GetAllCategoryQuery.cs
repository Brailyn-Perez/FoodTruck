using FoodTruck.Core.Application.DTOs.Category;
using MediatR;

namespace FoodTruck.Core.Application.Features.Category.Queries.GetAllCategory
{
    public class GetAllCategoryQuery : IRequest<List<CategoryDTO>>
    {

    }
}
