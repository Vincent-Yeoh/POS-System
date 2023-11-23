using MangoMartDb.Models;
using POS_System_Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System
{
    public class ProductViewModel : BaseViewModel
    {

        public string? Id { get; set; }
        public string? Name { get; set; }

        private string? _sku;
        public string? Sku
        {
            get => _sku;
            set => _sku = string.IsNullOrEmpty(value) ? "N/A" : value;
        }

        private double _price = 0.0;


        public double? Price
        {
            get => _price;
            set => _price = value ?? 0.0;
        }
        public bool? InStock { get; set; }
        public string? Image { get; set; }


        public static ProductViewModel MapProduct(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Sku = product.Sku,
                InStock = product.InStock,
                Image = product.Image,
            };
        }
    }
}
