using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Spark;
using Spark.Web.Mvc;

namespace n2CMS_Spark_Template
{
	public class Application
	{
		public void RegisterRoutes(ICollection<RouteBase> routes)
		{
			if (routes == null) throw new ArgumentNullException("routes");

			// default route
			routes.Add(new Route(
			           	"{controller}/{action}/{id}",
			           	new RouteValueDictionary(new { action = "Index", id = "" }),
			           	new MvcRouteHandler()));
		}

		public void RegisterViewEngines(ICollection<IViewEngine> engines)
		{
			if (engines == null) throw new ArgumentNullException("engines");
			ISparkSettings  settings = new SparkSettings();
			SparkEngineStarter.RegisterViewEngine(engines);
		}
	}
}