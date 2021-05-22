using APITakeawayTest.Data;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System;
using APITakeawayTest.Services;
using APITakeawayTest.Services.Interfaces;
using APITakeawayTest.web.Helpers.AutoMapperProfiles;
using Microsoft.Extensions.Configuration;

namespace APITakeawayTest.web
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //services.AddDbContext<LaptopDbContext>(op => op.UseInMemoryDatabase("LaptopConfiguration"));

            var conn = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<LaptopDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            //services.AddControllersWithViews()
            //    .AddNewtonsoftJson(options =>
            //        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc(
                    "LaptopApi",
                    new OpenApiInfo()
                    {
                        Title = "Laptop API",
                        Version = "1",
                        Description = "Laptop Operations",
                        Contact = new OpenApiContact
                        {
                            Email = "someone@nudgedigital.co.uk/",
                            Name = "Admin"
                        }
                    }
                );

                config.MapType<TimeSpan>(() => new OpenApiSchema
                {
                    Type = "string",
                    Example = new OpenApiString("00:00:00")
                });
            });

            services.AddSingleton(provider => new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ConfigurationProfile());
            }).CreateMapper());

            services.AddScoped<IConfigurationService, ConfigurationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/LaptopApi/swagger.json", "Laptop API");

                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
