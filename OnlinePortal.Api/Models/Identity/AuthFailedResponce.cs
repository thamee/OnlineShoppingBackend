using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePortal.Api.Models.Identity
{
    
        /// <summary>
        /// AuthFaildResponce
        /// </summary>
        public class AuthFailedResponce
        {
            public IEnumerable<string> Errors { get; set; }
        }
    
}
