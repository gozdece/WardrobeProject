using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Models
{
    public abstract class BaseEntity
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonIgnore]
        public DateTime CreatedDate { get; set; }
        
        [JsonIgnore]
        public DateTime? UpdatedDate { get; set; }
    }
}
