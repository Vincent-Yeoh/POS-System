using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MangoMartDbService.DTOs
{
    public class AttributeDTO
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("position")]
        public int? Position { get; set; }

        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }

        [JsonPropertyName("variation")]
        public bool? Variation { get; set; }

        [JsonPropertyName("options")]
        public List<string> Options { get; set; }

    }
}
