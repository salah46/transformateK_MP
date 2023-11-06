using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using transformatek_MP.Models;

namespace transformatek_MP.Data
{
    public class TransforamTek_MP_Context : DbContext
    {
        public DbSet<Admin> Admins { get; set; } = null!;
        public DbSet<Agent> Agent { get; set; } = null!;
        public DbSet<Affectation> Affectation { get; set; } = null!;
        public DbSet<Consigner> Consigner { get; set; } = null!;
        public DbSet<Point> Point { get; set; } = null!;
        public DbSet<Resultes> Resultes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=/home/salah/Desktop/transformatek_MP/Database/tt_mp_db");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Affectation>()
              .HasOne(a => a.Consigner)
              .WithOne()
              .HasForeignKey<Affectation>(a => a.Consigner_ID)


            // modelBuilder.Entity<Point>()
            // .HasOne(d => d.Affectation)
            // .WithOne()
            // .HasForeignKey<Affectation>(d => d.Affectation_ID);

            modelBuilder.Entity<Consigner>()
              .HasOne(c => c.Affectation)
              .WithOne()
              .HasForeignKey<Consigner>(c => c.Affectation_ID);
        }
    }
}