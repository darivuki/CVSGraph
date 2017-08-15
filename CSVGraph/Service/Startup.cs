using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Persistance.Shared;
using Microsoft.EntityFrameworkCore;
using Application.Stocks.Queries.GetStocksList;
using Persistance.Stocks;
using Application.Interfaces.Persitence;
using Application.Stocks.Commands.UploadStocks;

namespace Service
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add custom services.
            services.AddScoped<IUploadStocksCommand, UploadStocksCommand>();
            services.AddScoped<IGetStocksListQuery, GetStocksListQuery>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IDatabaseContext, DatabaseContext>();

            // Add framework services.
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));
            services.AddCors();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IDatabaseContext dbContext)
        {
            loggerFactory.AddDebug();
            loggerFactory.AddConsole();

            // Shows UseCors with CorsPolicyBuilder.
            app.UseCors(builder =>
               builder.WithOrigins("http://localhost:5000"));
            app.UseMvc();

            DatabaseInitializer.Initialize(dbContext);
        }
    }
}
