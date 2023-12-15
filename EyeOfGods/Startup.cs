using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EyeOfGods.Models;
using EyeOfGods.SupportClasses.UniGen;
using EyeOfGods.SupportClasses.StatGen;
using EyeOfGods.SupportClasses;
using EyeOfGods.SupportClasses.MapGenFactory;

namespace EyeOfGods
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
            services.AddControllersWithViews();
            services.AddDbContext<MyWargameContext>(options =>
            {
                //options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MyWargame;Trusted_Connection=True;MultipleActiveResultSets=true");
                options.UseSqlServer(@"Server=DESKTOP-EIT9M1T;Database=MyWargame;Trusted_Connection=true;TrustServerCertificate=True;MultipleActiveResultSets=true");
            });
            services.AddScoped<ILittleHelper, LittleHelper>();
            services.AddScoped<IUnitGenerator, UnitGenerator>();
            services.AddScoped<IStatistics, StatisticsGen>();
            services.AddScoped<IMapGenerator, MapGenerator>(); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Pages}/{action=Seed}/{id?}");
                    //pattern: "{controller=Pages}/{action=start}/{id?}");
            });
        }
    }
}
