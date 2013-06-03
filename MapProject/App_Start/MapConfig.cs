using System.Configuration;
using Autofac;
using Autofac.Integration.Mvc;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using MapProject.DomainModel.Entities.Authority;
using MapProject.DomainModel.Enum;
using NHibernate;

namespace MapProject.App_Start
{
	public class MapConfig
	{
		private readonly ContainerBuilder _builder;

		public MapConfig(ContainerBuilder builder)
		{
			_builder = builder;
		}

		public void Init()
		{
			_builder.Register(context => CreateSessionFactory()).SingleInstance();
			_builder.Register(context => context.Resolve<ISessionFactory>().OpenSession()).InstancePerHttpRequest();
		}

		private static ISessionFactory CreateSessionFactory()
		{
			const string connectionString = "DefaultConnection";
			return Fluently.Configure()
				.Database(MsSqlConfiguration.MsSql2008.ConnectionString(ConfigurationManager.ConnectionStrings[connectionString].ConnectionString).UseReflectionOptimizer())
				.Mappings(x => x.FluentMappings.AddFromAssemblyOf<Account>().Conventions.Add(ForeignKey.EndsWith("Id"), new NHibernateEnumConvertion()))
				.BuildConfiguration()
				.BuildSessionFactory();
		}
	}
}