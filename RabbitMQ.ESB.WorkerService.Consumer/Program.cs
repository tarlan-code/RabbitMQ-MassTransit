using MassTransit;
using Microsoft.Extensions.Hosting;
using RabbitMQ.ESB.WorkerService.Consumer.Consumers;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMassTransit(conf =>
        {
            conf.AddConsumer<ExampleMessageConsumer>(); 

            conf.UsingRabbitMq((context, _conf) =>
            {
                _conf.Host("localhost");

                _conf.ReceiveEndpoint("example-message-queue",e=> e.ConfigureConsumer<ExampleMessageConsumer>(context));
            });
        });
    })
    .Build();   

await host.RunAsync();  
