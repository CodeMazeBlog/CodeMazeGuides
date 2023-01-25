using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityByExamples.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IdentityByExamples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().MigrateDatabase().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
