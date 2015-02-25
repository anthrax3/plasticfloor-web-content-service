using System;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Plasticfloor.Services.WebContent
{
    public class Global : System.Web.HttpApplication
    {

        private static IWindsorContainer _container;
        protected void Application_Start(object sender, EventArgs e)
        {
            _container = new WindsorContainer();
            _container.Install(FromAssembly.This());
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}