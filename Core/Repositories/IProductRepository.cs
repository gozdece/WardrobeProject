using Core.Dtos.OfferDto;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IProductRepository
    {
        bool IsOfferableProduct(int productId);
        decimal GetPriceForProduct(int productId);
        Task<List<Product>> GetProductsWithOffers(int userId);
        Task<List<Product>> ProductsWithDetail();
        bool CheckOfferForUser(User user, PostOfferDto postOfferDto);
    }
}
