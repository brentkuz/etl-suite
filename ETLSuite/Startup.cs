﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ETLSuite.Business.Factories;
using ETLSuite.Business.Services;
using ETLSuite.Data;
using ETLSuite.Data.Repositories;
using ETLSuite.Models.Factories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace ETLSuite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddMvc()
                //avoid Camel Cased JSON
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver()); ;
            services.AddAutoMapper();

            //setup EF
            var connStr = Configuration.GetSection("ConnectionStrings").GetValue<string>("ETLDataConnectionString");
            services.AddDbContext<ETLDataContext>(options => options.UseSqlServer(connStr));


            ConfigureWeb(services);
            ConfigureBusiness(services);            
            ConfigureData(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var bldr = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

            Configuration = bldr.Build();


            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public void ConfigureWeb(IServiceCollection services)
        {
            services.AddTransient<IDbConnectionDefinitionViewModelFactory, DbConnectionDefinitionViewModelFactory>();
        }

        private void ConfigureBusiness(IServiceCollection services)
        {
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IDbConnectionDefinitionService, DbConnectionDefinitionService>();
            services.AddTransient<IDbConnectionDefinitionFactory, DbConnectionDefinitionFactory>();
        }
        private void ConfigureData(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ILogEntryRepository, LogEntryRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IDbConnectionDefinitionRepository, DbConnectionDefinitionRepository>();
        }
    }
}
