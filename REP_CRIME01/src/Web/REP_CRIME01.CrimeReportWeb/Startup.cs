using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using REP_CRIME01.Crime.Common.Models;
using REP_CRIME01.CrimeReportWeb.Models;
using REP_CRIME01.CrimeReportWeb.Settings;
using System;

namespace REP_CRIME01.CrimeReportWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CreateCrimeEventVM, CreateCrimeEventDto>();
            });
            services.AddScoped<IMapper>(x => config.CreateMapper());

            var httpClientsDns = new HttpClientsDns();
            Configuration.GetSection(nameof(HttpClientsDns)).Bind(httpClientsDns);

            services.AddHttpClient<ICrimeClient, CrimeClient>(c => c.BaseAddress = new Uri(httpClientsDns.CrimeClient));

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Crime}/{action=Index}/{id?}");
            });
        }
    }
}
