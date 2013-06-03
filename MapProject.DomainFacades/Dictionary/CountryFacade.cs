using System.Collections.Generic;
using MapProject.DomainFacades.Base;
using MapProject.DomainModel.Entities.Dictionary;
using NHibernate;

namespace MapProject.DomainFacades.Dictionary
{
	public class CountryFacade : BaseFacade<Country>
	{
		public CountryFacade(ISession session)
			: base(session)
		{
		}

		public IList<Country> GetCountries()
		{
			return GetEntities();
		}
	}
}
