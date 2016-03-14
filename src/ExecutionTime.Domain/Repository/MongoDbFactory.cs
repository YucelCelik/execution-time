using MongoDB.Driver;

namespace Papyrus.Domain.Repository
{
    public class MongoDbFactory
    {
        public virtual IMongoDatabase GetDatabase(string connectionString, string databaseName)
        {
            string con = connectionString;
            var client = new MongoClient(con);
            return client.GetDatabase(databaseName);
        }
    }
}
