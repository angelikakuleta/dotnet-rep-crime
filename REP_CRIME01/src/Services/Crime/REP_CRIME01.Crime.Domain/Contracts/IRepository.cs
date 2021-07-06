﻿using REP_CRIME01.Crime.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace REP_CRIME01.Crime.Domain.Contracts
{
    public interface IRepository<TEntity> where TEntity: AuditableEntity
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteByIdAsync(Guid id);
        Task<TEntity> FindByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> FindAllAsync(
            Expression<Func<TEntity, bool>> filterExpression, 
            Expression<Func<TEntity, object>> sortBy, 
            bool sortAsync, int page, int pageSize);
    }
}
