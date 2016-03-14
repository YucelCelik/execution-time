using System.Linq;
using Papyrus.Domain.Entities.ExecutionInformation;

namespace Papyrus.Domain.Manager.Interfaces
{
    public interface IExecutionInformationManager
    {
        void InsertExecutionInformation(ExecutionInformation executionInformation);
        IQueryable<string> GetApplicationNames();
        ExecutionInformation GetLastExecutionInformation(string applicationName);
        string GetApplicationIp(string applicationName);
    }
}
