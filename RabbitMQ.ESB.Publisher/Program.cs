using MassTransit;
using RabbitMQ.ESB.Shared.Messages;

string rabbitMQUri = "localhost";

string queueName = "example-queue";

IBusControl bus = Bus.Factory.CreateUsingRabbitMq(factory =>
{
    factory.Host(rabbitMQUri);
});

ISendEndpoint sendEndpoint = await bus.GetSendEndpoint(new($"queue:{queueName}")); 

Console.Write("Mesaj: ");

string msg = Console.ReadLine();

await sendEndpoint.Send<IMessage>(new ExampleMessage()
{
    Text = msg
});

Console.Read();