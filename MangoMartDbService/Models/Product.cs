using MangoMartDb.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoMartDb.Models
{
    public class Product
    {
        public string? Id { get; set; }

        public string? Name { get; set; }

        public string? Sku { get; set; }

        public double? Price { get; set; }

        public bool? InStock { get; set; }

        public string? ImageFilePath { get; set; }


        public async static Task<Product> MapDTO(ProductDTO DTO)
        {
            return new Product
            {
                Id = DTO.Id,
                Name = DTO.Name,
                Sku = DTO.Sku,
                Price = DTO.Price,
                InStock = DTO.InStock,
                ImageFilePath = await Utility.DownloadImageAsFile(DTO.Images?.FirstOrDefault()?.Src!, "Images"),
            };
        }

    }

  


}
