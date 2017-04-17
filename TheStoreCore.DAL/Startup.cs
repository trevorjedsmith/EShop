using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TheStoreCore.DAL.TheStoreCore.Repositories.Abstract;
using TheStoreCore.DAL.TheStoreCore.Repositories.Concrete;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TheStoreCore.DAL.Migrations.SeedData;

namespace TheStoreCore.DAL
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(env.ContentRootPath)
           .AddJsonFile("config.json")
           .AddJsonFile($"config.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(opts => opts.UseSqlServer((Configuration["ConnectionStrings:TheStoreCore"])));

            services.AddCors(options =>
                     options.AddPolicy("TheStore",
                         corsBuilder =>
                         {

                                 corsBuilder = corsBuilder.AllowAnyOrigin();

                                 corsBuilder = corsBuilder.AllowAnyHeader();

                                 corsBuilder = corsBuilder.AllowAnyMethod();

                                 corsBuilder = corsBuilder.AllowCredentials();
                             
                         })
                     );
        

            services.AddMvc();
            //Injections
            services.AddTransient<IDatabaseContext, DataContext>();
            services.AddTransient<IDbSession, DbSession>();
            services.AddScoped(typeof(IEntityRepository<>), typeof(EntityRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            SeedData.EnsurePopulated(app);
            app.UseMvc();
        }
    }
}
