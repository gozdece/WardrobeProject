using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.ProductDto
{
    public class PostProductDto : BaseEntityDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsOfferable { get; set; }
        public bool IsSold { get; set; }
        public decimal Price { get; set; }
        public string Photo { get; set; }
        public int BrandId { get; set; }
        public int UserId { get; set; }
        public int ColorId { get; set; }
        public int UsageStatusId { get; set; }
        public int CategoryId { get; set; }

    }
}
