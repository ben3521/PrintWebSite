using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintWebSite.Code.Extensions
{   
        public static class ConfigurationExtensions
        {
            public static IConfigurationBuilder AddConfigDbProvider(
                this IConfigurationBuilder configuration, Action<DbContextOptionsBuilder> setup)
            {
                configuration.Add(new ConfigDbSource(setup));
                return configuration;
            }
        }  
}
