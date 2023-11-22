using MangoMartDb.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace MangoMartDbService.Services
{
    public interface IDatabaseService
    {
        Task<List<Product>> Get(int page);

        Task<int> GetPageTotal();

    }
}
