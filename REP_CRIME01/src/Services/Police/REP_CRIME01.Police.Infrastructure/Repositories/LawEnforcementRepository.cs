using REP_CRIME01.Police.Domain.Entities;
using REP_CRIME01.Police.Infrastructure.Context;

namespace REP_CRIME01.Police.Infrastructure.Repositories
{
    class LawEnforcementRepository : Repository<LawEnforcement>
    {
        public LawEnforcementRepository(PoliceContext context) : base(context)
        {
        }
    }
}
