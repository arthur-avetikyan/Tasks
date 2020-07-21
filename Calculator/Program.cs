using Calculator.IOperationServices;
using Calculator.OperationServices;
using Calculator.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Calculator
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        public static IConfigurationRoot _configuration;

        static void Main(string[] args)
        {
            RegisterServices();

            IServiceScope scope = _serviceProvider.CreateScope();

            _configuration.GetSection("PluginSettings").Bind(scope.ServiceProvider.GetService<PluginSettings>());
            _configuration.GetSection("LoggingSettings").Bind(scope.ServiceProvider.GetService<LoggingSettings>());
            scope.ServiceProvider.GetService<ApplicationStart>().Run();

            scope.Dispose();
        }

        private static void RegisterServices()
        {
            _configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .Build();

            _serviceProvider = new ServiceCollection()
                .AddSingleton<IFileProviderService, LogFileProvider>()
                .AddSingleton<ILoggerService, Logger>()
                .AddSingleton<IUIHandllerService, UIHandler>()
                .AddScoped<IPluginManagerService, PluginManager>()
                .AddScoped<IOperationResolverService, OperationResolver>()
                .AddScoped<IOperationPerformerService, OperationPerformer>()
                .AddSingleton<PluginSettings>()
                .AddSingleton<LoggingSettings>()
                .AddScoped<ApplicationStart>()
                .BuildServiceProvider(true);
        }
    }
}