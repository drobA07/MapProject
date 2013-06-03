using System;
using FluentNHibernate.Mapping;

namespace MapProject.DomainModel.Entities.Base.Map
{
	public class GenericEntityMap<T, TType> : ClassMap<T> 
		where T : GenericEntity<TType> 
		where TType : struct, IEquatable<TType>
	{
		public GenericEntityMap()
		{
			var name = typeof(T).Name;
			Id(t => t.Id).GeneratedBy.Identity().Column(string.Format("{0}Id", name));

			var ns = typeof(T).Namespace;
			if (ns == null)
			{
				return;
			}
			if (!ns.Contains("."))
			{
				return;
			}
			var schemaName = ns.Substring(ns.LastIndexOf(".", StringComparison.Ordinal) + 1);
			Schema(schemaName);
			Table(name);
			LazyLoad();
		}
	}
}