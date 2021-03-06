using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendIO.Data;
using AttendIO.Services.Managers;
using AttendIO.Services.Services;
using AttendIO.Services.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AttendIO.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AppConfig = configuration;
        }

        public IConfiguration Configuration { get; }
        public static IConfiguration AppConfig { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(typeof(TimeLogServiceManager));
            services.AddScoped(typeof(UserServiceManager));
            services.AddScoped(typeof(AdminServiceManager));

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Referential")));

            var origins = Configuration["AllowedOrigins"].Split(';');
            services.AddCors(options =>
            {
                
                options.AddPolicy(name: "AllowedOrigins",
                                  builder =>
                                  {
                                      //builder.WithOrigins(origins);
                                      builder.AllowAnyOrigin();
                                      builder.AllowAnyHeader();
                                  });
            });

            services.AddControllers();

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowedOrigins");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
