using AutoMapper;
using Papyrus.Domain.Entities.ExecutionInformation;
using Papyrus.Dto.Model;

namespace Papyrus.Service.Config
{
    public class MapManager
    {
        public MapManager()
        {
            Mapper.CreateMap<ExecutionInformation, ExecutionInformationDto>();
            Mapper.CreateMap<ExecutionInformationDto, ExecutionInformation>();
            Mapper.AssertConfigurationIsValid();
        }
    }
}
