using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Dtos.ProductDto
{
    public class ProductDto : BaseEntityDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsOfferable { get; set; }
        public bool IsSold { get; set; }
        public decimal Price { get; set; }
        public string Photo { get; set; }
        public Brand Brand { get; set; }
    }
}
