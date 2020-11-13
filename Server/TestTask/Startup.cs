using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestTask.Domain;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using TestTask.Data;

namespace TestTask
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Reactions", Version = "v1" });
            });

            services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase(databaseName: "TestTask"));

            services.AddScoped<INoteStorage, NoteStorage>();
            services.AddScoped<INoteService, NoteService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger()
                   .UseSwaggerUI(config =>
                   {
                       config.SwaggerEndpoint("/swagger/v1/swagger.json", "Relations.API V1");
                   });

                app.UseCors(builder => builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin());
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
