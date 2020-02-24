using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MyCoreApi2
{
    /// <summary>
    /// web入口
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //有很多add开头的方法 作用是把服务添加到ioc容器（控制反转）里
            //.net 内置了很多服务组件在里面
            //ioc作用：1.注册类型（服务注册）
            //         2.请求示例。为其它类型提供容器里的服务实例
            //services.Add()

            //配置跨域 3.0+  2.x需要手动应用nuget包
            services.AddCors();





            //services.add?? 可注册ef core


            //服务的三种生命周期 一个服务仅有一个实现 后面的会覆盖前面的
            //1.暂时  每次请求从容器创建实例
            //2.作用域 每个可贵段请求创建一次实例
            //3.单例 永久存在的实例

            //注册服务到ioc 仅配置 使用时再创建实例
            //services.AddSingleton<Interface,class>(); 单例
            //services.AddScoped<Interface,class>(); 作用域
            //services.AddTransient<Interface,class>(); 暂时
        }

        //管道 
        //IApplicationBuilder的实例实在主机运行起来（run）后创建出来的
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //                         管道模型
            //
            //            --*********-----------**********-----------------
            //请求->->-- |-*->--->--*> -->->-->-*-->-----*>--->-->---->--> |
            //           | *中间件1 *           *中间件2 *                 |
            //           | *        *           *        *                 |
            //响应 <-<-<-| <*--<----<*---<----<--*-<--<---*-<--<--<----<-- |      
            //            -**********-----------**********-----------------



            //添加中间件1
            app.Use(async (context,next) => {
                await context.Response.WriteAsync("Welcom to Luyao`s World!--Use1 \r\n"); //请求时输出
                await next();//若不加next则直接返回
                await context.Response.WriteAsync("End!--Use1 \r\n");//响应时输出
            });

          ////添加中间件2
          //app.Use(async (context, next) => {
          //    await context.Response.WriteAsync("Welcom to Luyao`s World!--Use2 \r\n"); //请求时输出
          //    //await next();//若不加next则直接返回
          //    await context.Response.WriteAsync("End!--Use2 \r\n");//响应时输出
          //});
          //
          ////添加中间件3
          ////添加一个终端中间件委托 不用添加next 该中间件必定是最后一个中间件
          //app.Run(async context => {
          //   await context.Response.WriteAsync("Welcom to Luyao`s World!--Run \r\n");
          //});

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //用于匹配路由和终结点
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World! \r\n");
                });
            });
        }
    }
}
