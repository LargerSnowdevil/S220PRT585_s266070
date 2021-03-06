﻿using Microsoft.EntityFrameworkCore;
using MovieManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager.Data
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext(DbContextOptions<MovieDBContext> options) : base(options) {

        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Catagory> Catagorys { get; set; }
    }
}
