using System;
using System.Text;
using Core.Models;
using Core.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Service.Mail;
using Service.Mapping;
using Service.Services;
using Service.Services.JwtToken;
using Service.Validations;
using Service.Validations.CustomValidations;

namespace Service
{
    public static class ServiceCollection
    {
        
        public static IServiceCollection AddServiceLayerServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
            services.AddScoped(typeof(IProductService), typeof(ProductService));
            services.AddScoped(typeof(IOfferService), typeof(OfferService));
            //services.AddScoped<TokenGenerator>();
            services.AddAutoMapper(typeof(MapProfile));
            
            
            services.AddIdentity<User, Role>(_ =>
            {
                _.Password.RequiredLength = 8; //En az ka? karakterli olmas? gerekti?ini belirtiyoruz.
                _.Password.RequireNonAlphanumeric = false;//Alfanumerik zorunlulu?unu kald?r?yoruz.
                _.Password.RequireLowercase = false;//K???k harf zorunlulu?unu kald?r?yoruz.
                _.Password.RequireUppercase = false;//B?y?k harf zorunlulu?unu kald?r?yoruz.
                _.Password.RequireDigit = false;//0-9 aras? say?sal karakter zorunlulu?unu kald?r?yoruz.
                _.User.RequireUniqueEmail = true; //Email adreslerini tekille?tiriyoruz.
                _.User.AllowedUserNameCharacters = "abc?defghi?jklmno?pqrs?tu?vwxyzABC?DEFGHI?JKLMNO?PQRS?TU?VWXYZ0123456789-._@+"; //Kullan?c? ad?nda ge?erli olan karakterleri belirtiyoruz
            }).AddPasswordValidator<PasswordValidator>()
            .AddUserValidator<UserValidator>()
            .AddErrorDescriber<CustomIdentityErrorDescriber>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            services.AddTransient<IMailSender, MailSender>(i =>
                new MailSender(
                    configuration["EmailSender:Host"],
                    configuration.GetValue<int>("EmailSender:Port"),
                    configuration.GetValue<bool>("EmailSender:EnableSSL"),
                    configuration["EmailSender:UserName"],
                    configuration["EmailSender:Password"]
                ));
            services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<PostProductDtoValidator>());
            return services;
        }
    }
}
