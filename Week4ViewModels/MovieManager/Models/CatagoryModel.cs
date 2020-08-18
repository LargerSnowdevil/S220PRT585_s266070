using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager.Models
{
    public class CatagoryModel
    {
        public int catagoryID { get; set; }

        [Display(Name = "Catagory")]
        public String name { get; set; }
    }
}
