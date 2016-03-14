using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Papyrus.Domain.Entities.Settings;

namespace Papyrus.Domain.Repository
{
    public abstract class BaseRepository<T> where T : class
    {
        protected readonly IMongoDatabase Database;

        protected BaseRepository(ExecutionTimeSettings settings, MongoDbFactory mongoDbFactory)
        {
            if (settings != null)
            {
                Database = mongoDbFactory.GetDatabase(settings.ConnectionString, settings.DatabaseName);
            }
        }
        protected abstract string CollectionName { get; set; }

        public virtual Task Insert(T data)
        {
            if (data == null)
                return null;
            IMongoCollection<T> collection = Database.GetCollection<T>(CollectionName);            
            return collection.InsertOneAsync(data);            
        }

        public virtual IQueryable<T> GetAll()
        {
            IMongoCollection<T> collection = Database.GetCollection<T>(CollectionName);            
            return collection.AsQueryable();
        }

        public virtual IQueryable<T> GetMany(Expression<Func<T, bool>> where)
        {
            IMongoCollection<T> collection = Database.GetCollection<T>(CollectionName);
            IQueryable<T> dataList = collection.AsQueryable().Where(where);

            return dataList;
        }

        public virtual T Get(Expression<Func<T, bool>> where)
        {
            IMongoCollection<T> collection = Database.GetCollection<T>(CollectionName);
            T data = collection.AsQueryable().FirstOrDefault(where);

            return data;
        }
    }
}
