using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using REP_CRIME01.Crime.Domain.Contracts;
using REP_CRIME01.Crime.Infrastructure.Settings;
using REP_CRIME01.Crime.Infrastructure.Repositories;

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

            return services;
        }
    }
}
