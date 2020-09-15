using AngularApiApp._DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApiApp._BLL.Models
{
    public class ProductBLLModel
    {
        public int ProductId { get; set; }

        public String Name { get; set; }

        public int Quantity { get; set; }

        public Language Language { get; set; }

        public CategoryBLLModel Category { get; set; }
    }
}
