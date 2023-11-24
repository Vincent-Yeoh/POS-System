using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MangoMartDbService.DTOs
{
    public class ImageDTO
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("src")]
        public string Src { get; set; }

        [JsonPropertyName("alt")]
        public string Alt { get; set; }

        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("src_small")]
        public string SrcSmall { get; set; }

        [JsonPropertyName("src_medium")]
        public string SrcMedium { get; set; }

        [JsonPropertyName("src_large")]
        public string SrcLarge { get; set; }
    }
}
