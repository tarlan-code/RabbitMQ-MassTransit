﻿using MassTransit;
using RabbitMQ.ESB.Shared.Messages;

namespace RabbitMQ.ESB.WorkerService.Consumer.Consumers;

public class ExampleMessageConsumer : IConsumer<IMessage>
{
    public Task Consume(ConsumeContext<IMessage> context)
    {
        Console.WriteLine(context.Message.Text);

        return Task.CompletedTask;
    }
}
