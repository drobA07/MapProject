using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MapProject.App_Start;
using MapProject.Services.SecurityService;
using NHibernate;

namespace MapProject
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : HttpApplication
	{
		protected void Application_Start()
		{
			BootConfig.Register();
			AreaRegistration.RegisterAllAreas();

			WebApiConfig.Register(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			AuthConfig.RegisterAuth();
		}

		private void Session_Start(object sender, EventArgs e)
		{
			//логирывание учитывая куки
			var session = (ISession)DependencyResolver.Current.GetService(typeof(ISession));
			WebSecurity.GetInstance(session, Context).TryRecoverFromCookie();
		}
	}
}