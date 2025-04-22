using FoodTruck.Core.Application.DTOs.Users;
using FoodTruck.Core.Application.Enums;
using FoodTruck.Core.Application.Exceptions;
using FoodTruck.Core.Application.Interfaces.Application.Identity;
using FoodTruck.Core.Application.Wrappers;
using FoodTruck.Core.Domain.Settings;
using FoodTruck.Infraestructure.Identity.Helpers;
using FoodTruck.Infraestructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

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
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new ApiException($"user not found {request.Email}");
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                throw new ApiException($"");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateJWTToken(user);

            AuthenticationResponse response = new AuthenticationResponse();

            // Fix for CS0029: Cannot implicitly convert type 'string' to 'int'
            // The `Id` property in `AuthenticationResponse` is of type `int`, but `user.Id` is of type `string`.
            // To fix this, we need to convert `user.Id` to an integer.

            response.Id = int.TryParse(user.Id, out var userId) ? userId : 0; // Default to 0 if conversion fails
            response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = user.Email;
            response.UserName = user.UserName;

            var rolesList = await _userManager.GetRolesAsync(user);
            response.Roles = rolesList.ToList();

            response.IsVerified = user.EmailConfirmed;
            var refreshToken = GenerateRefreshToken(ipAddress);

            response.RefreshToken = refreshToken.Token;
            return new Response<AuthenticationResponse>(response, $"{user.Name}");
        }

        public async Task<Response<string>> RegisterAsync(RegisterRequest request, string origin)
        {
            var userWhitTheSameUserName = await _userManager.FindByNameAsync(request.Name);

            if (userWhitTheSameUserName != null)
                throw new ApiException($"");

            var user = new ApplicationUser
            {
                Email = request.Email,
                Name = request.Name,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var userWhitTheSameEmail = await _userManager.FindByEmailAsync(request.Email);

            if (userWhitTheSameEmail != null)
                throw new ApiException($"");
            else
            {
                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Roles.User.ToString());
                    return new Response<string>(user.Id, message: $"User created {request.UserName}");
                }
                else
                {
                    throw new ApiException($"{result.Errors}");
                }
            }


            throw new NotImplementedException();
        }

        private async Task<JwtSecurityToken> GenerateJWTToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }

            string ipAddress = IpHelper.GetIpAddress();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id),
                new Claim("ip",ipAddress),
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSetting.Issuer,
                audience: _jwtSetting.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSetting.DurationInMinutes),
                signingCredentials: signingCredentials
                );

            return jwtSecurityToken;

        }

        private RefreshToken GenerateRefreshToken(string ipAddress)
        {
            return new RefreshToken
            {
                Token = RandomTokenString(),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now,
                CreatedByIp = ipAddress
            };
        }

        private string RandomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return BitConverter.ToString(randomBytes).Replace("-", "");

        }
    }
}
