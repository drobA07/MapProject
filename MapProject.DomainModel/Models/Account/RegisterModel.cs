using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MapProject.DomainModel.Entities.Dictionary;
using MapProject.DomainModel.Entities.Travel;
using MapProject.DomainModel.Models.Base;

namespace MapProject.DomainModel.Models.Account
{
	public class RegisterModel : BaseModel
	{
		[Required]
		[Display(Name = "E-mail")]
		public string Email { get; set; }

		[Display(Name = "")]
		public bool? Prefix { get; set; }

		[Display(Name = "Фамилия")]
		public string FirstName { get; set; }

		[Display(Name = "Имя")]
		public string SecondName { get; set; }

		[Display(Name = "Отчество")]
		public string LastName { get; set; }

		[Display(Name = "Страна")]
		public int? CountryId { get; set; }

		[Display(Name = "Возраст")]
		public int? AgeId { get; set; }

		[Display(Name = "")]
		public string PhotoPath { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Пароль")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Подтверждение пароля")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }

		[Display(Name = "Примечания")]
		public string Note { get; set; }

		[Display(Name = "Отправлять сообщения на E-mail")]
		public bool IsSendToMail { get; set; }

		[Display(Name = "Туристическая категория")]
		public int? TravelCategoryId { get; set; }

		[Display(Name = "Туристическое звание")]
		public int? TravelRankId { get; set; }

		public IList<Country> Countries { get; set; }

		public IList<int> Ages { get; set; }

		public IList<TravelCategory> TravelCategories { get; set; }

		public IList<TravelRank> TravelRanks { get; set; }
	}
}
