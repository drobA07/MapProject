using MapProject.DomainModel.Entities.Base.Map;

namespace MapProject.DomainModel.Entities.Dictionary.Map
{
	public class CountryMap : EntityMap<Country>
	{
		public CountryMap()
		{
			Map(x => x.Name).Column("Name").Not.Nullable().Length(50);
			Map(x => x.FullName).Column("FullName").Not.Nullable().Length(400);
		}
	}
}
