using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePortal.Api.Models.Identity
{
    /// <summary>
    /// Authentication Result
    /// </summary>
    public class AuthenticationResult
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public bool Status { get; set; }

        public String Id { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
