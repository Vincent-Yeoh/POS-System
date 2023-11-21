using MangoMartDb.DTOs;
using MangoMartDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoMartDb
{
    internal class LocalDbContext : DbContext
    {
        private string _connectionString;
        public LocalDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string dbPath = Path.Combine(AppContext.BaseDirectory, "MangoLocalDb.mdf");
            //Console.WriteLine(dbPath);
           
            optionsBuilder.UseSqlite(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
