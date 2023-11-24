using MangoMartDb.DTOs;
using MangoMartDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoMartDbService
{
    public class LocalDbContext : DbContext
    {

        //To perform ef database migrations, run the following commands in PMC
        //dotnet ef migrations add [MigrationName] --project MangoMartDbService --startup-project ApiDriver --verbose


        private string _connectionString;
        public LocalDbContext(string connectionString = "")
        {
            _connectionString = string.IsNullOrEmpty(connectionString) ? "Data Source=MangoLocalDb.db" : connectionString;
        }
        public DbSet<Product>? Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
