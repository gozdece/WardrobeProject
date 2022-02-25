using AutoMapper;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository;
using Repository.Repositories;
using Repository.UnitOfWorks;
using Service.Mail;
using Service.Mapping;
using Service.Services;
using Service.Services.JwtToken;
using Service.Validations;
using Service.Validations.CustomValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private readonly string key = "Bu benim uzun string key degerim";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<PostProductDtoValidator>());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
            });

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidAudience = Configuration["Jwt:Auidence"],
                    ValidateIssuer =true,
                    ValidIssuer=Configuration["Jwt:Issuer"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ClockSkew = TimeSpan.Zero
                   
                };
            });
            //services.AddSingleton<IJwtAuthentication>(new JwtAuthentication(key));
            services.AddScoped<TokenGenerator>();

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlConnection"), x => { x.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name); }));
            
            
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
            .AddEntityFrameworkStores<AppDbContext>();
        
            services.AddTransient<IMailService, MailService>(i =>
                new MailService(
                    Configuration["EmailSender:Host"],
                    Configuration.GetValue<int>("EmailSender:Port"),
                    Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                    Configuration["EmailSender:UserName"],
                    Configuration["EmailSender:Password"]
                ));

            services.AddAutoMapper(typeof(MapProfile));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
