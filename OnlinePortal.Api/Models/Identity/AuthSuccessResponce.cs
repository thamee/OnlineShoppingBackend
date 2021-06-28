using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePortal.Api.Models.Identity
{
    public class AuthSuccessResponce
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }
    }
}
