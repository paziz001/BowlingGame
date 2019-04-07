﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Web.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost
                .CreateDefaultBuilder(args)
                .UseKestrel()
                .UseStartup<Startup>();
        }
    }
}