using AngularApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApp.Data
{
    public class AngularAppDBContext : DbContext
    {
        public AngularAppDBContext(DbContextOptions<AngularAppDBContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
    }
}
