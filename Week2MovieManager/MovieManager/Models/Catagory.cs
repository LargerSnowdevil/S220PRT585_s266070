using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager.Models
{
    public class Catagory
    {
        public int id { get; set; }

        [Display(Name = "Name")]
        public String name { get; set; }

    }
}
