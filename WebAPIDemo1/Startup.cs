using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebAPIDemo1.MiddleWare;
using Microsoft.Extensions.Options;
using WebAPIDemo1.Service;
using WebAPIDemo1.Model;
using System.ComponentModel;
using StructureMap;
using System.Web;
using WebAPIDemo1.BookStructureMap;

namespace WebAPIDemo1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        //    StructureMapConfiguration.AddRegistry(new ServiceRegistry());

        //    //GlobalConfiguration.Configuration.UseStructureMap<ServiceRegistry>();

        //    //services.Add<ServiceRegistry>();

        //    //services.AddSingleton<IBookService, BookService>();
        //}

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
   
            services.AddMvc();

            var container = new StructureMap.Container();
            container.Configure(c =>
            {
                c.Populate(services);                
                c.AddRegistry<ServiceRegistry>();
                c.AddRegistry<BookDatabaseRegistry>();
                c.AddRegistry<ValidationRegistry>();
            });

            return container.GetInstance<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMiddleware<BookAPIMiddleWare>();
            app.UseMvc();
        }

    }

}
