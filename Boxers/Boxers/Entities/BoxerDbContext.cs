﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Boxers.Entities
{
    public class BoxerDbContext : DbContext
    {        private string _connectionString = "Server = .\\SQLEXPRESS; Initial Catalog = BoxerDbStorage; Integrated Security = True;Encrypt=False;" +
                "TrustServerCertificate=True;MultipleActiveResultSets=True";
        public DbSet<Boxer> Boxers { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boxer>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Boxer>()
               .Property(x => x.Weight)
               .IsRequired()
               .HasMaxLength(3);

            modelBuilder.Entity<Boxer>()
               .Property(x => x.Wins)
               .IsRequired()
               .HasMaxLength(3);


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