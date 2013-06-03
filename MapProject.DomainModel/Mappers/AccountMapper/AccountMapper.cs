using AutoMapper;
using MapProject.DomainModel.Entities.Authority;
using MapProject.DomainModel.Entities.Dictionary;
using MapProject.DomainModel.Entities.Travel;
using MapProject.DomainModel.Mappers.Base;
using MapProject.DomainModel.Models.Account;

namespace MapProject.DomainModel.Mappers.AccountMapper
{
	public class AccountMapper : BaseMapper<RegisterModel, Account>
	{
		public void Map(RegisterModel source, Account target)
		{
			CreateMapper(source, target)
				.ForMember(t => t.Country, map => map.MapFrom(s => s.CountryId.HasValue ? new Country { Id = s.CountryId.Value } : null))
				.ForMember(t => t.Age, map => map.MapFrom(s => s.AgeId))
				.ForMember(t => t.TravelCategory, opt => opt.MapFrom(s => s.TravelCategoryId.HasValue ? new TravelCategory { Id = s.TravelCategoryId.Value } : null))
				.ForMember(t => t.TravelRank, opt => opt.MapFrom(s => s.TravelRankId.HasValue ? new TravelRank { Id = s.TravelRankId.Value } : null));

			Mapper.Map(source, target);
		}
	}
}
