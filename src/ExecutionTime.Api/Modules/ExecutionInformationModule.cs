using Nancy;
using Nancy.ModelBinding;
using Papyrus.Dto.Model;
using Papyrus.Service.Interfaces;

namespace Papyrus.Api.Modules
{
    public class ExecutionInformationModule : NancyModule
    {
        public ExecutionInformationModule(IExecutionInformationService executionInformationServiceProxy)
        {
            Post["ExecutionInformations"] = _ =>
            {
                var log = this.Bind<ExecutionInformationDto>();
                executionInformationServiceProxy.InsertExecutionInformation(log);

                return HttpStatusCode.OK;
            };

            Get["/ApplicationNames"] = _ =>
            {
                var applicationNames = executionInformationServiceProxy.GetApplicationNames();
                return applicationNames == null ? HttpStatusCode.NotFound : Response.AsJson(applicationNames);
            };

            Get["/ExecutionInformations/GetLast"] = parameters =>
            {
                if (Request.Query["ApplicationName"].HasValue)
                {
                    string applicationName = Request.Query["ApplicationName"].Value;

                    var executionInformation =
                        executionInformationServiceProxy.GetLastExecutionInformation(applicationName);

                    return executionInformation == null
                        ? HttpStatusCode.NotFound
                        : Response.AsJson(executionInformation);
                }
                return HttpStatusCode.BadRequest;
            };

            Get["/ExecutionInformations/Ip"] = parameters =>
            {
                if (Request.Query["ApplicationName"].HasValue)
                {
                    string applicationName = Request.Query["ApplicationName"].Value;

                    var ip = executionInformationServiceProxy.GetApplicationIp(applicationName);

                    return ip == null
                        ? HttpStatusCode.NotFound
                        : Response.AsJson(ip);
                }
                return HttpStatusCode.BadRequest;
            };
        }
    }
}
