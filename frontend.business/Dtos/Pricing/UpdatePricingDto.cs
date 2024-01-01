using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.business.Application.Dtos.Pricing
{
    public class UpdatePricingDto
    {
        public string id { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? PricingUser { get; set; }

        [Required(ErrorMessage = "zorunlu alan ")]
        public string? PriceCategory { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? TotalMemory { get; set; }

        public string? PricngName { get; set; }
    }
}
