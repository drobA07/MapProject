using Autofac;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using MapProject.Controllers.Base;
using MapProject.Services.ServiceLocator;
using Microsoft.Practices.ServiceLocation;

namespace MapProject.App_Start
{
	public class BootConfig
	{
		private static readonly object Gate = new object();
		private static bool _initialized;

		public static void Register()
		{
			lock (Gate)
			{
				if (_initialized)
				{
					return;
				}
				//инициализация доп. компонентов и сервисов
				var builder = new ContainerBuilder();
				//new SettingsModule(builder).Init();
				new MapConfig(builder).Init();

				builder.RegisterControllers(typeof(BaseController).Assembly).PropertiesAutowired().InstancePerHttpRequest();
				builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

				var container = builder.Build();
				DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
				ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));

				var resolver = new AutofacWebApiDependencyResolver(container);
				GlobalConfiguration.Configuration.DependencyResolver = resolver;

				_initialized = true;
			}
		}
	}
}