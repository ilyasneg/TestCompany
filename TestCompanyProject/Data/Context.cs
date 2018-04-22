using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestCompanyProject.Models;

namespace TestCompanyProject.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<StandInfo> StandInfos { get; set; }
        public DbSet<Stand> Stands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StandInfo>().HasKey(a => a.Id);
            modelBuilder.Entity<StandInfo>().ToTable("StandInfo");

            modelBuilder.Entity<Stand>().HasKey(a => a.Id);
            modelBuilder.Entity<Stand>().ToTable("Stand");
        }
    }
}
