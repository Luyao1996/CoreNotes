using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MyCoreApi2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// 启动主机
        /// </summary>
        /// <param name="args"></param>
        /// <returns>一个主机生成器的实例</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>

            //配置通用主机
            //加载默认配置
            //加载环境变量(DOTNET开头的)
            //加载命令行参数(如果由命令行启动)
            //加载应用配置
            //加载日志组件
            Host.CreateDefaultBuilder(args)

                //配置webhost
                //调用里面的一些扩展方法 进行自定义配置
                //启用kestrel
                //kestrel:
                //(一个内置于core里面的类似iis的web服务器)
                //(在linux里性能>windows)
                //(高性能服务器,可以当做边缘服务器,可以直接面向web但是不推荐,因为功能太少)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //组件配置
                    //配置请求体的最大字节为2048 默认 30000000字节既是28.6M(最大上传29.6M文件)
                    //webBuilder.ConfigureKestrel((context,option)=> option.Limits.MaxRequestBodySize=2048);   

                    //主机配置项
                    webBuilder.UseStartup<Startup>();
                });
    }
}
