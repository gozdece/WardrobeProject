using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Product> Products { get; set; } //kullannıcın girdiği ürünler
        public ICollection<Offer> Offers { get; set; } //verdiğim teklifler
        public ICollection<Order> Orders { get; set; } //siparişlerim

        public static implicit operator int(User v)
        {
            throw new NotImplementedException();
        }
    }
}
