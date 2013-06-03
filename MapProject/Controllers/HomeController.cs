using System.Web.Mvc;
using MapProject.Controllers.Authorize;
using MapProject.Models;
using NHibernate;

namespace MapProject.Controllers
{
	public class HomeController : NonAuthorizeController
	{
		public HomeController(ISession session) : base(session)
		{
		}

		public ActionResult Index()
		{
			var model = new HomeModel();
			var loginData = (LoginModel)TempData["loginData"];
			if (loginData != null)
			{
				model.LoginModel = loginData;
			}
			else
			{
				if (WebSecurity.IsAuthenticated)
				{
					model.LoginModel.Abbreviation = WebSecurity.CurrentUser.Abbreviation;
					model.LoginModel.IsAuthenticated = true;
				}
			}
			ViewBag.Title = "Тут что-то будет!";
			//ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			return View(model);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your app description page.";
			return View();
		}

		public ActionResult Products()
		{
			ViewBag.Message = "Your contact page.";
			return View();
		}

		public ActionResult Downloads()
		{
			ViewBag.Message = "Your contact page.";
			return View();
		}

		public ActionResult Help()
		{
			ViewBag.Message = "Your contact page.";
			return View();
		}

		public ActionResult Contacts()
		{
			ViewBag.Message = "Your contact page.";
			return View();
		}
	}

	public class HomeModel
	{
		public LoginModel LoginModel { get; set; }

		public HomeModel()
		{
			LoginModel = new LoginModel();
		}
	}
}
