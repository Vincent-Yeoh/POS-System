using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System
{
    public class ProductViewModel : ViewModel
    {

        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Sku { get; set; }
        public double? Price { get; set; }
        public bool? InStock { get; set; }
        public string? Image { get; set; }

    }
}
