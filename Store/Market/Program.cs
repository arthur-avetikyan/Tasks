using IServices;
using Microsoft.Extensions.DependencyInjection;
using Services;
using System;

namespace Market
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            RegisterServices();

            IServiceScope scope = _serviceProvider.CreateScope();
            scope.ServiceProvider.GetService<ApplicationStart>().Run();

            scope.Dispose();
        }

        private static void RegisterServices()
        {
            _serviceProvider = new ServiceCollection()
                .AddScoped<IDiscountProvider, DiscountProvider>()
                .AddScoped<ISalesManager, SalesManager>()
                .BuildServiceProvider(true);
        }
    }
}
