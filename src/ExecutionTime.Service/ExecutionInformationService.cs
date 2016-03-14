using System.Collections.Generic;
using AutoMapper;
using Papyrus.Domain.Entities.ExecutionInformation;
using Papyrus.Domain.Manager.Interfaces;
using Papyrus.Dto.Model;
using Papyrus.Service.Config;
using Papyrus.Service.Interfaces;

namespace Papyrus.Service
{
    public class ExecutionInformationService : IExecutionInformationService
    {
        private readonly IExecutionInformationManager _executionInformationManager;
        private readonly MapManager _mapManager;

        public ExecutionInformationService(IExecutionInformationManager executionInformationManager, MapManager mapManager)
        {
            _executionInformationManager = executionInformationManager;
            _mapManager = mapManager;
        }

        public void InsertExecutionInformation(ExecutionInformationDto executionInformationDto)
        {
            _executionInformationManager.InsertExecutionInformation(Mapper.Map<ExecutionInformation>(executionInformationDto));
        }

        public IEnumerable<string> GetApplicationNames()
        {
            return _executionInformationManager.GetApplicationNames();
        }

        public ExecutionInformationDto GetLastExecutionInformation(string applicationName)
        {
            return
                Mapper.Map<ExecutionInformationDto>(
                    _executionInformationManager.GetLastExecutionInformation(applicationName));
        }

        public string GetApplicationIp(string applicationName)
        {
            return _executionInformationManager.GetApplicationIp(applicationName);
        }
    }
}
