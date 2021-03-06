using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using REP_CRIME01.CrimeFeedback.EventHandlers;
using REP_CRIME01.CrimeFeedback.Services;
using REP_CRIME01.CrimeFeedback.Settings;
using REP_CRIME01.EventBus.Settings;

namespace REP_CRIME01.CrimeFeedback
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    
                    services.AddScoped<ISender, MailSender>();
                    services.Configure<SMTPSettings>(options => hostContext.Configuration.GetSection(nameof(SMTPSettings)).Bind(options));

                    services.AddMassTransit(config => {
                        config.AddConsumer<CrimeEventAssignedNotificationHandler>();

                        config.UsingRabbitMq((context, cfg) => {
                            cfg.Host(hostContext.Configuration["EventBusSettings:HostAddress"]);

                            cfg.ReceiveEndpoint(EventBusConstrants.CrimeEventAssignedNotificationQueue, c => {
                                c.ConfigureConsumer<CrimeEventAssignedNotificationHandler>(context);
                            });
                        });
                    });
                });
    }
}
