using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoMartDb
{



    public class ProductImage
    {
        public int Id { get; set; }
        public string? Src { get; set; }
        public string? Src_small { get; set; }

        public string? Src_medium { get; set; }
        public string? Src_large { get; set; }
    }

    public class ProductVariation
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("sku")]
        public string? Sku { get; set; }

        [JsonProperty("regular_price")]
        public double? Price { get; set; }
    }

    public class Product
    {

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }


        [JsonProperty("sku")]
        public string? Sku { get; set; }


        [JsonProperty("regular_price")]
        public double? Price { get; set; }


        [JsonProperty("in_stock")]
        public bool? InStock { get; set; }

        [JsonProperty("images")]
        public List<ProductImage>? Images { get; set; }



    }
}

