using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjectionDemo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DependencyInjectionDemo
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
            #region 注册不同生命周期的服务
            // 单例模式
            services.AddSingleton<IMySingletonService, MySingletonService>();
            // Scope 的生命周期
            services.AddScoped<IMyScopedService, MyScopedService>();
            // 瞬时生命周期
            services.AddTransient<IMyTransientService, MyTransientService>();
            #endregion

            #region 
            //直接注册实例
            services.AddSingleton<IOrderService>(new OrderService());

            // 工厂方式注册
            //services.AddSingleton<IOrderService>(serviceProvider =>
            //{
            //    return new OrderServiceEx();
            //}); 
            //services.AddScoped<IOrderService>(serviceProvider =>
            //{
            //    //serviceProvider.GetService<T>();
            //    return new OrderServiceEx();
            //});
            #endregion

            services.TryAddSingleton<IOrderService, OrderServiceEx>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
