using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;

namespace ht22
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        //        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //            WebHost.CreateDefaultBuilder(args)
        //                .UseStartup<Startup>();

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel(options =>
                {
                    options.Listen(IPAddress.Loopback, 44355);
                    options.Listen(IPAddress.Any, 80);
                    options.Listen(IPAddress.Any, 443, listenOptions =>
                    {
                        var serverCertificate = LoadCertificate();
                        listenOptions.UseHttps(serverCertificate); // <- Configures SSL
                    });
                })
                .UseStartup<Startup>();

        private static X509Certificate2 LoadCertificate()
        {
            var physicalFileSystem = new PhysicalFileProvider("c:/t/hc22");
            var certificateFileInfo = physicalFileSystem.GetFileInfo("ladybuginternational.pfx");

            using (var certificateStream = certificateFileInfo.CreateReadStream())
            {
                byte[] certificatePayload;
                using (var memoryStream = new MemoryStream())
                {
                    certificateStream.CopyTo(memoryStream);
                    certificatePayload = memoryStream.ToArray();
                }

                return new X509Certificate2(certificatePayload, "shannon");
            }
        }
    }
}
