using Core.Dtos.OfferDto;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    { 
        public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public bool IsOfferableProduct(int productId)
        {
            var product= _dbSet.Where(x => x.Id == productId).FirstOrDefault();
            var result = (product.IsOfferable == true ? true : false);
            return result;
        }

        public decimal GetPriceForProduct(int productId)
        {
            var product = _dbSet.Where(x =>x.Id == productId).FirstOrDefault();
            return product.Price;
        }
        public async Task<List<Product>> GetProductsWithOffers(int userId)
        {
            var result = await _appDbContext.Products.Where(x => x.UserId == userId).Include(x => x.Offers).ToListAsync();
            //var result= _appDbContext.Products.Include(x => x.Offers).Where(x => x.UserId == userId).ToListAsync();
            return result;
        }

        public Task<List<Product>> ProductsWithDetail()
        {
            var result = _appDbContext.Products.Include(product => product.Brand).ToListAsync();
            return result;
        }

        public bool CheckOfferForUser(User user, PostOfferDto postOfferDto)
        {
            var result = _appDbContext.Offers.Where(x => x.UserId == user.Id).Where(x => x.ProductId == postOfferDto.ProductId);
            if(result is not null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
