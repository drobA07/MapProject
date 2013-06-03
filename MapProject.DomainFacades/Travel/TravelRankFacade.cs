using System.Collections.Generic;
using MapProject.DomainFacades.Base;
using MapProject.DomainModel.Entities.Travel;
using NHibernate;

namespace MapProject.DomainFacades.Travel
{
	public class TravelRankFacade : BaseFacade<TravelRank>
	{
		public TravelRankFacade(ISession session) : base(session)
		{
		}

		public IList<TravelRank> GetTravelRanks()
		{
			return GetEntities();
		}
	}
}
