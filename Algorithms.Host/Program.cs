using Algorithms.Host.Helpers;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
.RegisterServices()
.BuildServiceProvider();
Console.WriteLine();