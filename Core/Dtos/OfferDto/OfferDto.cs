using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.OfferDto
{
    public class OfferDto :BaseEntityDto
    {
        public decimal OfferedPrice { get; set; }
        public decimal? OfferedPricePercentage { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public bool AcceptOffer { get; set; }
        public bool SoldStatus { get; set; }
    }
}
