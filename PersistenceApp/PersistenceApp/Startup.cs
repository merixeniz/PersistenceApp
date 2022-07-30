using System;
using Application.Interfaces;
using Application.Interfaces.DataAccess;
using Application.Mappings;
using Application.Services;
using Application.Services.BackgroundJobs;
using Entities.Dto;
using FluentValidation.AspNetCore;
using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Infrastructure.Extensions;
using MassTransit;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PersistenceApp.Middleware;

namespace PersistenceApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PersistenceApp", Version = "v1" });
            });

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration.GetConnectionString("Redis");
                options.InstanceName = "PersistenceApp_"; // prefix przed kazdym kluczem
            });

            services.AddAutoMapper(typeof(Startup), typeof(MappingProfile));

            services.AddInfrastructure(Configuration);
            services.AddIdentityServices(Configuration);

            services.AddControllers().AddNewtonsoftJson();

            services.AddFluentValidation(fv =>
                fv.RegisterValidatorsFromAssemblyContaining<CreateVirtualDeviceDtoValidator>());

            #region CORS

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod()
                    .AllowAnyHeader()
                    //.AllowAnyOrigin();
                    .WithOrigins("http://localhost:3000")
                    .AllowCredentials();
                });

                opt.AddPolicy("CorsPolicyStaging", policy =>
                {
                    policy
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed(isOriginAllowed: _ => true)
                        .AllowCredentials();
                });

                opt.AddPolicy("CorsPolicyProd", policy =>
                {
                    policy
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed(isOriginAllowed: _ => true)
                        .AllowCredentials();
                });
            });

            #endregion

            #region Repositories

            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IVirtualDeviceRepository, VirtualDeviceRepository>();
            services.AddScoped<IBoardsRepository, BoardsRepository>();

            #endregion

            #region MassTransit

            //services.AddMassTransit(x =>
            //{
            //    x.UsingAzureServiceBus((context, cfg) =>
            //    {
            //        cfg.Host("connection-string");

            //        cfg.ReceiveEndpoint("input-queue", e =>
            //        {
            //            // all of these are optional!!
            //            e.PrefetchCount = 100;

            //            // number of "threads" to run concurrently
            //            e.MaxConcurrentCalls = 100;

            //            // default, but shown for example
            //            e.LockDuration = TimeSpan.FromMinutes(5);

            //            // lock will be renewed up to 30 minutes
            //            e.MaxAutoRenewDuration = TimeSpan.FromMinutes(30);
            //        });
            //    });
            //});

            #endregion

            services.AddScoped<ITestService, TestService>();

            services.AddSingleton<ControlledWorker>();
            services.AddHostedService(x => x.GetRequiredService<ControlledWorker>());
            services.AddHostedService<Worker>();

            services.AddExceptionMiddleware()
                .AddExceptionMappings<AppExceptionMappings>();

            services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme)
                    .AddCertificate();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PersistenceApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicyProd");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseExceptionMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
