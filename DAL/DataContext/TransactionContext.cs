using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DataContext
{
    public class TransactionContext : DbContext
    {
        public TransactionContext()
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DataSource=mydatabase.db;");
        }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
