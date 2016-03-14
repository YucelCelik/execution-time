using System.Linq;
using Papyrus.Domain.Entities.ExecutionInformation;
using Papyrus.Domain.Manager.Interfaces;
using Papyrus.Domain.Repository.Interfaces;

namespace Papyrus.Domain.Manager
{
    public class ExecutionInformationManager : IExecutionInformationManager
    {
        private readonly IExecutionInformationRepository _executionInformationRepository;

        public ExecutionInformationManager(IExecutionInformationRepository executionInformationRepository)
        {
            _executionInformationRepository = executionInformationRepository;
        }

        public void InsertExecutionInformation(ExecutionInformation executionInformation)
        {
            _executionInformationRepository.Insert(executionInformation);
        }

        public IQueryable<string> GetApplicationNames()
        {
            return _executionInformationRepository.GetAll().Select(v => v.ApplicationName).Distinct();
        }

        public ExecutionInformation GetLastExecutionInformation(string applicationName)
        {
            var executionInformations = _executionInformationRepository.GetMany(e => e.ApplicationName == applicationName);
            return executionInformations.OrderByDescending(e => e.StartDate).FirstOrDefault();
        }

        public string GetApplicationIp(string applicationName)
        {
            var executionInformation = _executionInformationRepository.GetApplicationIp(applicationName);

            return executionInformation != null ? executionInformation.IpAddress : null;
        }
    }
}
