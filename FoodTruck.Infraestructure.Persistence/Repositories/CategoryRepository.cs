using FoodTruck.Core.Application.Interfaces.Persistence;
using FoodTruck.Core.Domain.Entities;
using FoodTruck.Infraestructure.Persistence.Base;
using FoodTruck.Infraestructure.Persistence.Context;

namespace FoodTruck.Infraestructure.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationContext _context;

        public CategoryRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
