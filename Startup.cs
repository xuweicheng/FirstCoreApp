using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FirstCoreApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                            IHostingEnvironment env,
                            IGreeter greeter,
                            ILogger<Startup> logger,
                            IConfiguration config)
        {
            // IHostingEnvironment gives you the runtime environment
            if (env.IsDevelopment())
            {
                // env.ApplicationName
                // env.ContentRootPath
                // env.EnvironmentName, assess the host value of "ASPNETCORE_ENVIRONMENT" environment variable
                // env.IsStaging()
                // env.IsProduction()
                // env.IsEnvironment("QA")
                // middleware, shows developer friendly error page.
                app.UseDeveloperExceptionPage();
            }

            // build my custom middle ware
            // app.Use only invoke once to setup the middlware
            // the inner return async context => {} is the middleware 
            // which get invoked for each http request
            // app.Use(next => { //next is RequestDelegate, also the next middleware in the pipeline
            //     return async context => {
            //         logger.LogInformation("Request incoming");
            //         if(context.Request.Path.StartsWithSegments("/mym"))
            //         {
            //             await context.Response.WriteAsync("Hit!!");
            //             logger.LogInformation("Request handled by custom middleware");
            //         }
            //         else
            //         {
            //             await next(context);
            //             logger.LogInformation("Response outgoing");
            //         }
            //     };
            // });

            //make every request serve the welcome page
            // app.UseWelcomePage(new WelcomePageOptions {
            //     //url mapping just for welcom page
            //     Path="/wp"
            // });

            app.Run(async (context) =>
            {
                // throw new Exception("error!");

                var greetingMessage = greeter.getGreetingOfToday();
                var greetingFromConfig = config["Greeting"];
                // await context.Response.WriteAsync(greetingMessage);
                await context.Response.WriteAsync($"{greetingMessage} : {env.EnvironmentName} : {greetingFromConfig}");
            });
        }
    }
}
