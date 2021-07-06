using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using REP_CRIME01.Crime.Domain.Common;
using REP_CRIME01.Crime.Domain.Contracts;
using REP_CRIME01.Crime.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace REP_CRIME01.Crime.Infrastructure.Repositories
{
    public class MongoRepository<TDocument> : IRepository<TDocument> where TDocument: AuditableEntity
    {
        private readonly IMongoCollection<TDocument> _collection;

        public MongoRepository(IMongoDbSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<TDocument>(typeof(TDocument).Name);
            ClassMapping();
        }

        protected virtual void ClassMapping()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(TDocument)))
            {
                BsonClassMap.RegisterClassMap<TDocument>(cm =>
                {
                    cm.SetIdMember(cm.GetMemberMap(x => x.Id));
                });
            }
        }

        public virtual async Task<TDocument> AddAsync(TDocument entity)
        {
            entity.CreatedDate = DateTime.Now;
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public virtual async Task DeleteByIdAsync(Guid id)
        {
            await _collection.FindOneAndDeleteAsync(x => x.Id == id);
        }

        public virtual async Task<TDocument> FindByIdAsync(Guid id)
        {
            return await _collection.Find(x => x.Id == id).SingleOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<TDocument>> FindAllAsync(
            Expression<Func<TDocument, bool>> filterExpression, 
            Expression<Func<TDocument, object>> sortBy, 
            bool sortAsync, int page, int pageSize)
        {
            var sortExpresion = sortAsync ? Builders<TDocument>.Sort.Ascending(sortBy) : Builders<TDocument>.Sort.Descending(sortBy);
            return await _collection
                .Find(filterExpression)
                .Sort(sortExpresion)
                .Skip((page - 1) * pageSize)
                .Limit(pageSize)
                .ToListAsync();
        }

        public virtual async Task UpdateAsync(TDocument entity)
        {
            entity.LastModifiedDate = DateTime.Now;
            await _collection.FindOneAndReplaceAsync(x => x.Id == entity.Id, entity);
        }
    }
}
