using CarService.BL.Interfaces;
using CarService.BL.Services;
using CarService.DL.InMemoryRepos;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;

namespace CarService
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
            services.AddSingleton(Log.Logger);

            services.AddAutoMapper(typeof(Startup));

            services.AddSingleton<IEmployeeRepository, EmployeeInMemoryRepository>();
            services.AddSingleton<IShiftRepository, ShiftInMemoryRepository>();
            services.AddSingleton<IServiceRepository, ServiceInMemoryRepository>();
            services.AddSingleton<IClientRepository, ClientInMemoryRepository>();
            services.AddSingleton<ICarRepository, CarInMemoryRepository>();
            services.AddSingleton<IProductRepository, ProductInMemoryRepository>();

            services.AddSingleton<IShiftsService, ShiftService>();
            services.AddSingleton<ICarsService, CarsService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.AddSingleton<IClientService, ClientService>();
            services.AddSingleton<IProductsService, ProductService>();
            services.AddSingleton<IServiceService, ServiceService>();

            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());

            //services.AddMvcCore().AddApiExplorer();
            //services.AddRazorPages();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarService", Version = "v1" });
            });
            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarService v1"));
            }

            //app.ConfigureExceptionHandler(logger);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
