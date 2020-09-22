using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPProject.Models.Entities;

namespace VPProject.Data.Repository
{
    public partial class VPContext : DataContext, IDisposable
    {
        public VPContext(DbContextOptions<VPContext> options) : base(options)
        {

        }
        public virtual DbSet<Country> Country { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<CountrySetting>().ToTable("CountrySetting");
            modelBuilder.Entity<CountryHoliday>().ToTable("CountryHoliday");
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
