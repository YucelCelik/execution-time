using System.Linq;
using MongoDB.Driver;
using Papyrus.Domain.Entities.ExecutionInformation;
using Papyrus.Domain.Entities.Settings;
using Papyrus.Domain.Repository.Interfaces;

namespace Papyrus.Domain.Repository
{
    public class ExecutionInformationRepository : BaseRepository<ExecutionInformation>, IExecutionInformationRepository
    {
        public ExecutionInformationRepository(ExecutionTimeSettings settings, MongoDbFactory mongoDbFactory)
            : base(settings, mongoDbFactory)
        {
            CollectionName = "ExecutionInformation";
        }

        protected override sealed string CollectionName { get; set; }

        public ExecutionInformation GetApplicationIp(string applicationName)
        {
            IMongoCollection<ExecutionInformation> collection = Database.GetCollection<ExecutionInformation>(CollectionName);
            FilterDefinition<ExecutionInformation> filter = new ExpressionFilterDefinition<ExecutionInformation>(e => e.ApplicationName == applicationName);

            var query =
                collection.Find(filter)
                    .Project<ExecutionInformation>(
                        Builders<ExecutionInformation>.Projection.Include(e => e.IpAddress));

            var results = query.ToList().FirstOrDefault();

            return results;
        }
    }
}
