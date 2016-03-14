using System;
using System.Collections.Generic;
using System.Linq;

namespace Papyrus.Api.Config
{
    public class ExecutionTimeSettings
    {
        public string ApplicationBaseUrl { get; set; }
        public string BuildConfiguration { get; set; }
        public IList<Uri> GetBaseUrlAsList()
        {
            return ApplicationBaseUrl.Split(',').Select(eachUrl => new Uri(eachUrl)).ToList();
        }
    }
}
