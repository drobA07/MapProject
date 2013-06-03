using System.Collections.Generic;

namespace MapProject.Services.SecurityService.Message
{
	public static class Messanger
	{
		private static readonly Dictionary<EMessages, string> Messages = new Dictionary<EMessages, string>();

		static void Add(EMessages key, string value)
		{
			Messages.Add(key, value);
		}

		public static string Get(EMessages name)
		{
			return Messages[name];
		}

		static Messanger()
		{
			Add(EMessages.IncorrectUserPassword, "Неверное имя пользователя или пароль");
			Add(EMessages.UserDoesntExist, "Отсутствует данный пользователь");
			Add(EMessages.CannotCreateUser, "Не удалось создать пользователя");
		}
	}
}