// See https://aka.ms/new-console-template for more information

//create a factory
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory() { HostName = "localhost" };
using(var connection = factory.CreateConnection())
using(var channel=connection.CreateModel())
{
    channel.QueueDeclare(queue: "BasicTest",
        durable: false,
        exclusive:false,
        autoDelete: false,
        arguments: null);

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, basicDeliveryEventArgs) =>
    {
        var body = basicDeliveryEventArgs.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine("Received message {0}...", message);
    };
    channel.BasicConsume(queue: "BasicTest",
        autoAck: true,
        consumer: consumer,
        consumerTag: "INFO");
    Console.WriteLine("Press [enter] to exit consumer...");
    Console.ReadLine();
}
