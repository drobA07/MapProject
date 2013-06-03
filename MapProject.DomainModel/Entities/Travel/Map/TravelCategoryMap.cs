using MapProject.DomainModel.Entities.Base.Map;

namespace MapProject.DomainModel.Entities.Travel.Map
{
	public class TravelCategoryMap : EntityMap<TravelCategory>
	{
		public TravelCategoryMap()
		{
			Map(x => x.Name).Column("Name").Not.Nullable().Length(150);
		}
	}
}
