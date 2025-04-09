using FoodTruck.Core.Application.Interfaces.Application;
using FoodTruck.Core.Application.Interfaces.Persistence;
using FoodTruck.Core.Application.ViewModels.User;

namespace FoodTruck.Core.Application.Services
{
    public class UserService : IGenericService<UserViewModel>
    {
        private readonly IUserRepository _Repository;

        public UserService(IUserRepository userRepository)
        {
            _Repository = userRepository;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllAsync()
        {
            var user = await _Repository.GetAllAsync();
            var userViewModel = user.Select(u => new UserViewModel
            {
                id = u.id,
                name = u.name,
                email = u.email,
                password = u.password,
                Rol = u.Rol
            });
            return userViewModel;
        }

        public Task<UserViewModel> GetByIdAsync(int id)
        {
            var user = _Repository.GetByIdAsync(id);
            var userViewModel = new UserViewModel
            {
                id = user.Result.id,
                name = user.Result.name,
                email = user.Result.email,
                password = user.Result.password,
                Rol = user.Result.Rol
            };
            return Task.FromResult(userViewModel);
        }
    }
}
