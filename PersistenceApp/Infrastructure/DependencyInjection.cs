using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionStringBuilder = new DbConnectionStringBuilder
            {
                { "Server", configuration["SQ_DB_HOST"] },
                { "Database", configuration["SQ_DB_NAME"] },
                { "Port", configuration["SQ_DB_PORT"] },
                { "Username", configuration["SQ_DB_USER"] },
                { "Password", configuration["SQ_DB_PASSWORD"] },
                { "Keepalive", configuration["SQ_DB_KEEPALIVE"] }
            };

            //services.AddDbContext<IOvDbContext, OvDbContext>(o =>
            //{
            //    o.UseNpgsql(connectionStringBuilder.ConnectionString);

            //    //o.UseInMemoryDatabase($"test_db");
            //    //o.ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            //});

            //services.AddScoped<OvDbContext>();

            return services;
        }
    }
}
