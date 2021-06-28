using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePortal.Api.Options
{
    /// <summary>
    /// Jwt Setting Option
    /// </summary>
    public class JwtSettings
    {
        /// <summary>
        /// Client Secret
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Token Life Time
        /// </summary>
        public TimeSpan TokenLifeTime { get; set; }


    }
}
