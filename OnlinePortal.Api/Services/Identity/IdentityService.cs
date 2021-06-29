using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using OnlinePortal.Api.Enums;
using OnlinePortal.Api.Models.Identity;
using OnlinePortal.Api.Options;
using OnlinePortal.Api.Services.Identity;
using OnlineShoppingDbContext;
using OnlineShoppingDbContext.Entities.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlinePortal.Api.Services
{
    public class IdentityService: IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly JwtSettings _jwtSettings;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly ApplicationDbContext _dataContext;

        public IdentityService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, JwtSettings jwtSettings, TokenValidationParameters tokenValidationParameters, ApplicationDbContext dataContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings;
            _tokenValidationParameters = tokenValidationParameters;
            _dataContext = dataContext;
        }
        /// <summary>
        /// Method to register the user
        /// </summary>
        public async Task<AuthenticationResult> RegisterUserAsync(UserRegistrationRequest request)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);

            if (existingUser != null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User with the Email Address Already Exits" }
                };
            }
          
            var newUser = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.Email,
                Id = Guid.NewGuid().ToString()

            };

            var createdUser = _userManager.CreateAsync(newUser, request.Password);

            if (!createdUser.Result.Succeeded)
            {
                return new AuthenticationResult
                {
                    Errors = createdUser.Result.Errors.Select(x => x.Description)
                };
            }


           

            return await GenerateAuthenticationResultForUserAsync(newUser);

        }

        public async Task<AuthenticationResult> RegisterSellersAsync(UserRegistrationRequest request)
        {
            bool x = await _roleManager.RoleExistsAsync("Sellers");
            if (!x)
            {
                var role = new ApplicationRole
                {
                    Name = "Sellers",
                    Id = Guid.NewGuid().ToString()
                };
                await _roleManager.CreateAsync(role);
                   
            }
            var existingUser = await _userManager.FindByEmailAsync(request.Email);

            if (existingUser != null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User with the Email Address Already Exits" }
                };
            }

            var newUser = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.Email,
                Id = Guid.NewGuid().ToString()

            };

            var createdUser = _userManager.CreateAsync(newUser, request.Password);
            await _userManager.AddToRoleAsync(newUser, "Sellers");

            if (!createdUser.Result.Succeeded)
            {
                return new AuthenticationResult
                {
                    Errors = createdUser.Result.Errors.Select(x => x.Description)
                };
            }




            return await GenerateAuthenticationResultForUserAsync(newUser);

        }

        private async Task<AuthenticationResult> GenerateAuthenticationResultForUserAsync(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var claims = new List<Claim>
            {
                new Claim(type: JwtRegisteredClaimNames.Sub,value: user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("id", user.Id)
            };

            var userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
                var role = await _roleManager.FindByNameAsync(userRole);
                if (role == null) continue;
                var roleClaims = await _roleManager.GetClaimsAsync(role);

                foreach (var roleClaim in roleClaims)
                {
                    if (claims.Contains(roleClaim))
                        continue;

                    claims.Add(roleClaim);
                }
            }


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),

                Expires = DateTime.Now.Add(_jwtSettings.TokenLifeTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), algorithm: SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

           

            await _dataContext.SaveChangesAsync();
            return new AuthenticationResult
            {
                Status = true,
                Token = tokenHandler.WriteToken(token),
                Id = user.Id
            };
        }

        public async Task<AuthenticationResult> LoginAsync(UserLoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User does not exist" }
                };
            }

           
            var userHasValidPassword = _userManager.CheckPasswordAsync(user, request.Password);

            if (!userHasValidPassword.Result)
                return new AuthenticationResult
                {
                    Errors = new[] { "Email/PassWord combination is wrong!" }
                };

            return await GenerateAuthenticationResultForUserAsync(user);
        }
        




        }


    }



