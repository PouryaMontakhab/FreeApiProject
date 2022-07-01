using System;
using FreeApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FreeApiProject.Data
{
    public class MovieContext : DbContext
    {
        public DbSet<Favorite> favorites { get; set; }

        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
