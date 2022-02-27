using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Dtos.ProductDto
{
    public class PostProductDto : BaseEntityDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("isofferable")]
        public bool IsOfferable { get; set; }
        [JsonPropertyName("issold")]
        public bool IsSold { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        [JsonPropertyName("photo")]
        public string Photo { get; set; }
        [JsonPropertyName("brandid")]
        public int BrandId { get; set; }
        [JsonPropertyName("userid")]
        public int UserId { get; set; }

        [JsonPropertyName("colorid")]
        public int ColorId { get; set; }
        [JsonPropertyName("usagestatusid")]
        public int UsageStatusId { get; set; }
        [JsonPropertyName("categoryid")]
        public int CategoryId { get; set; }

    }
}
