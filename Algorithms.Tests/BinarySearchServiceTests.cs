using Algorithms.Host.Services;
using FluentAssertions;

namespace Algorithms.Tests
{
	public class BinarySearchServiceTests
	{
		private readonly BinarySearchService _binarySearchService;
		public BinarySearchServiceTests()
		{
			_binarySearchService = new BinarySearchService();
		}

		[Theory]
		[InlineData(new int[] {1, 2, 3, 4}, 4)]
		[InlineData(new int[] {1, 2, 3, 4}, 1)]
		[InlineData(new int[] {1, 2, 3, 4, 5}, 3)]
		[InlineData(new int[] {1, 2, 2, 2}, 2)]
		[InlineData(new int[] {2}, 2)]
		public void BinarySearch_CanFindElement(IList<int> collection, int elementToSearch)
		{
			//Arrange
			//Act

			var result = _binarySearchService.BinarySearch(collection, elementToSearch);

			//Assert

			result.Should().NotBeNull();
			elementToSearch.Should().Be(collection[result.Value]);
		}

		[Theory]
		[InlineData(new int[] { 1, 2, 2, 2 }, 3)]
		[InlineData(new int[0] , 1)]
		public void BinarySearch_CanNotFindElement(IList<int> collection, int elementToSearch)
		{
			//Arrange
			//Act

			var result = _binarySearchService.BinarySearch(collection, elementToSearch);

			//Assert

			result.Should().BeNull();
		}
	}
}