namespace FoodTruck.Core.Application.Interfaces.Application
{
    public interface IGenericService<viewModel>
    {
        public Task<viewModel> GetByIdAsync(int id);
        public Task<IEnumerable<viewModel>> GetAllAsync();
    }
}
