using Calculator.IOperationServices;
using Calculator.OperationServices;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Calculator
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            _serviceProvider = RegisterServices();
            IServiceScope scope = _serviceProvider.CreateScope();
            scope.ServiceProvider.GetService<Start>().Run();

            scope.Dispose();
        }

        private static IServiceProvider RegisterServices()
        {
            return new ServiceCollection()
                .AddSingleton<ILoggerService, Logger>()
                .AddSingleton<IUIHandllerService, UIHandler>()
                .AddScoped<IPluginManagerService, PluginManager>()
                .AddScoped<IOperationResolverService, OperationResolver>()
                .AddScoped<IOperationPerformerService, OperationPerformer>()
                .AddScoped<Start>()
                .BuildServiceProvider(true);
        }
    }
}