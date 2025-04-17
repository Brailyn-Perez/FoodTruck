using FoodTruck.Core.Application.Interfaces.Persistence;
using FoodTruck.Core.Domain.Entities;
using FoodTruck.Infraestructure.Persistence.Base;
using FoodTruck.Infraestructure.Persistence.Context;

namespace FoodTruck.Infraestructure.Persistence.Repositories
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        private readonly ApplicationContext _context;

        public SaleRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
