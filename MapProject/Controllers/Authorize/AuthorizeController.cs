using System;
using System.Web.Mvc;
using MapProject.Controllers.Base;
using MapProject.Models;
using MapProject.Services.SecurityService;
using NHibernate;

namespace MapProject.Controllers.Authorize
{
	[Authorize]
	public class AuthorizeController : BaseController
	{
		public AuthorizeController(ISession session)
			: base(session)
		{
		}

		//[AllowAnonymous]
		//public ActionResult Login()
		//{
		//	if (HttpContext.User.Identity.IsAuthenticated)
		//	{
		//		return RedirectToAction("Index", "Home");
		//	}
		//	var model = new LoginModel
		//	{
		//		IsAuthenticated = false
		//	};
		//	return View(model);
		//}

		[HttpPost]
		[AllowAnonymous]
		public ActionResult Login(LoginModel model)
		{
			string message = null;
			try
			{
				var data = new LoginData { Login = model.UserName, Password = model.Password, RememberMe = model.RememberMe};
				if (!(ModelState.IsValid && WebSecurity.Login(data, out message)))
				{
					throw new Exception(message);
				}
				model.IsAuthenticated = true;
			}
			catch (Exception ex)
			{
				message = ex.Message;
				model.IsAuthenticated = false;
			}
			finally
			{
				model.ErrorMessage = message ?? string.Empty;
			}
			TempData["loginData"] = model;
			return RedirectToAction("Index", "Home");
		}

		[AllowAnonymous]
		public ActionResult LogOff()
		{
			try
			{
				WebSecurity.LogOff();
			}
			catch
			{
				
			}
			return RedirectToAction("Index", "Home");
		}
	}
}
