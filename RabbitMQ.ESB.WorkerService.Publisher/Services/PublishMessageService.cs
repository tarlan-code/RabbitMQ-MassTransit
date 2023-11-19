using MassTransit;
using Microsoft.Extensions.Hosting;
using RabbitMQ.ESB.Shared.Messages;

namespace RabbitMQ.ESB.WorkerService.Publisher.Services;

public class PublishMessageService : BackgroundService
{
    readonly IPublishEndpoint _publishEndpoint;

    public PublishMessageService(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        for (int i = 0; i < 100; i++)
        {
            ExampleMessage msg = new()
            {
                Text = $"{i}. Mesaj"
            };

            await _publishEndpoint.Publish(msg);
        }
    }
}
