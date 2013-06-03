using MapProject.DomainModel.Entities.Base.Map;

namespace MapProject.DomainModel.Entities.Authority.Map
{
	public class AccountMap : EntityMap<Account>
	{
		public AccountMap()
		{
			References(x => x.Country).Column("CountryId");
			References(x => x.TravelCategory).Column("TravelCategoryId");
			References(x => x.TravelRank).Column("TravelRankId");

			Map(x => x.Email).Column("Email").Not.Nullable().Length(150);
			Map(x => x.FirstName).Column("FirstName").Not.Nullable().Length(150);
			Map(x => x.SecondName).Column("SecondName").Not.Nullable().Length(150);
			Map(x => x.LastName).Column("LastName").Length(150);
			Map(x => x.PassHash).Column("PassHash").Not.Nullable().Length(40);
			Map(x => x.Activity).Column("Activity").Not.Nullable();
			Map(x => x.Prefix).Column("Prefix");
			Map(x => x.Age).Column("Age").Precision(10);
			Map(x => x.Sex).Column("Sex");
			Map(x => x.PhotoPath).Column("PhotoPath").Length(400);
			Map(x => x.Note).Column("Note").Length(1000);
			Map(x => x.IsSendToMail).Column("IsSendToMail").Not.Nullable();
		}
	}
}