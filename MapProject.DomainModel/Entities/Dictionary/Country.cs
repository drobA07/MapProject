using MapProject.DomainModel.Entities.Base;

namespace MapProject.DomainModel.Entities.Dictionary
{
	public class Country : Entity
	{
		public virtual string Name { get; set; }
		public virtual string FullName { get; set; }
	}
}
