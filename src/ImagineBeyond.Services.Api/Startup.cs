using ImagineBeyond.Application.Customer.Interfaces;
using ImagineBeyond.Application.Customer.Services;
using ImagineBeyond.Domain.Interfaces.Repositories;
using ImagineBeyond.Domain.Interfaces.UoW;
using ImagineBeyond.Repository.Repository;
using ImagineBeyond.Repository.UnitOfWork;
using ImagineBeyond.Services.Api.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ImagineBeyond.Services.Api
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
            services.AddDatabaseSetup(Configuration);

            services.AddControllers();

            services.AddAutoMapperSetup();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Infra
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUoW, UnitOfWork>();

            //Application
            services.AddScoped<ICustomerAppService, CustomerAppService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
