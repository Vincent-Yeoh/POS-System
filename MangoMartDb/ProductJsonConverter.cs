using MangoMartDb.DTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoMartDb
{
    internal class ProductJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ProductDTO);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            string price;
         
            JObject jObject = JObject.Load(reader);
            try
            {
                price = (string)jObject["regular_price"]!;
            }
            catch
            {
                price = "0";
            }
            Console.WriteLine(price);
            ProductDTO product = new ProductDTO
            {
                Id = (string)jObject["id"],
                Name = (string)jObject["name"],
  
            };
            return product;
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
