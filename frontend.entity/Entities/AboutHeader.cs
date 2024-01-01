﻿using Microsoft.AspNetCore.Http;
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
    public class AboutHeader:BaseEntity
    {
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? FilePath { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? Text { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? UrlText { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? Url { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? Description { get; set; }
    }
}
