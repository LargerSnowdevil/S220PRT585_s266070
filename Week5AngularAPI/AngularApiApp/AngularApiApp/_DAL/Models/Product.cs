using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApiApp._DAL.Models
{
    public enum Language
    {
        English,
        Japanese,
        Chinese
    }

    public class Product
    {
        public int ProductId { get; set; }

        public String Name { get; set; }

        public int Quantity { get; set; }

        public Language Language { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
