using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TechSpace.Data.DependencyInjection;
using TechSpace.DevTo.DependencyInjection;
using TechSpace.Reddit;
using TechSpace.Reddit.DependencyInjection;
using TechSpace.Web.Services;

namespace TechSpace.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "client-app/build"; });

            // Data layer
            services.AddTechSpaceRepositories(Configuration["ConnectionStrings:TechSpace"]);
            
            // Services for logic abstraction
            services.AddSingleton<ITechSpacesService, SpacesService>();
            services.AddSingleton<IPostsService, PostsService>();

            // Connectors to 3rd party APIs
            services.AddReddit(new RedditOptions());
            services.AddDevTo(new DevToOptions());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "client-app";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start:react");
                }
            });
        }
    }
}