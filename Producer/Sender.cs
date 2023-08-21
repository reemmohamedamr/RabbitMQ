// See https://aka.ms/new-console-template for more information
//open a connection to local rabbit mq host
//through connection factory

using RabbitMQ.Client;
using System.Text;
//create the factory
var factory = new ConnectionFactory()
{
    HostName = "localhost",

};
//open a connection
using (var connection = factory.CreateConnection())
    //open a channel
using (var channel = connection.CreateModel())
{
    channel.ExchangeDeclare(exchange: "log",
        type: "direct",
        autoDelete: false,
        durable: false);
    //declare the queue
    channel.QueueDeclare(queue: "BasicTest",
        durable: false,
        exclusive: false,
        autoDelete: false,
        arguments: null);
    channel.QueueBind(queue: "BasicTest",
                  exchange: "log",
                  routingKey: "BasicTest");
    //create a message
    string message = "Getting started with .net core RabbitMQ";
    var body = Encoding.UTF8.GetBytes(message);
    //publish the message
    channel.BasicPublish(exchange: "log",
        routingKey: "BasicTest",
        basicProperties: null,
        body: body);
    Console.WriteLine("Sent message {0}...", message);
}
Console.WriteLine("Press [enter] to exit the sender app...");
Console.ReadLine();