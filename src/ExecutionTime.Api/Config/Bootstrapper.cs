using System;
using System.Configuration.Abstractions;
using System.Diagnostics.Tracing;
using Autofac;
using Common.Logging;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Autofac;
using Newtonsoft.Json;

namespace Papyrus.Api.Config
{
    public class Bootstrapper : AutofacNancyBootstrapper
    {
        protected override void ApplicationStartup(ILifetimeScope container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            if (pipelines != null)
            {
                pipelines.OnError += (ctx, ex) =>
                {
                    var logger = container.Resolve<ILog>();
                    logger.Error(
                        JsonConvert.SerializeObject(
                            new
                            {
                                ExceptionType = ex.GetType().ToString(),
                                ExceptionMessage = ex.ToString(),
                                EventTime = DateTime.Now,
                                Severity = EventLevel.Error.ToString(),
                                Url = ctx.Request.Url.ToString()
                            }));
                    return null;
                };
            }
        }

        protected override void ConfigureApplicationContainer(ILifetimeScope container)
        {
            base.ConfigureApplicationContainer(container);

            var builder = new ContainerBuilder();
            Service.Config.Bootstrapper.Load(builder);

            builder.RegisterInstance(LogManager.GetLogger("Logger")).As<ILog>().SingleInstance();
            var executionTimeSettings = ConfigurationManager.Instance.AppSettings.Map<ExecutionTimeSettings>();
            builder.RegisterInstance(executionTimeSettings);

            builder.Update(container.ComponentRegistry);
        }
    }
}
