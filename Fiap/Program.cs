﻿using Fiap.Core.Context;
using Fiap.Custom;
using Fiap.Middlewares;
using Fiap.Core.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Fiap
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
            //Console.WriteLine("Hello World!");
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Statup>()
                .Build();
        }
    }

    public class Statup
    {


        public void ConfigureServices(IServiceCollection service)
        {
            //service.AddSingleton
            //service.AddScoped
            service.AddTransient<ILogCred, LogCred>();
            service.AddTransient<INoticiaService, NoticiaService>();

            var connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.NewDb2;Trusted_Connection=True;ConnectRetryCount=0";
            service.AddDbContext<TurismoContext>(option => option.UseSqlServer(connection));

            service.AddMvc();
            service.AddDataProtection()
                .SetApplicationName("admin")
                .PersistKeysToFileSystem(new System.IO.DirectoryInfo("C:/teste"));


            //service.AddAuthentication("app")
            //    .AddCookie("app", b => {
            //        b.LoginPath = "/account/index";
            //        b.AccessDeniedPath = "/account/denied";
            //    });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseLog();

            //app.UseMiddleware<MeuLogMiddleware>();


            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseMvc(
                routes =>
                {
                    routes.MapRoute(
                    name: "padrao, default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );

                });

            // app.MapWhen(
            //     context => context.Request.Query.ContainsKey("parametro"),
            //     myapp =>
            //     {
            //         myapp.Run(async (context) =>
            //             { await context.Response.WriteAsync("admin");

            //             });
            //     });


            // app.Map("/admin", myapp =>
            // {
            //     myapp.Run(async (context) =>
            //     {
            //         await context.Response.WriteAsync("admin");
            //     });
            // });

            // app.Use(async (context, next) =>
            //{

            //    var teste = 123;
            //    await next.Invoke();
            //    var retorno = 123;
            //});

            // app.Run(async (context) =>
            // {
            //     await context.Response.WriteAsync("boa noite");
            // });




            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("boa noite Fiap !");

            //});
        }




    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseLog(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MeuLogMiddleware>();
        }
    }
}


