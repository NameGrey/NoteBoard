using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace AzureNoteService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
		public readonly ILog logger = LogManager.GetLogger("GlobalLogger");

		protected void Application_Start()
        {
			XmlConfigurator.Configure();
			logger.Info("Application start - before configuring");
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
