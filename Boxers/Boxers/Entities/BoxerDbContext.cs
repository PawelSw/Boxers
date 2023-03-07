using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Boxers.Entities
{
    public class BoxerDbContext : DbContext
    {
        private string _connectionString = "Server = .\\SQLEXPRESS; Initial Catalog = BoxerDbStorage; Integrated Security = True;Encrypt=False;" +
                "TrustServerCertificate=True;MultipleActiveResultSets=True";
        public DbSet<Boxer> Boxers { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(x => x.Email)
                .IsRequired();

            modelBuilder.Entity<Role>()
                .Property(x => x.Name)
                .IsRequired();

            modelBuilder.Entity<Boxer>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Boxer>()
               .Property(x => x.Weight)
               .IsRequired();

            modelBuilder.Entity<Boxer>()
               .Property(x => x.Wins)
               .IsRequired();

            modelBuilder.Entity<Trainer>()
                .Property(r => r.FullName)
                .IsRequired()
                .HasMaxLength(50);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
