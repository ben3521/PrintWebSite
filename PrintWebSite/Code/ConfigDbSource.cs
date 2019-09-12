using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PrintWebSite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintWebSite.Code
{
    public class ConfigDbSource : IConfigurationSource
    {
        private readonly Action<DbContextOptionsBuilder> _optionsAction;

        public ConfigDbSource(Action<DbContextOptionsBuilder> optionsAction)
        {
            _optionsAction = optionsAction;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new ConfigDbProvider(_optionsAction);
        }
    }


    public class ConfigDbProvider : ConfigurationProvider
    {
        private readonly Action<DbContextOptionsBuilder> _options;

        public ConfigDbProvider(Action<DbContextOptionsBuilder> options)
        {
            _options = options;
        }

        public override void Load()
        {
            var builder = new DbContextOptionsBuilder<PrintWebSiteDbContext>();
            _options(builder);

            using (var context = new PrintWebSiteDbContext(builder.Options))
            {
                var items = context.Configurations
                    .AsNoTracking()
                    .ToList();

                foreach (var item in items)
                {
                    Data.Add(item.Key, item.Value);
                }
            }
        }
    }

}
