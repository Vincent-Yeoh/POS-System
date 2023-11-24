using MangoMartDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace POS_System.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {

        public int? Id { get; set; }
        public string? Name { get; set; }

        private string? _sku;
        public string? Sku
        {
            get => _sku;
            set => _sku = string.IsNullOrEmpty(value) ? "N/A" : value;
        }

        private double _price = 0.0;

        public List<string>? Options { get; set; }
        public double? Price
        {
            get => _price;
            set => _price = value ?? 0.0;
        }
        public bool? InStock { get; set; }
        public string? Image { get; set; }


        public static ProductViewModel MapProduct(Product product)
        {
            var options = product.Options?.Split(',').ToList();
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Sku = product.Sku,
                InStock = product.InStock,
                Options = options,
                Image = product.Image,
            };
        }
    }
}
