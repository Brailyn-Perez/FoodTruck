using FoodTruck.Core.Application.DTOs.Users;
using FoodTruck.Core.Application.Wrappers;

namespace FoodTruck.Core.Application.Interfaces.Application.Identity
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress);
        Task<Response<string>> RegisterAsync(RegisterRequest request, string origin);

    }
}
