namespace MapProject.Services.SecurityService.Base
{
	public interface ISecurity
	{
		bool Login(LoginData data, out string result);
		void LogOff();
	}
}
