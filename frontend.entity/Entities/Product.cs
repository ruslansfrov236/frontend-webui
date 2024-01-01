using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using frontend.entity.Customers;


namespace  frontend.entity
{
    public class Product : BaseEntity
    {
        [Required(ErrorMessage = "zorunlu alan")]
        public string? FilePath { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }

        [Required(ErrorMessage = "zorunlu alan")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "zorunlu alan")]
        public string? Text { get; set; }
    }
}
