using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QLTHPT.Models;

namespace QLTHPT {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) 
        {
            services.AddControllersWithViews ();
            services.AddDistributedMemoryCache ();
            services.AddControllersWithViews ().AddRazorRuntimeCompilation ();
            services.AddDbContext<acomptec_qlthptContext> ();
            // ??ng k� d?ch v? l?u cache trong b? nh? (Session s? s? d?ng n�)
            services.AddSession (cfg => { // ??ng k� d?ch v? Session
                cfg.Cookie.Name = "xuanthulab"; // ??t t�n Session - t�n n�y s? d?ng ? Browser (Cookie)
                cfg.IdleTimeout = new TimeSpan (0, 120, 0); // Th?i gian t?n t?i c?a Session
            });
            // services.AddDistributedMemoryCache();

            // services.AddSession(options =>
            // {
            //     options.IdleTimeout = new TimeSpan(0, 120, 0);
            //     // options.IdleTimeout = TimeSpan.FromSeconds(60);
            //     options.Cookie.HttpOnly = true;
            //     options.Cookie.IsEssential = true;
            // });
            // services.AddControllersWithViews();
            // services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseExceptionHandler ("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts ();
            }
            app.UseHttpsRedirection ();
            app.UseStaticFiles ();

            app.UseRouting ();

            app.UseAuthorization ();

            app.UseSession ();

            app.UseEndpoints (endpoints => {
                endpoints.MapControllerRoute (
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}