using System.Web.Mvc;
using System.Web.Routing;

namespace MapProject.App_Start
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"About",
				"About",
				new { controller = "Home", action = "About" });

			routes.MapRoute(
				"Products",
				"Products",
				new { controller = "Home", action = "Products" });

			routes.MapRoute(
				"Downloads",
				"Downloads",
				new { controller = "Home", action = "Downloads" });

			routes.MapRoute(
				"Help",
				"Help",
				new { controller = "Home", action = "Help" });

			routes.MapRoute(
				"Contacts",
				"Contacts",
				new { controller = "Home", action = "Contacts" });

			routes.MapRoute(
				"Registration",
				"Registration",
				new { controller = "Account", action = "Registration" });

			routes.MapRoute(
				"Default",
				"{controller}/{action}/{id}",
				new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}