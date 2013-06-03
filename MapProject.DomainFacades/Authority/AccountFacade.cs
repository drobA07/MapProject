using System.Linq;
using MapProject.DomainFacades.Base;
using MapProject.DomainModel.Entities.Authority;
using NHibernate;
using NHibernate.Linq;

namespace MapProject.DomainFacades.Authority
{
	public class AccountFacade : BaseFacade<Account>
	{
		public AccountFacade(ISession session) : base(session)
		{
		}

		public Account GetUser(string email)
		{
			return Session.Query<Account>().FirstOrDefault(i => i.Email.Equals(email));
		}

		public Account GetUser(int id)
		{
			return GetEntityById(id);
		}
	}
}
