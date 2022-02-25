using AutoMapper;
using Core.Dtos.OfferDto;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository) : base(repository, unitOfWork, mapper)
        {
            _productRepository = productRepository;
        }

        public bool IsOfferableProduct(int productId)
        {
          return  _productRepository.IsOfferableProduct(productId);
        }
        public decimal GetPriceForProduct(int productId)
        {
            return _productRepository.GetPriceForProduct(productId);
        }

       public Task<List<Product>> GetProductsWithOffers(int userId)
        {
            return _productRepository.GetProductsWithOffers(userId);
        }
        public Task<List<Product>> ProductsWithDetail()
        {
            return _productRepository.ProductsWithDetail();
        }
        public bool CheckOfferForUser(User user, PostOfferDto postOfferDto)
        {
            return _productRepository.CheckOfferForUser(user, postOfferDto);
        }
    }
}
