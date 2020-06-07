using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
                .Entity<Transaction>()
                .Property(t => t.Status)
                .HasConversion(
                    s => s.ToString(),
                    m => (Status)Enum.Parse(typeof(Status), m));
        }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
