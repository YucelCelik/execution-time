using System;

namespace Papyrus.Dto.Model
{
    public class ExecutionInformationDto
    {        
        public string ApplicationName { get; set; }
        public string Mode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public StatusTypeEnumDto Status { get; set; }
        public long ItemCount { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public MessageTypeEnumDto Type { get; set; }
        public string IpAddress { get; set; }
    }
}
