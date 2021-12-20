using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSessionTagHelperViewComponent
{
    public class Startup
    {
        // ViewComponent
        // TagHelper
        // Session
        // Cache

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddRazorPages(); // razorpages ile de �al��aca��m�z i�in bu serviside aktif hale getiriyoruz.
            services.AddSession();
  
            //services.AddRazorPages().AddRazorRuntimeCompilation();
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
            // E�er Login i�lemi yap�yorsa bu middleware �al��t�rmam�z laz�m
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseSession();

            //app.UseBrowserLink();

            app.UseEndpoints(endpoints =>
            {


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                // RazorPages sayfalar�nda Login Register var buraya tan�tmak laz�m
                endpoints.MapRazorPages();
            });



        }
    }
}
