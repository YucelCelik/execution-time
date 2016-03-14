using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Papyrus.Domain.Entities.ExecutionInformation
{
    [BsonIgnoreExtraElements]
    public class ExecutionInformation
    {
        public string ApplicationName { get; set; }
        public string Mode { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime StartDate { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime EndDate { get; set; }
        public StatusTypeEnum Status { get; set; }
        public string Message { get; set; }
        public MessageTypeEnum Type { get; set; }
        public string IpAddress { get; set; }
    }
}
