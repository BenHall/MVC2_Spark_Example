using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace n2CMS_Spark_Template
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default",                                              // Route name
				"{controller}/{action}/{id}",                           // URL with parameters
				new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
			);

		}

		private static readonly Application _application = new Application();

		protected void Application_Start()
		{
			_application.RegisterViewEngines(ViewEngines.Engines);
			_application.RegisterRoutes(RouteTable.Routes);

			AreaRegistration.RegisterAllAreas();

			RegisterRoutes(RouteTable.Routes);
		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{
			// this ensures Default.aspx will be processed
			var context = ((HttpApplication)sender).Context;
			var relativeFilePath = context.Request.AppRelativeCurrentExecutionFilePath;
			if (relativeFilePath == "~/" ||
				string.Equals(relativeFilePath, "~/default.aspx", StringComparison.InvariantCultureIgnoreCase))
			{
				context.RewritePath("~/Home");
			}
		}
	}
}