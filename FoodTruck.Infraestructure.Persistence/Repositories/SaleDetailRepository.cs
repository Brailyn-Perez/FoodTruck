using FoodTruck.Core.Application.Interfaces.Persistence;
using FoodTruck.Core.Domain.Entities;
using FoodTruck.Infraestructure.Persistence.Base;
using FoodTruck.Infraestructure.Persistence.Context;

namespace FoodTruck.Infraestructure.Persistence.Repositories
{
    public class SaleDetailRepository : GenericRepository<SaleDetail>, ISaleDetailsRepository
    {
        private readonly ApplicationContext _context;

        public SaleDetailRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
