using Autofac;
using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;

namespace MapProject.Services.ServiceLocator
{
	/// <summary>
	/// AutofacServiceLocator
	/// </summary>
	[Serializable]
	public class AutofacServiceLocator : IServiceLocator, IDisposable
	{
		public IContainer Container { get; private set; }

		public AutofacServiceLocator(IContainer container)
		{
			Container = container;
		}

		#region Implementation of IServiceProvider

		public object GetService(Type serviceType)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Implementation of IServiceLocator

		public object GetInstance(Type serviceType)
		{
			throw new NotImplementedException();
		}

		public object GetInstance(Type serviceType, string key)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<object> GetAllInstances(Type serviceType)
		{
			throw new NotImplementedException();
		}

		public TService GetInstance<TService>()
		{
			return Container.Resolve<TService>();
		}

		public TService GetInstance<TService>(string key)
		{
			return Container.Resolve<TService>();
		}

		public IEnumerable<TService> GetAllInstances<TService>()
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Implementation of IDisposable

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
