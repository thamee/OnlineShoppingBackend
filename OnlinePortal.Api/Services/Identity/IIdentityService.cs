using OnlinePortal.Api.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePortal.Api.Services.Identity
{
   public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterUserAsync(UserRegistrationRequest request);

        Task<AuthenticationResult> LoginAsync(UserLoginRequest request);

        Task<AuthenticationResult> RegisterSellersAsync(UserRegistrationRequest request);
    }
}
