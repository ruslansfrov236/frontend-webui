using frontend.entity.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace frontend.entity
{
    public class Feauters:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Files> Files { get; set; }
    }
}
