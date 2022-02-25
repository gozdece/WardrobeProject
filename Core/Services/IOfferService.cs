using Core.Dtos.OfferDto;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IOfferService : IService<Offer>
    {
        bool DeleteOffer(int userId, int productId);
        decimal CalcOfferPrice(PostOfferDto postOfferDto,decimal productPrice);
        Offer GetOfferByUserId(int userId, int productId);
        List<List<Offer>> GetOffersByProducts(List<Product> products);
    }
}
