using System;
using Core.Repositories;
using Core.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories;
using Repository.UnitOfWorks;

namespace Repository
{
    public static class RepositoryCollection
    {
        public static IServiceCollection AddRepositoryLayerServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            services.AddScoped(typeof(IOfferRepository), typeof(OfferRepository));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            return services;
        }
    }
}
