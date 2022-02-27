using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Dtos.ProductDto
{
    public class ProductDto : BaseEntityDto
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
        public Brand Brand { get; set; }
    }
}
