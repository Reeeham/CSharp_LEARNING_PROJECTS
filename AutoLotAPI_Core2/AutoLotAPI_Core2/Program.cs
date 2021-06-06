using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using AutoLotDAL_Core2.DataInitialization;
using AutoLotDAL_Core2.EF;

namespace AutoLotAPI_Core2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            //var webHost = CreateWebHostBuilder(args);
            //using (var scope = webHost.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    var context = services.GetRequiredService<AutoLotContext>();
            //    MyDataInitializer.RecreateDatabase(context);
            //    MyDataInitializer.InitializeData(context);
            //}
            //webHost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
         WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        
    }
}
