using FoodTruck.Core.Application.Interfaces.Persistence;
using FoodTruck.Core.Domain.Entities;
using FoodTruck.Infraestructure.Persistence.Base;
using FoodTruck.Infraestructure.Persistence.Context;

namespace FoodTruck.Infraestructure.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product> , IProductRepository
    {
        private readonly ApplicationContext _context;
        public ProductRepository(ApplicationContext context) : base(context) 
        {
            _context = context;
        }
    }
}
