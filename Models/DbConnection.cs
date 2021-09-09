using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooBookApp.Models
{
    public class DbConnection : DbContext
    {
        public DbConnection(DbContextOptions<DbConnection> options) : base(options)
        {
        }

        public DbSet<Employees> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>().HasIndex(e => e.FirstName).IsUnique();
        }
    }
}
