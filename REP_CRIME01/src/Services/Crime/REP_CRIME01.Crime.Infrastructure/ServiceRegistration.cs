using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using REP_CRIME01.Crime.Domain.Contracts;
using REP_CRIME01.Crime.Infrastructure.Settings;
using REP_CRIME01.Crime.Infrastructure.Repositories;
using REP_CRIME01.Crime.Infrastructure.Clients;
using System;

namespace REP_CRIME01.Crime.Infrastructure
{
    public static partial class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureWithMongoDbServices(
            this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<MongoDbSettings>(options => configuration.GetSection(nameof(MongoDbSettings)).Bind(options));
            services.AddSingleton<IMongoDbSettings>(sp =>
                sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);

            services.AddScoped(typeof(IRepository<>), typeof(MongoRepository<>));

            var httpClientsDns = new HttpClientsDns();
            configuration.GetSection(nameof(HttpClientsDns)).Bind(httpClientsDns);

            services.AddHttpClient<IPoliceClient, PoliceClient>(c => c.BaseAddress = new Uri(httpClientsDns.PoliceClient));

            return services;
        }
    }
}
