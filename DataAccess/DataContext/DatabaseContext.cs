using Core.Models;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess.DataContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<TransactionEntity>()
                .Property(t => t.Status)
                .HasConversion(
                    s => s.ToString(),
                    m => (Status)Enum.Parse(typeof(Status), m));
        }

        public DbSet<TransactionEntity> Transactions { get; set; }
    }
}
