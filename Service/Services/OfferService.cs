using AutoMapper;
using Core.Dtos.OfferDto;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class OfferService : Service<Offer>, IOfferService
    {
        private readonly IOfferRepository _offerRepository;
        public OfferService(IGenericRepository<Offer> repository, IUnitOfWork unitOfWork, IMapper mapper,IOfferRepository offerRepository) : base(repository, unitOfWork, mapper)
        {
            _offerRepository = offerRepository;
        }

        public decimal CalcOfferPrice(PostOfferDto postOfferDto, decimal productPrice)
        {
            return _offerRepository.CalcOfferPrice(postOfferDto, productPrice);
        }

        public bool DeleteOffer(int userId, int productId)
        {
            throw new NotImplementedException();
        }

        public Offer GetOfferByUserId(int userId, int productId)
        {
            return _offerRepository.GetOfferByUserId(userId, productId);
        }
       public List<List<Offer>> GetOffersByProducts(List<Product> products)
        {
            return _offerRepository.GetOffersByProducts(products);
        }

    }

}
