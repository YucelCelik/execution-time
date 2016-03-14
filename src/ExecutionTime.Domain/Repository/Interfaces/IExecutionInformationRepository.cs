using Papyrus.Domain.Entities.ExecutionInformation;

namespace Papyrus.Domain.Repository.Interfaces
{
    public interface IExecutionInformationRepository : IRepository<ExecutionInformation>
    {
        ExecutionInformation GetApplicationIp(string applicationName);
    }
}
