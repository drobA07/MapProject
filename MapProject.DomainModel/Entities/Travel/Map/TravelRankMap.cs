using MapProject.DomainModel.Entities.Base.Map;

namespace MapProject.DomainModel.Entities.Travel.Map
{
	public class TravelRankMap : EntityMap<TravelRank>
	{
		public TravelRankMap()
		{
			Map(x => x.Name).Column("Name").Not.Nullable().Length(150);
		}
	}
}
