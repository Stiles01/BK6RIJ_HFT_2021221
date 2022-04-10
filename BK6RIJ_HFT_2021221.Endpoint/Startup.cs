using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BK6RIJ_HFT_2021221.Data;
using BK6RIJ_HFT_2021221.Logic;
using BK6RIJ_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using BK6RIJ_HFT_2021221.Endpoint.Services;

namespace BK6RIJ_HFT_2021221.Endpoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {           

            services.AddTransient<IOrderLogic,OrderLogic>();
            services.AddTransient<IOrderRepository,OrderRepository>();
            services.AddTransient<ICustomerLogic, CustomerLogic>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IDeliveryLogic, DeliveryLogic>();
            services.AddTransient<IDeliveryRepository, DeliveryRepository>();
            services.AddTransient<IProductLogic, ProductLogic>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<BK6RIJ_HFT_2021221_DbContext, BK6RIJ_HFT_2021221_DbContext>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BK6RIJ_HFT_2021221.Endpoint", Version = "v1" });
            });
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BK6RIJ_HFT_2021221.Endpoint v1"));
            }

            
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SinalRHub>("/hub");
            });
        }
    }
}
