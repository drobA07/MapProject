using System.Collections.Generic;
using MapProject.DomainFacades.Base;
using MapProject.DomainModel.Entities.Travel;
using NHibernate;

namespace MapProject.DomainFacades.Travel
{
	public class TravelCategoryFacade : BaseFacade<TravelCategory>
	{
		public TravelCategoryFacade(ISession session) : base(session)
		{
		}

		public IList<TravelCategory> GetTravelCategories()
		{
			return GetEntities();
		}
	}
}
