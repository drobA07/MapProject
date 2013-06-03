using System;

namespace MapProject.DomainModel.Entities.Base
{
	[Serializable]
	public class GenericEntity<T> : IEquatable<GenericEntity<T>> where T : struct, IEquatable<T>
	{
		public virtual T Id { get; set; }

		public virtual bool Equals(GenericEntity<T> other)
		{
			if (ReferenceEquals(null, other))
			{
				return false;
			}
			if (ReferenceEquals(this, other))
			{
				return true;
			}
			return other.Id.Equals(Id);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}
			if (ReferenceEquals(this, obj))
			{
				return true;
			}
			if (obj.GetType() != GetType())
			{
				return false;
			}
			return Equals((GenericEntity<T>)obj);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		public static bool operator ==(GenericEntity<T> left, GenericEntity<T> right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(GenericEntity<T> left, GenericEntity<T> right)
		{
			return !Equals(left, right);
		}
	}
}