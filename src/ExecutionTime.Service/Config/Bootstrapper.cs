using System.Configuration.Abstractions;
using Autofac;
using Papyrus.Domain.Entities.Settings;
using Papyrus.Domain.Manager;
using Papyrus.Domain.Manager.Interfaces;
using Papyrus.Domain.Repository;
using Papyrus.Domain.Repository.Interfaces;
using Papyrus.Service.Interfaces;

namespace Papyrus.Service.Config
{
    public class Bootstrapper
    {
        public static ContainerBuilder Load(ContainerBuilder builder)
        {
            var settings = ConfigurationManager.Instance.AppSettings.Map<ExecutionTimeSettings>();

            builder.RegisterInstance(settings);
            builder.RegisterType<MongoDbFactory>().SingleInstance();
            builder.RegisterType<MapManager>().SingleInstance();

            builder.RegisterType<ExecutionInformationRepository>().As<IExecutionInformationRepository>().SingleInstance();
            builder.RegisterType<ExecutionInformationManager>().As<IExecutionInformationManager>().SingleInstance();
            builder.RegisterType<ExecutionInformationService>().As<IExecutionInformationService>().SingleInstance();

            return builder;            
        }
    }
}
