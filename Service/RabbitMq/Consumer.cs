﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Service.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RabbitMq
{
    public class Consumer
    {
        private IMailSender _mailService;


        public Consumer(IMailSender mailService)
        {
            _mailService = mailService;
           
            
        }

        public void BasicConsume(string mail, string subject, string message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            var connection = factory.CreateConnection();

            IModel channel = connection.CreateModel();

            channel.QueueDeclare(
                    queue: "WardrobeConsumer",
                    durable: false,
                    exclusive: false,
                    autoDelete: false
                );

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, args) =>
            {
                var message = Encoding.UTF8.GetString(args.Body);
                _mailService.SendEmailAsync(mail, subject, message);
            };

            channel.BasicConsume("WardrobeConsumer", autoAck: true, consumer: consumer);
        }
    }
}
