﻿using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;

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

            services.AddDbContext<PersistenceDbContext>(o => o.UseNpgsql("User ID=postgres;Password=postgres;Host=127.0.0.1;Port=5431;Database=PersistenceApp;"));

            //services.AddDbContext<IOvDbContext, OvDbContext>(o =>
            //{
            //    o.UseNpgsql(connectionStringBuilder.ConnectionString);

            //    //o.UseInMemoryDatabase($"test_db");
            //    //o.ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            //});

            services.AddScoped<PersistenceDbContext>();

            return services;
        }
    }
}
