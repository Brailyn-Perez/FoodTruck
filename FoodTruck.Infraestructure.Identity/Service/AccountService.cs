using FoodTruck.Core.Application.DTOs.Users;
using FoodTruck.Core.Application.Interfaces.Application.Identity;
using FoodTruck.Core.Application.Wrappers;
using FoodTruck.Core.Domain.Settings;
using FoodTruck.Infraestructure.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace FoodTruck.Infraestructure.Identity.Service
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JWTSttings _jwtSetting;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public AccountService(RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, JWTSttings jwtsetting)
        {
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtSetting = jwtsetting;
        }

        public async Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<string>> RegisterAsync(RegisterRequest request, string origin)
        {
            throw new NotImplementedException();
        }
    }
}
