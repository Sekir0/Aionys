﻿using Aionys.Data;
using Aionys.BL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Aionys.Configurations
{
    /// <summary>
    /// Db configurations and lifetime DI containers
    /// </summary>
    public class DbConfig : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
              options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Aionys")));

            services.AddScoped<INoteService, NoteService>();
        }
    }
}