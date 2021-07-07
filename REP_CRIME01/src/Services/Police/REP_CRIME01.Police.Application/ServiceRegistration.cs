using Microsoft.Extensions.Configuration;
using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using REP_CRIME01.CQRSResponse.Behaviours;

namespace REP_CRIME01.Police.Application
{
    public static partial class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}
