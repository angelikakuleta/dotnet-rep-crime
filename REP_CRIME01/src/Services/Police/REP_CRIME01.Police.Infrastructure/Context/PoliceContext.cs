using Microsoft.EntityFrameworkCore;
using REP_CRIME01.Police.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace REP_CRIME01.Police.Infrastructure.Context
{
    public class PoliceContext : DbContext
    {
        public PoliceContext([NotNull] DbContextOptions<PoliceContext> options) : base(options)
        {
        }

        public DbSet<LawEnforcement> LawEnforcements { get; set; }
        public DbSet<Case> Cases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LawEnforcement>().ToTable("LawEnforcement");
            modelBuilder.Entity<LawEnforcement>().HasIndex(x => x.Code).IsUnique();
            modelBuilder.Entity<LawEnforcement>().Property(x => x.Rank).HasConversion<string>();
            modelBuilder.Entity<Case>().ToTable("Case");

            modelBuilder.Entity<Case>()
                .HasOne(x => x.LawEnforcement);
        }
    }
}
