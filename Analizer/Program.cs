using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Analizer
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        public static IConfiguration _configuration;

        static void Main(string[] args)
        {
            RegisterServices();
            IServiceScope scope = _serviceProvider.CreateScope();

            _configuration.GetSection("IOSettings").Bind(scope.ServiceProvider.GetService<IOSettings>());

            scope.ServiceProvider.GetService<Application>().Run();
        }

        private static void RegisterServices()
        {
            _configuration = new ConfigurationBuilder()
               .AddJsonFile(@"C:\Users\arthu\source\repos\Tasks\Analizer\appsettings.json",
                            optional: false,
                            reloadOnChange: true)
               .Build();

            _serviceProvider = new ServiceCollection()
                .AddSingleton<IOSettings>()
                .AddTransient<AnalizerData>()
                .AddScoped<IAnalizerFactory, AnalizerFactory>()
                .AddScoped<Application>()
                .BuildServiceProvider(true);
        }
    }
}
