using AutoMapper;

namespace MapProject.DomainModel.Mappers.Base
{
	public class BaseMapper<TSourceType, TTargetType>
	{
		public IMappingExpression<TSourceType, TTargetType> CreateMapper(TSourceType source, TTargetType target)
		{
			return Mapper.CreateMap<TSourceType, TTargetType>();
		}
	}
}
