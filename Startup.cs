using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CoreCodeCamp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CoreCodeCamp
{
  public class Startup
  {
        private readonly string MyAllowSpecificOrigins = "192.168.1.68:4200";
    public void ConfigureServices(IServiceCollection services)
    {
            services.AddCors(Options =>
            {
                Options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("192.168.1.65:7000", "192.168.1.65:7000").AllowAnyHeader().AllowAnyMethod();
                    });
            });

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder
            //        .AllowAnyMethod()
            //        .AllowCredentials()
            //        .SetIsOriginAllowed(("") => true)
            //        .AllowAnyHeader()); 
            //});
                
                
                

            services.AddDbContext<ShareContext>();
            services.AddScoped<IShareRepository, ShareRepository>();

      //services.AddDbContext<CampContext>();
      //services.AddScoped<ICampRepository, CampRepository>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

      services.AddControllers();



    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

            app.UseCors("CorsPolicy");

      app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(cfg =>
      {
        cfg.MapControllers();
      });
    }
  }
}
