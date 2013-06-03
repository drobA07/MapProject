using System.Collections.Generic;
using System.Linq;

namespace MapProject.Shared.Common
{
	public class Functions
	{
		public static IList<int> GetAges()
		{
			return Enumerable.Range(1, 100).ToList();
		}
	}
}
