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
    //declare the queue
    channel.QueueDeclare("BasicTest", false, false, false, null);
    //create a message
    string message = "Getting started with .net core RabbitMQ";
    var body = Encoding.UTF8.GetBytes(message);
    //publish the message
    channel.BasicPublish("", "BasicTest", null, body);
    Console.WriteLine("Sent message {0}...", message);
}
Console.WriteLine("Press [enter] to exit the sender app...");
Console.ReadLine();