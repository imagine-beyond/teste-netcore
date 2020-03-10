using ImagineBeyond.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ImagineBeyond.Services.Api.Configurations
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));            

            services.AddDbContext<InfraContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));            
        }
    }
}
