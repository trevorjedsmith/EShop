using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using TheStoreCore.Web.TheStoreCore.Repositories.Concrete;
using TheStoreCore.Web.TheStoreCore.Repositories.Abstract;
using TheStoreCore.Web.TheStoreCore.Services.Abstract;
using TheStoreCore.Web.TheStoreCore.Services;
using TheStoreCore.Web.Migrations.SeedData;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TheStoreCore.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

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
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<DataContext>(opts => opts.UseSqlServer((Configuration["ConnectionStrings:TheStoreCore"])));



            services.AddMvc();

            services.AddMemoryCache();
            services.AddSession();

            //Injections
            //Move to new DI injector for a bigger project
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IDatabaseContext, DataContext>();
            services.AddTransient<IDbSession, DbSession>();
            services.AddTransient<IProductService, ProductService>();
            services.AddScoped(typeof(IEntityRepository<>), typeof(EntityRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            SeedData.EnsurePopulated(app);
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Product}/{action=List}/{id?}");
            });
        }
    }
}
