using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WeatherMicroService
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                var latString = context.Request.Query["Lat"].FirstOrDefault();
                var longString = context.Request.Query["long"].FirstOrDefault();
                await context.Response.WriteAsync(String.Format("Latitude: {0} Longitude: {1}", latString, longString));
            });
        }
    }

    public static class Extensions{
        public static double? TryParse(this string input){
            double result;
            if(double.TryParse(input, out result)){
                return result;
            }
            else{
                return null;
            }
        }
    }
}
