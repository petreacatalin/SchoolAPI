using FluentValidation.AspNetCore;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using School.DTOs.Dtos;
using School.DTOs.Profiles;
using School.Repositories;
using School.Services.Services.Implementation;
using SchoolAPI.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<SchoolDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.ConfigureJWT(Configuration);
            services.AddHangfire(x => x.UseSqlServerStorage("Server=localhost\\SQLEXPRESS;Database=SchoolAPI;Trusted_Connection=True;MultipleActiveResultSets=true"));
            services.AddHangfireServer();
            services.AddControllers()
                .AddFluentValidation(c => c.RegisterValidatorsFromAssembly(typeof(CardDtoValidator).Assembly))
                .AddNewtonsoftJson(options =>
                 options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.ConfigureSwagger();
            services.ConfigureIdentity();
            services.AddAuthentication();

            services.AddCors(o =>
            {
                o.AddPolicy("AllowAll", builder =>
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader());
            });

            services.RegisterAppServices();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly); 
           
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();                
            }

            app.SwaggerConfigure(Configuration["AppName"]);
            app.UseCors("AllowAll");
            app.UseHttpsRedirection(); 
            app.UseHangfireDashboard();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.ExceptionHandler();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //RecurringJob.AddOrUpdate<ExportExcelsService>(
            //        nameof(ExportExcelsService),
            //        x => x.RunAsync(),Cron.Minutely());

        }
       
    }
}
