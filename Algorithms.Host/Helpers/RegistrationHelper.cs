using Algorithms.Host.Interfaces;
using Algorithms.Host.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Algorithms.Host.Helpers
{
	public static class RegistrationHelper
	{
		public static IServiceCollection RegisterServices(this IServiceCollection serviceProvider)
		{
			serviceProvider.AddScoped<IBinarySearchService, BinarySearchService>();

			return serviceProvider;
		}
	}
}
