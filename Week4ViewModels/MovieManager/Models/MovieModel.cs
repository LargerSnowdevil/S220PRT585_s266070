using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager.Models
{
    public class MovieModel
    {
        public int movieID { get; set; }

        public String movieName { get; set; }

        public DateTime releaseDate { get; set; }

        public String directorName { get; set; }

        public String contactAdress { get; set; }

        public language movieLanguage { get; set; }

        public int catagoryID { get; set; }
    }
}
