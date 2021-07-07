using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using REP_CRIME01.Police.Domain.Entities;
using System;
using System.Linq;

namespace REP_CRIME01.Police.Infrastructure.Context
{
    public class PrepDatabase
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var serviceProvider = serviceScope.ServiceProvider;
            SeedData(serviceProvider.GetService<PoliceContext>(), serviceProvider.GetService<ILogger<PrepDatabase>>());
        }

        private static void SeedData(PoliceContext context, ILogger<PrepDatabase> logger)
        {
            logger.LogInformation("Applying Migrations...");
            context.Database.Migrate();

            if (!context.LawEnforcements.Any())
            {               
                context.LawEnforcements.AddRange(GetPreconfiguredLawEnforcements());
                context.SaveChanges();
                logger.LogInformation("Populated database with data.");
            }
        }

        private static LawEnforcement[] GetPreconfiguredLawEnforcements()
        {
            return new LawEnforcement[]
            {
                new LawEnforcement()
                {
                    Id = Guid.Parse("d9c82106-fa66-4bf8-9c25-583fdb861ccc"),
                    Code = "XJDS23",
                    Rank = LawEnforcementRank.Officer,
                    PoliceDepartmentCode = "CRA027",
                    City = "Kraków",
                },
                new LawEnforcement()
                {
                    Id = Guid.Parse("4e2d557f-b800-4f99-9cc9-3a09c35a81b0"),
                    Code = "OBZ423",
                    Rank = LawEnforcementRank.Detective,
                    PoliceDepartmentCode = "WAW078",
                    City = "Warszawa",
                },
                new LawEnforcement()
                {
                    Id = Guid.Parse("0a30a2fb-de36-432e-af10-479a1ee660b7"),
                    Code = "WXA193",
                    Rank = LawEnforcementRank.Sergeant,
                    PoliceDepartmentCode = "WAW008",
                    City = "Warszawa",
                },
                new LawEnforcement()
                {
                    Id = Guid.Parse("8157a714-02f7-4da4-b6a1-5a2dbe5bc681"),
                    Code = "PRI312",
                    Rank = LawEnforcementRank.Officer,
                    PoliceDepartmentCode = "ZGA002",
                    City = "Zielona Góra",
                }
            };
        }
    }
}
