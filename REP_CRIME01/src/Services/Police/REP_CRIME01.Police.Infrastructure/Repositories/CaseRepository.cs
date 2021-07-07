using Microsoft.EntityFrameworkCore;
using REP_CRIME01.Police.Domain.Entities;
using REP_CRIME01.Police.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace REP_CRIME01.Police.Infrastructure.Repositories
{
    public class CaseRepository : Repository<Case>
    {
        public CaseRepository(PoliceContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Case>> FindAllAsync(Expression<Func<Case, bool>> filterExpression, Expression<Func<Case, object>> sortBy, bool sortAsc, int page, int pageSize)
        {
            return await GetQuery(filterExpression, sortBy, sortAsc, page, pageSize, x => x.LawEnforcement)
                .ToListAsync();
        }

        public override async Task<Case> FindAsync(Expression<Func<Case, bool>> filterExpression)
        {
            return await dbSet
                .Where(filterExpression)
                .Include(x => x.LawEnforcement)
                .FirstOrDefaultAsync();
        }

        public override async Task<Case> FindByIdAsync(Guid id)
        {
            return await dbSet
                .Where(x => x.Id == id)
                .Include(x => x.LawEnforcement)
                .FirstOrDefaultAsync();
        }
    }
}
