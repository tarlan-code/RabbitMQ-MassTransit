using MassTransit;
using MassTransit.Testing;
using RabbitMQ.ESB.Consumer.Consumers;

string rabbitMQUri = "localhost";

string queueName = "example-queue";

IBusControl bus = Bus.Factory.CreateUsingRabbitMq(factory =>
{
    factory.Host(rabbitMQUri);

    factory.ReceiveEndpoint(queueName,endpoint =>
    {
        endpoint.Consumer<ExampleMessageConsumer>();    
    });
});

await bus.StartAsync();

Console.Read();