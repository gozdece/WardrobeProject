using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace Service.RabbitMq
{
    public class Producer
    {
        
        public void SendEmail(EmailModel emailModel)
        {

            ConnectionFactory factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            IConnection connection = factory.CreateConnection();

            IModel channel = connection.CreateModel();

            channel.QueueDeclare(
                queue:"Wardrobe",
                durable:false,
                exclusive:false,
                autoDelete:false,null);

            var body = Encoding.UTF8.GetBytes(System.Text.Json.JsonSerializer.Serialize(emailModel));
            channel.BasicPublish(exchange: "", routingKey: "Wardrobe", body: body);

        }
        

        

    }

    public class EmailModel
    {
        public string Email { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
    }
}
