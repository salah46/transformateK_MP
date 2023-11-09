using Microsoft.EntityFrameworkCore;
using transformatek_MP.Models;

namespace transformatek_MP.Data
{
    public class TransforamTek_MP_Context : DbContext
    {
        public TransforamTek_MP_Context(DbContextOptions<TransforamTek_MP_Context> options)
    : base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; } = null!;
        public DbSet<Agent> Agent { get; set; } = null!;
        public DbSet<Affectation> Affectation { get; set; } = null!;
        public DbSet<Consigner> Consigner { get; set; } = null!;
        public DbSet<Point> Point { get; set; } = null!;
        public DbSet<Resultes> Resultes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Point>()
            .HasOne(p => p.Affectation)
            .WithOne()
            .HasForeignKey<Point>(p => p.Affectation_ID);

            modelBuilder.Entity<Consigner>()
              .HasOne(c => c.Affectation)
              .WithOne()
              .HasForeignKey<Consigner>(c => c.Affectation_ID);
        }
    }
}