using System;
using System.Collections.Generic;
using System.Configuration.Abstractions;

namespace Papyrus.Api.Config
{
    public class ExecutionTimeSelfHost : NancySelfHost
    {
        protected override IList<Uri> ServiceUriList
        {
            get
            {
                var executionTimeSettings = ConfigurationManager.Instance.AppSettings.Map<ExecutionTimeSettings>();
                return executionTimeSettings.GetBaseUrlAsList();
            }
        }
    }
}
