using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager.Models
{
    public class MovieModel
    {
        public int movieID { get; set; }

        [Display(Name = "Title")]
        public String movieName { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime releaseDate { get; set; }

        [Display(Name = "Director")]
        public String directorName { get; set; }

        [Display(Name = "Contact")]
        [EmailAddress]
        public String contactAdress { get; set; }

        [Display(Name = "Language")]
        public language movieLanguage { get; set; }

        [Display(Name = "Catagory")]
        public int catagoryID { get; set; }

        [Display(Name = "Catagory")]
        public String catagory { get; set; }
    }
}
