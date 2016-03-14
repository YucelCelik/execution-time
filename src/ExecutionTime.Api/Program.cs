using System;
using Papyrus.Api.Config;
using Topshelf;

namespace Papyrus.Api
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HostFactory.Run(config =>
            {
                config.Service<ExecutionTimeSelfHost>(sc =>
                {
                    sc.ConstructUsing(() => new ExecutionTimeSelfHost());
                    sc.WhenStarted(s => s.Start());
                    sc.WhenStopped(s => s.Stop());
                });
                config.SetServiceName("ExecutionTime.Api.Service");
                config.SetDisplayName("ExecutionTime.Api");
                config.SetDescription("restful service to provide product information");
                config.StartAutomatically();
            });

            Console.ReadLine();
        }
    }
}
