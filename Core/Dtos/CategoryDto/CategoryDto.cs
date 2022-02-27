using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Dtos.CategoryDto
{
    public class CategoryDto:BaseEntityDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("products")]
        public ICollection<Product> Products { get; set; }
    }
}
