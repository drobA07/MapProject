using NHibernate;

namespace MapProject.DomainFacades.Base
{
	public interface IBaseFacade
	{
		ISession Session { get; set; }
	}
}
