using Algorithms.Host.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Host.Services
{
	public class BinarySearchService : IBinarySearchService
	{
		public int? BinarySearch(IList<int> collection, int elementToSearch)
		{
			int low = 0;
			int high = collection.Count - 1;

			while (low <= high)
			{
				var mid = (high + low) / 2;
				var guess = collection[mid];

				if (guess == elementToSearch)
					return mid;

				if (guess < elementToSearch)
					low = mid + 1;
				else 
					high = mid - 1;
			}

			return null;
		}
	}
}
