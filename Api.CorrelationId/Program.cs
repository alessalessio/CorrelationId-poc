using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;

namespace Api.CorrelationId
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //https://github.com/serilog/serilog-aspnetcore/issues/28
            string logTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [CorrelationId: {CorrelationId}  {Level:u}] [{SourceContext}] {EventId:j} {Message}{NewLine}{Exception}";

            

            CreateWebHostBuilder(args)
                .UseSerilog((context, configuration) => configuration
                    .Enrich.FromLogContext()
                    .MinimumLevel.Information()
                    .WriteTo.Console()
                    .WriteTo.File("log.txt", outputTemplate: logTemplate),
                    preserveStaticLogger: true)
                .Build()
                .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
          WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
    }
}
