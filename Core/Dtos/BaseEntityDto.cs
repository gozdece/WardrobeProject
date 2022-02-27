using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public abstract class BaseEntityDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
    }
}
