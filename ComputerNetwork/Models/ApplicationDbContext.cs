using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerNetwork.Models
{
    //zapewnia dostep do funkcjonalnosci Entity Framework Core
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        public DbSet<Router> Routers { get; set; }
        public DbSet<Switch> Switches { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Edge> Edges { get; set; }
        public DbSet<Network> Networks { get; set; }


    }
}
