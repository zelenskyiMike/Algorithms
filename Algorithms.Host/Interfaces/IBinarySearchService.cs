using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Host.Interfaces
{
	public interface IBinarySearchService
	{
		int? BinarySearch(IList<int> collection, int elementToSearch);
	}
}
