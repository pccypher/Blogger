using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EST.Mp.Business.Abstract;
using EST.Mp.Business.Concrete.EntityFramework;
using EST.Mp.DataAccess.Abstract;
using EST.Mp.DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EST.Mp.WebUI
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
            services.AddMvc();            
            services.AddScoped<ICategoryServices, CategoryService>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<IArticleServices, ArticleService>();
            services.AddScoped<IArticleDal, EfArticleDal>();
            services.AddScoped<IUserServices, UserService>();
            services.AddScoped<IUserDal, EfUserDal>();
            services.AddScoped<ICommentServices, CommentService>();
            services.AddScoped<ICommentDal, EfCommentDal>();

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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
