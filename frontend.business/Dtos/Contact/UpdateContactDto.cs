using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.business.Application.Dtos.Contact
{
    public class UpdateContactDto
    {
        public string Id { get; set; }      
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? TitleWork { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? FullName { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? Telephone { get; set; }
    }
}
