using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularAPIApp.Models
{

    public enum Language
    {
        English,
        Japanese,
        Chinese
    }

    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Product Name")]
        public String Name { get; set; }

        [Display(Name = "Quantity")]
        [Range(0, Int32.MaxValue)]
        public int Quantity { get; set; }

        [Display(Name = "Langauge")]
        public Language Language { get; set; }

        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}
