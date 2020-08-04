using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager.Data

{
    public enum language
    {
        English,
        Japanese,
        Chinese
    }
    public class Movie
    {
        public int id { get; set; }

        public String movieName { get; set; }

        public DateTime releaseDate { get; set; }

        public String directorName { get; set; }

        public String contactAdress { get; set; }

        public language movieLanguage { get; set; }

        public String catagory { get; set; }
    }
}
