using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  frontend.business.Application.Dtos.About
{
    public class CreateAboutDto
    {
        [Required(ErrorMessage = "zorunlu alan ")]
        public string Title { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string Description { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string FilePath { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
    }
}
