using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace GFT.TechnicalTest
{
    public sealed class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                       .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                       .ConfigureWebHostDefaults(webBuilder =>
                            webBuilder
                                .ConfigureKestrel(k => k.AddServerHeader = false)
                                .UseStartup<Startup>());
        }
    }
}
