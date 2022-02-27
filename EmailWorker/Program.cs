using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Mail;
using Service.RabbitMq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public IConfiguration Configuration { get; }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration configuration = hostContext.Configuration;

                    
                    services.AddTransient<IMailSender, MailSender>(i =>
               new MailSender(
                   configuration["EmailSender:Host"],
                   configuration.GetValue<int>("EmailSender:Port"),
                   configuration.GetValue<bool>("EmailSender:EnableSSL"),
                   configuration["EmailSender:UserName"],
                   configuration["EmailSender:Password"]
               ));
                  
                    services.AddHostedService<Worker>();
                    services.AddSingleton<Consumer>();
                   // services.AddHostedService<IMailSender, MailSender>();
                
                });
    }
}
