using Core.Dtos.OfferDto;
using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class OfferRepository : GenericRepository<Offer>, IOfferRepository
    {
        public OfferRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public bool DeleteOffer(int userId, int productId)
        {
           var product= _dbSet.Where(x => x.ProductId == productId && x.UserId==userId).FirstOrDefault();
            return product!=null ? true:false;

        }
        public decimal CalcOfferPrice(PostOfferDto postOfferDto,decimal productPrice)
        {
            //eger teklif yuzdesi verildiyse = productPrice*percentage/100 
            //kendisi teklif verdiyse direk onu dön

            if(postOfferDto.OfferedPrice!=0)
            {
                return postOfferDto.OfferedPrice;
            }
            else
            {
                return productPrice * postOfferDto.OfferedPricePercentage / 100;
            }
        }
        public Offer GetOfferByUserId(int userId, int productId)
        {
            var offers = _dbSet.Where(x => x.ProductId == productId).ToList();

            foreach (var item in offers)
            {
                if(item.UserId == userId)
                    return item;
            }

            return null;
        }
        public List<List<Offer>> GetOffersByProducts(List<Product> products)
        {
            List<List<Offer>> offers = new List<List<Offer>>();
            foreach (var product in products)
            {
                if (product.Offers is not null)
                {
                   var result = _appDbContext.Offers.Include(x => x.Product).ToList();
                    offers.Add(result);
                }
                    
            }
            return offers;
        }
    }
}
