using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Security;
using MapProject.DomainFacades.Authority;
using MapProject.DomainModel.Entities.Authority;
using MapProject.DomainModel.Mappers.AccountMapper;
using MapProject.DomainModel.Models.Account;
using MapProject.Services.SecurityService.Base;
using MapProject.Services.SecurityService.Message;
using NHibernate;

namespace MapProject.Services.SecurityService
{
	public class WebSecurity : ISecurity
	{
		private WebSecurity(ISession session, HttpContext context)
		{
			//Session = session;
			Context = context;
			_accountFacade = new AccountFacade(session);
		}

		private readonly AccountFacade _accountFacade;

		private IIdentity Identity
		{
			get { return Context.User.Identity; }
		}

		public bool IsAuthenticated
		{
			get { return Identity.IsAuthenticated; }
		}

		public int CurrentUserId
		{
			get
			{
				int userId;
				return int.TryParse(Identity.Name, out userId) ? userId : 0;
			}
		}

		public Account CurrentUser
		{
			get { return _accountFacade.GetUser(CurrentUserId); }
		}

		//private ISession Session { get; set; }

		private HttpContext Context { get; set; }

		public static WebSecurity GetInstance(ISession session, HttpContext context)
		{
			return new WebSecurity(session, context);
		}

		public bool Login(LoginData data, out string result)
		{
			var login = _accountFacade.GetUser(data.Login);
			if (login == null)
			{
				result = Messanger.Get(EMessages.UserDoesntExist);
				return false;
			}
			if (!login.PassHash.SequenceEqual(data.PasswordHash ?? GetSha1Hash(data.Password)))
			{
				result = Messanger.Get(EMessages.IncorrectUserPassword);
				return false;
			}

			//запись в cookie(AuthCookie)
			//data.User = login;
			FormsAuthentication.SetAuthCookie(login.Id.ToString(), data.RememberMe);
			result = string.Empty;
			return true;
		}

		private static byte[] GetSha1Hash(string password)
		{
			return new SHA1Managed().ComputeHash(Encoding.GetEncoding(1251).GetBytes(password));
		}

		public bool Login(int id)
		{
			string result;
			var user = _accountFacade.GetUser(id);
			return Login(new LoginData
			{
				Login = user.Email,
				PasswordHash = user.PassHash
			}, out result);
		}

		public void LogOff()
		{
			//удаление cookie
			FormsAuthentication.SignOut();
		}

		public void TryRecoverFromCookie()
		{
			int id;
			var identity = Context.User.Identity;
			if (!(identity.IsAuthenticated && int.TryParse(identity.Name, out id) && Login(id)))
			{
				LogOff();
			}
		}

		public bool CreateUserAndAccount(RegisterModel model, out string result)
		{
			result = Messanger.Get(EMessages.CannotCreateUser);
			var account = new Account();
			var accountMapper = new AccountMapper();
			accountMapper.Map(model, account);
			return _accountFacade.SaveOrUpdate(account);
		}
	}
}
