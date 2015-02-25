using System;
using CassiniDev;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plasticfloor.Services.WebContent.Interface;

namespace Plasticfloor.Services.WebContent.IntegrationTests
{
    [TestClass]
    public class GlobalSetup
    {
        private static CassiniDevServer _server;

        public const int Port = 58371;
        public static readonly string BasePath = "http://localhost:" + Port + "/";

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            if(_server != null)
                _server.StopServer();
        }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            try
            {
                _server = new CassiniDevServer();
                _server.StartServer("../../../TechData.EC.Services.WebContent", Port, "/", "localhost");
            }
            // we're already running the service, ignore
            catch(Exception)
            {
                _server = null;
            }

            Container = new WindsorContainer();
            Container.AddFacility<WcfFacility>();

            Container.Register(
                Component.For<IPageService>()
                    .AsWcfClient(new DefaultClientModel(WcfEndpoint.FromConfiguration("PageService")))
            );
        }

        public static WindsorContainer Container { get; set; }

    }
}

