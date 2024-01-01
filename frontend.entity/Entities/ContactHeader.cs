using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using frontend.entity.Customers;


namespace frontend.entity
{
    public class ContactHeader:BaseEntity
    {
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? Content { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? Link { get; set; }


        public string? FilePath { get; set; }

        [NotMapped]
        public IFormFile? File { get; set; }
    }
}
