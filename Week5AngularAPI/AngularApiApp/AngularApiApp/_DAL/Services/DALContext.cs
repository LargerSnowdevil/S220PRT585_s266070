using AngularApiApp._DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApiApp._DAL.Services
{
    public class DALContext : DbContext
    {
        public DALContext(DbContextOptions<DALContext> options) : base(options) 
        {
            
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categorys { get; set; }
    }
}
