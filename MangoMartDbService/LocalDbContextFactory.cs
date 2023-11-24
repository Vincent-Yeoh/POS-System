using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MangoMartDbService
{

    internal class LocalDbContextFactory
    {
        private readonly string _connectionString;
        public LocalDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public LocalDbContext CreateDbContext()
        {
            return new LocalDbContext(_connectionString);
        }
    }
}
