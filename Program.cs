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
        /// ��������
        /// </summary>
        /// <param name="args"></param>
        /// <returns>һ��������������ʵ��</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>

            //����ͨ������
            //����Ĭ������
            //���ػ�������(DOTNET��ͷ��)
            //���������в���(���������������)
            //����Ӧ������
            //������־���
            Host.CreateDefaultBuilder(args)

                //����webhost
                //���������һЩ��չ���� �����Զ�������
                //����kestrel
                //kestrel:
                //(һ��������core���������iis��web������)
                //(��linux������>windows)
                //(�����ܷ�����,���Ե�����Ե������,����ֱ������web���ǲ��Ƽ�,��Ϊ����̫��)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //�������
                    //���������������ֽ�Ϊ2048 Ĭ�� 30000000�ֽڼ���28.6M(����ϴ�29.6M�ļ�)
                    //webBuilder.ConfigureKestrel((context,option)=> option.Limits.MaxRequestBodySize=2048);   

                    //����������
                    webBuilder.UseStartup<Startup>();
                });
    }
}
