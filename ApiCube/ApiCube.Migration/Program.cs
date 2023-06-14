using System;
using System.IO;
using ApiCube.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace ApiCube.Migration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Applying migrations");
            var webHost = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<ConsoleStartup>()
                .Build();

            using (var context = (DatabaseContext) webHost.Services.GetService(typeof(DatabaseContext)))
            {
                context.Database.Migrate();
            }
            Console.WriteLine("Done");
        }
    }
}