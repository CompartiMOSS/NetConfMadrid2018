﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IS4.Auth
{
  public class Program
  {
    public static void Main(string[] args)
    {
        var host = CreateWebHostBuilder(args).Build();  
        SeedData.EnsureSeedData(host.Services); 
        host.Run(); 
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseIISIntegration()
            .UseKestrel()
            .UseStartup<Startup>();
  }
}
