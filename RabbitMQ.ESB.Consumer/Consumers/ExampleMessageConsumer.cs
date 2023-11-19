using MassTransit;
using RabbitMQ.ESB.Shared.Messages;

namespace RabbitMQ.ESB.Consumer.Consumers;

public class ExampleMessageConsumer : IConsumer<IMessage>
{
    public async Task Consume(ConsumeContext<IMessage> context)
    {
        Console.WriteLine($"Gelen mesaj: {context.Message.Text}");
    }
}
