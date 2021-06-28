using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePortal.Api.Models.Sales
{
    public class CreateSalesDto
    {
        [Required]
        public int ProductId { get; set; }

        public int Quantity { get; set; }

    }
}
