using frontend.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.business.Application.Dtos.Feauters
{
    public class CreateFeautersDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Files> Files { get; set; }
    }
}
