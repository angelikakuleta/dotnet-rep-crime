using Microsoft.EntityFrameworkCore;
using REP_CRIME01.Police.Domain.Common;
using REP_CRIME01.Police.Domain.Contracts;
using REP_CRIME01.Police.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace REP_CRIME01.Police.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : AuditableEntity, new()
    {
        protected readonly PoliceContext context;
        protected DbSet<TEntity> dbSet;

        public Repository(PoliceContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            dbSet = context.Set<TEntity>();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.CreatedDate = DateTime.Now;
            dbSet.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async virtual Task<long> CountAsync(Expression<Func<TEntity, bool>> filterExpression)
        {
            return await dbSet.Where(filterExpression).CountAsync();
        }

        public async virtual Task<bool> DeleteByIdAsync(Guid id)
        {
            try
            {
                dbSet.Remove(await FindByIdAsync(id));
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, object>> sortBy, bool sortAsc, int page, int pageSize)
        {
            return await GetQuery(filterExpression, sortBy, sortAsc, page, pageSize)
                .ToListAsync();
        }

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filterExpression)
        {
            return await dbSet.Where(filterExpression).FirstOrDefaultAsync();
        }

        public virtual async Task<TEntity> FindByIdAsync(Guid id)
        {
            return await dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            entity.LastModifiedDate = DateTime.Now;
            dbSet.Update(entity);
            await context.SaveChangesAsync();
        }

        protected IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, object>> sortBy, bool sortAsc, int page, int pageSize, params Expression<Func<TEntity, AuditableEntity>>[] includes)
        {
            IQueryable<TEntity> query = dbSet.Where(filterExpression);

            query = sortAsc ? query.OrderBy(sortBy) : query.OrderByDescending(sortBy);

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            query = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking();

            return query;
        }
    }
}
