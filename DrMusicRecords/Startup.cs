using System;
using DrMusicRecords.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using DrMusic;

namespace DrMusicRecords
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MusicRecordsContext>(opt => opt.UseInMemoryDatabase("MusicRecords"));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Music Records API",
                    Version = "v1.0",
                    Description = "Example of OpenAPI for api/musicRecords",
                    Contact = new OpenApiContact()
                    {
                        Email = "NewEmail@email.com",
                        Name = "YouNameHere",
                        Url = new Uri("http://UrlToHelpPage.com"),
                    },
                    License = new OpenApiLicense()
                    {
                        Name = "NameHere",
                        Url = new Uri("http://UrlToHelpPage.com"),
                    }
                }
                );
            });
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Music Records API v1.0")
            );

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
