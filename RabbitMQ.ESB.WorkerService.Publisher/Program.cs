using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.ESB.WorkerService.Publisher.Services;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMassTransit(conf =>
        {
            conf.UsingRabbitMq((context, _conf) =>
            {
                _conf.Host("localhost");
            });
        });

        services.AddHostedService<PublishMessageService>(provider =>
        {
            using IServiceScope scope =  provider.CreateScope();

            IPublishEndpoint publishEndpoint =  scope.ServiceProvider.GetService<IPublishEndpoint>();
             
            return new(publishEndpoint);
        });
    })
    .Build();

host.Run();
