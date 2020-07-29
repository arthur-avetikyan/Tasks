using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Store.DAL.Infrastructure;
using Store.IServices;
using Store.Mapper;
using Store.Services;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Market
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        public static IConfiguration _configuration;

        static async Task<int> Main(string[] args)
        {
            using (IHost host = CreateHostBuilder(args).Build())
            {
                await host.StartAsync();
                IHostApplicationLifetime lifetime = host.Services.GetRequiredService<IHostApplicationLifetime>();

                using (IServiceScope lScope = _serviceProvider.CreateScope())
                {
                    await lScope.ServiceProvider.GetService<ApplicationStart>().Run();
                }

                lifetime.StopApplication();
                await host.WaitForShutdownAsync();
            }
            return 0;
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host
                 .CreateDefaultBuilder(args)
                 .UseConsoleLifetime()
                 .ConfigureServices(ConfigureServices);
        }

        public static void ConfigureServices(HostBuilderContext context, IServiceCollection serviceCollection)
        {
            _configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json",
                            optional: false,
                            reloadOnChange: true).Build();

            serviceCollection
                .AddDbContext<MarketDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"),
                s => s.MigrationsAssembly(Assembly.GetAssembly(typeof(MarketDbContext)).FullName)));

            IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile(new EntityToDTOProfile())).CreateMapper();

            serviceCollection
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddSingleton(mapper)
                .AddScoped<IProductService, ProductService>()
                .AddScoped<ApplicationStart>();

            _serviceProvider = serviceCollection.BuildServiceProvider(true);
        }
    }
}
