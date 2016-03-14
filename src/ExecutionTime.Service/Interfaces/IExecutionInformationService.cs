using System.Collections.Generic;
using Papyrus.Dto.Model;

namespace Papyrus.Service.Interfaces
{
    public interface IExecutionInformationService
    {
        void InsertExecutionInformation(ExecutionInformationDto executionInformationDto);
        IEnumerable<string> GetApplicationNames();
        ExecutionInformationDto GetLastExecutionInformation(string applicationName);
        string GetApplicationIp(string applicationName);
    }
}
