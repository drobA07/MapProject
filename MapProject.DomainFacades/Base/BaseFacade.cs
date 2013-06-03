using System;
using System.Collections.Generic;
using System.Linq;
using MapProject.DomainModel.Entities.Dictionary;
using NHibernate;
using NHibernate.Linq;

namespace MapProject.DomainFacades.Base
{
	public abstract class BaseFacade<TType> : IBaseFacade
	{
		public ISession Session { get; set; }

		protected BaseFacade(ISession session)
		{
			Session = session;
		}

		public virtual bool SaveOrUpdate(TType entity)
		{
			return BaseEntityAction(entity, type =>
			{
				Session.SaveOrUpdate(entity);
				return 0;
			});
		}

		public virtual bool Delete(TType entity)
		{
			return BaseEntityAction(entity, type =>
			{
				Session.Delete(entity);
				return 0;
			});
		}

		protected virtual TType GetEntityById(object id)
		{
			return Session.Load<TType>(id);
		}

		protected IList<TType> GetEntities()
		{
			return Session.Query<TType>().ToList();
		}

		private bool BaseEntityAction(TType entity, Func<TType, int> method)
		{
			using (var transaction = Session.BeginTransaction())
			{
				method(entity);
				transaction.Commit();
			}
			return true;
		}
	}
}
