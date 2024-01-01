using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using frontend.entity.Customers;
using Microsoft.AspNetCore.Http;

namespace frontend.entity
{
    public class Files:BaseEntity
    {
    
        public string PhotoPath { get; set; }
        public int FeaturedWorkComponentId { get; set; }
        public int Order { get; set; }
        public Feauters Feauters { get; set; }

        [NotMapped] 

        public IFormFile file { get; set; } 



    }
}
