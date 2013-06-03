using System.Web;
using System.Web.Mvc;
using MapProject.DomainModel.Entities.Authority;
using MapProject.DomainModel.Models.Base;
using MapProject.Services.SecurityService;
using NHibernate;

namespace MapProject.Controllers.Base
{
	public class BaseController : Controller
	{
		protected ISession _Session;

		protected HttpContext Context
		{
			get { return HttpContext.ApplicationInstance.Context; }
		}

		protected WebSecurity WebSecurity
		{
			get { return WebSecurity.GetInstance(_Session, Context); }
		}

		protected int CurrentUserGuid
		{
			get { return WebSecurity.CurrentUserId; }
		}

		public Account CurrentUser
		{
			get { return WebSecurity.CurrentUser; }
		}

		public BaseController(ISession session)
		{
			_Session = session;
		}

		//protected virtual void FillModel()
		//{
		//	//todo 
		//}
	}
}
