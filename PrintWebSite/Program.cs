using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PrintWebSite.Code.Extensions;


namespace PrintWebSite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var serviceProvider = services.GetRequiredService<IServiceProvider>();
                    var configuration = services.GetRequiredService<IConfiguration>();

                    //Seed.SeedData(serviceProvider, configuration).Wait();  //---> Use For Seeding Data To DB

                }
                catch (Exception exception)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(exception, "An error occurred while creating roles");
                }
            }
            host.Run();
        }
        //public static IWebHost BuildWebHost(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        //.UseSetting("https_port", "443")                
        //        .UseStartup<Startup>()
        //        .Build();

        public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(AddDbConfiguration)
            //.ConfigureAppConfiguration((hostingContext, config) =>
            //{
            //    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);                
            //})
            .UseStartup<Startup>()
            .Build();

        //private static void AddDbConfiguration(WebHostBuilderContext context, IConfigurationBuilder builder)
        private static void AddDbConfiguration(IConfigurationBuilder builder)
        {
            var configuration = builder.Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.AddConfigDbProvider(options => options.UseSqlServer(connectionString));
        }
    }
}
