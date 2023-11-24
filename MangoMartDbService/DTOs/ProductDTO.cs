using MangoMartDbService.DTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MangoMartDb.DTOs
{

    public class Collection
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }


    public class Links
    {
        [JsonPropertyName("self")]
        public List<Self> Self { get; set; }

        [JsonPropertyName("collection")]
        public List<Collection> Collection { get; set; }
    }


    public class Self
    {
        [JsonPropertyName("href")]
        public string? Href { get; set; }
    }

    public class ProductDTO
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("date_modified")]
        public DateTime? DateModified { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("sku")]
        public string? Sku { get; set; }

        [JsonPropertyName("regular_price")]
        public int? RegularPrice { get; set; }

        [JsonPropertyName("sale_price")]
        public string? SalePrice { get; set; }


        [JsonPropertyName("stock_quantity")]
        public object? StockQuantity { get; set; }

        [JsonPropertyName("in_stock")]
        public bool? InStock { get; set; }


        [JsonPropertyName("weight")]
        public string? Weight { get; set; }

        [JsonPropertyName("tags")]
        public List<object>? Tags { get; set; }

        [JsonPropertyName("images")]
        public List<ImageDTO>? Images { get; set; }

        [JsonPropertyName("attributes")]
        public List<AttributeDTO>? Attributes { get; set; }


        [JsonPropertyName("minimum_quantity")]
        public object? MinimumQuantity { get; set; }

        [JsonPropertyName("maximum_quantity")]
        public object? MaximumQuantity { get; set; }



    }

  

    


}

