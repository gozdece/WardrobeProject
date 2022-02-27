using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Product : BaseEntity
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
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
        public int UsageStatusId { get; set; }
        public UsageStatus UsageStatus { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        //public ICollection<Order> Orders { get; set; } 
        public Order Order { get; set; }
        public ICollection<Offer> Offers { get; set; }

    }
}
