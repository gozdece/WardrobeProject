using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Dtos.OfferDto
{
    public class PostOfferDto : BaseEntityDto
    {
        public decimal OfferedPrice { get; set; }
        public decimal OfferedPricePercentage { get; set; }
        public int ProductId { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }

    }
}
