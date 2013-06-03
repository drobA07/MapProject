using System.Web.Mvc;
using MapProject.Controllers.Base;
using NHibernate;

namespace MapProject.Controllers.Authorize
{
	public class NonAuthorizeController : BaseController
	{
		public NonAuthorizeController(ISession session)
			: base(session)
		{
		}
	}
}