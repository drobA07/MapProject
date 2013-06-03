using System.Linq;
using MapProject.DomainModel.Entities.Base;
using MapProject.DomainModel.Entities.Dictionary;
using MapProject.DomainModel.Entities.Travel;

namespace MapProject.DomainModel.Entities.Authority
{
	public class Account : Entity
	{
		public virtual string Email { get; set; }
		public virtual string FirstName { get; set; }
		public virtual string SecondName { get; set; }
		public virtual string LastName { get; set; }
		public virtual byte[] PassHash { get; set; }
		public virtual bool Activity { get; set; }
		public virtual bool? Prefix { get; set; }
		public virtual Country Country { get; set; }
		public virtual int? Age { get; set; }
		public virtual bool? Sex { get; set; }
		public virtual string PhotoPath { get; set; }
		public virtual string Note { get; set; }
		public virtual bool IsSendToMail { get; set; }
		public virtual TravelCategory TravelCategory { get; set; }
		public virtual TravelRank TravelRank { get; set; }

		public virtual string FullName
		{
			get { return string.Format("{0} {1} {2}", FirstName, SecondName, LastName); }
		}

		public virtual string Abbreviation
		{
			get
			{
				return string.Format("{0} {1} {2}", FirstName, string.IsNullOrEmpty(SecondName) ? string.Empty : string.Format("{0}.", SecondName.First()), string.IsNullOrEmpty(LastName) ? string.Empty : string.Format("{0}.", LastName.First()));
			}
		}
	}
}
