#region license

// <copyright company="ZAN LLC" file="Program.cs">
//   Copyright (c)2019 ZAN ALL RIGHTS RESERVED.
// </copyright>

#endregion

namespace Sample01
{
    #region region

    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

    #endregion

    /// <summary>
    /// The program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 程序入口
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <returns>
        /// The <see cref="IWebHostBuilder"/>.
        /// </returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args) // 使用默认的配置信息来初始化一个新的IWebHostBuilder实例
                .ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        var env = hostingContext.HostingEnvironment;

                        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                            .AddJsonFile("Content.json", optional: false, reloadOnChange: false)
                            .AddEnvironmentVariables();

                    })
                .UseStartup<Startup>(); // 为Web Host指定了Startup类
        }

        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args) // 调用上面的方法，返回一个IWebHostBuilder对象
                .Build() // 用上面返回的IWebHostBuilder对象创建一个IWebHost
                .Run(); // 运行上面创建的IWebHost对象从而运行我们的Web应用程序换句话说就是启动一个一直运行监听http请求的任务
        }
    }
}