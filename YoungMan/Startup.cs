using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using YoungMan.Models;

namespace YoungMan
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>options.EnableEndpointRouting=false);
            services.AddMemoryCache();
            services.AddSession();
            
            services.AddTransient<IProductRepository,EfProducts>();
            services.AddTransient<ICategoryRepository, EfCategories>();
            services.AddTransient<IOrderRepository, EfOrders>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));

            services.AddDbContext<AppDbContext>(builder =>
                builder.UseSqlServer(Configuration["Data:YoungMan:ConnectionString"]));
            services.AddDbContext<AppIdentityContext>(builder =>
                builder.UseSqlServer(Configuration["Data:YoungManIdentity:ConnectionString"]));
            services.AddIdentity<IdentityUser,IdentityRole>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                } )
                .AddEntityFrameworkStores<AppIdentityContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();

            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseSession();
            
            app.UseMvcWithDefaultRoute();
        }
    }
}