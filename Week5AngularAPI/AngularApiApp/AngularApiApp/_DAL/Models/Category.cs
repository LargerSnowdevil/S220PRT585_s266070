using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApiApp._DAL.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        public String Name { get; set; }

        public String Code { get; set; }

        public List<Product> Products { get; set;}
    }
}