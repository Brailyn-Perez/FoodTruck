using FoodTruck.Core.Application.Parameters;

namespace FoodTruck.Core.Application.Features.Category.Queries.GetAllCategory
{
    public class GetAllCategoryParameters : RequestParameter
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
