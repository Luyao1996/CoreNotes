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
    /// web���
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// ���÷���
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //�кܶ�add��ͷ�ķ��� �����ǰѷ�����ӵ�ioc���������Ʒ�ת����
            //.net �����˺ܶ�������������
            //ioc���ã�1.ע�����ͣ�����ע�ᣩ
            //         2.����ʾ����Ϊ���������ṩ������ķ���ʵ��
            //services.Add()

            //���ÿ��� 3.0+  2.x��Ҫ�ֶ�Ӧ��nuget��
            services.AddCors();





            //services.add?? ��ע��ef core


            //����������������� һ���������һ��ʵ�� ����ĻḲ��ǰ���
            //1.��ʱ  ÿ���������������ʵ��
            //2.������ ÿ���ɹ�����󴴽�һ��ʵ��
            //3.���� ���ô��ڵ�ʵ��

            //ע�����ioc ������ ʹ��ʱ�ٴ���ʵ��
            //services.AddSingleton<Interface,class>(); ����
            //services.AddScoped<Interface,class>(); ������
            //services.AddTransient<Interface,class>(); ��ʱ
        }

        //�ܵ� 
        //IApplicationBuilder��ʵ��ʵ����������������run���󴴽�������
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //                         �ܵ�ģ��
            //
            //            --*********-----------**********-----------------
            //����->->-- |-*->--->--*> -->->-->-*-->-----*>--->-->---->--> |
            //           | *�м��1 *           *�м��2 *                 |
            //           | *        *           *        *                 |
            //��Ӧ <-<-<-| <*--<----<*---<----<--*-<--<---*-<--<--<----<-- |      
            //            -**********-----------**********-----------------



            //����м��1
            app.Use(async (context,next) => {
                await context.Response.WriteAsync("Welcom to Luyao`s World!--Use1 \r\n"); //����ʱ���
                await next();//������next��ֱ�ӷ���
                await context.Response.WriteAsync("End!--Use1 \r\n");//��Ӧʱ���
            });

          ////����м��2
          //app.Use(async (context, next) => {
          //    await context.Response.WriteAsync("Welcom to Luyao`s World!--Use2 \r\n"); //����ʱ���
          //    //await next();//������next��ֱ�ӷ���
          //    await context.Response.WriteAsync("End!--Use2 \r\n");//��Ӧʱ���
          //});
          //
          ////����м��3
          ////���һ���ն��м��ί�� �������next ���м���ض������һ���м��
          //app.Run(async context => {
          //   await context.Response.WriteAsync("Welcom to Luyao`s World!--Run \r\n");
          //});

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //����ƥ��·�ɺ��ս��
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
