using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Correspondence;
using Correspondence.Configurations;
using Microsoft.EntityFrameworkCore;
using Correspondence.Services;
using Correspondence.Interfaces;
using Correspondence.Models;
//using MySql.EntityFrameworkCore.Extensions;

namespace Correspondence
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
            services.AddEntityFrameworkMySql()
                .AddDbContext<CorrespContext>((serviceProvider, options) =>
                {
                    //options.UseMySql(Configuration.GetConnectionString("DefaultConnection"), ServerVersion.Parse("10.5.13-MariaDB"));
                    options.UseMySql(Configuration.GetConnectionString("DefaultConnection"), ServerVersion.Parse("8.0.24-mysql"));

                });

            services.AddRazorPages();

            services.AddControllersWithViews(); // new

            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IDtypeService, DTypeService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IMainService, MainService>();
            services.AddScoped<IPlaceService, PlaceService>();
            services.AddScoped<ISubeventService, SubeventService>();
            services.AddScoped<ISubthemeService, SubthemeService>();
            services.AddScoped<IThemeService, ThemeService>();
            services.AddScoped<IFilesService, FilesService>();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CorrespContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Shared/Error");
                app.UseHsts();
            }

            //Clean up the database if we are setting CleanUpDatabase flag in the app settings
            var databaseSettings = Configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();
            if (databaseSettings?.CleanUpDatabase ?? false)
                context.Database.EnsureDeleted();

            // Check that database is created and all the pending migrations are applied 
            var pendingMigrations = context.Database.GetPendingMigrations();
            if (pendingMigrations.Any())
                context.Database.Migrate();

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapRazorPages();
            //});
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Front}/{action=FrontIndex}/{id?}");
            });
        }
    }
}
