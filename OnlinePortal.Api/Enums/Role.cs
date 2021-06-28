using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePortal.Api.Enums
{
    /// <summary>
    /// The Enum Filter Option
    /// </summary>
    public enum Roles
    {
        /// <summary>
        /// FilterOptions All(1), Archived(2), Active(3)
        /// </summary>
        [Description("admin")]
        Admin = 1,

        /// <summary>
        /// Archived
        /// </summary>
        [Description("customer")]
        Customer = 2,

        
    }
}
