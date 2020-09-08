using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MojoDesignCollection.Models.DB;
using MojoDesignCollection.Models.Repository;

namespace MojoDesignCollection
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration config)
        {
            Configuration = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
         
            services.AddDbContext<MojoDesignCollectionDbContext>(opt =>
            {
                opt.UseSqlServer(
                    Configuration["ConnectionStrings:MojoDesignCollectionContext"]
                    );
            });
            services.AddMvc();
            services.AddRazorPages();
            services.AddDistributedMemoryCache(); // in memory data store
            services.AddSession();
            services.AddScoped<IStoreRepository, EfMdcRepository>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();

            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");

                endpoints.MapControllerRoute("catpage","category/Page{productPage:int}",
                    new {Conroller="Store",action="Index"});

                endpoints.MapControllerRoute("page", "category/Page{productPage:int}",
                    new { Conroller = "Store", action = "Index" });

                endpoints.MapControllerRoute("category", "{category}",
                    new { Conroller = "Store", action = "Index",productPage=1 });

                endpoints.MapControllerRoute("pagination", "Products/Page{productPage}",
                    new { Conroller = "Store", action = "Index", productPage = 1 });
                endpoints.MapRazorPages();
            });
            SeedData.EnsurePopulated(app);
        }
    }
}
