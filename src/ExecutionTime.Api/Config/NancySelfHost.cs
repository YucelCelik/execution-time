using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Nancy.Hosting.Self;
using Nancy.Json;

namespace Papyrus.Api.Config
{
    public abstract class NancySelfHost
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (NancySelfHost));

        private NancyHost _selfHost;
        protected abstract IList<Uri> ServiceUriList { get; }

        public void Start()
        {
            JsonSettings.MaxJsonLength = int.MaxValue;
            JsonSettings.MaxRecursions = int.MaxValue;

            var configurationToListenOnAllPorts = new HostConfiguration
            {
                UrlReservations = {CreateAutomatically = true},
                AllowChunkedEncoding = false
            };

            Uri[] baseUris = ServiceUriList.ToArray();
            _selfHost = new NancyHost(configurationToListenOnAllPorts, baseUris);
            _selfHost.Start();
            foreach (Uri eachUri in baseUris)
            {
                Log.Debug(String.Format("Service started at host: {0} port: {1}", eachUri.Host, eachUri.Port));
            }
        }

        public void Stop()
        {
            Log.Debug(String.Format("Service stopped!"));
            _selfHost.Stop();
        }
    }
}