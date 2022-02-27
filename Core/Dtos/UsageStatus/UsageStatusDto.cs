using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Dtos.UsageStatus
{
    public class UsageStatusDto : BaseEntityDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
