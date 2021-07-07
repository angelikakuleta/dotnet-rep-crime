using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using REP_CRIME01.Police.Domain.Contracts;
using REP_CRIME01.Police.Infrastructure.Context;
using REP_CRIME01.Police.Infrastructure.Repositories;
using System.Reflection;

namespace REP_CRIME01.Police.Infrastructure
{
    public static partial class ServiceExtension
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PoliceContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PoliceContext"), x => x.MigrationsAssembly(Assembly.GetExecutingAssembly().ToString())));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
