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
        
        public Producer(string email)
        {
          

            ConnectionFactory factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            IConnection connection = factory.CreateConnection();

            IModel channel = connection.CreateModel();

            channel.QueueDeclare(
                queue:"WardrobeProducer",
                durable:false,
                exclusive:false,
                autoDelete:false,null);

            string message = email;
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "", routingKey: "WardrobeProducer", body: body);

        }
        

        

    }
}
