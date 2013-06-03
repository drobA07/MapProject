namespace MapProject.Services.SecurityService
{
	public class LoginData
	{
		public LoginData()
		{
			RememberMe = true;
		}

		public string Login { get; set; }
		public string Password { get; set; }
		public byte[] PasswordHash { get; set; }
		public bool RememberMe { get; set; }
	}
}
