using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Azure;
using BusinessLogic.src.repositories.aero_logging;
using BusinessLogic.src.models.configurations;
using BusinessLogic.contexts.aero_logging;
using Microsoft.OpenApi.Models;

namespace AeroLogging
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
            services.AddTransient<IAeroLoggerRepository, AeroLoggerRepository>();
            services.AddTransient<ICosmosLoggerDBContext, CosmosLoggerDBContext>();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pet API", Version = "v1" });
            });
            services.AddAzureClients(builder =>
            {
                builder.AddBlobServiceClient(Configuration["ConnectionStrings:aero-logging-account.mongo.cosmos.azure.com"]);
            });
            services.ConfigureAll<LogOptions>(opts => {
                opts.DatabaseName = Configuration["CosmosDB:AeroLogger:DatabaseName"];
                opts.Collection = Configuration["CosmosDB:AeroLogger:Collection"];
                opts.ConnectionString = Configuration["CosmosDB:AeroLogger:ConnectionString"];
                opts.Username = Configuration["CosmosDB:AeroLogger:Host"];
                opts.Passsword = Configuration["CosmosDB:AeroLogger:Password"];
                opts.SSL = bool.Parse(Configuration["CosmosDB:AeroLogger:SSL"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors(options => {
                    options.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .AllowAnyMethod();
                });
            }

            // enable middleware to serve generated Swagger as JSON Endpoint
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Aero Logging API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
