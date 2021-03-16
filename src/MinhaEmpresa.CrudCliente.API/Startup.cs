using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MinhaEmpresa.CrudCliente.API.Configuration;
using MinhaEmpresa.CrudCliente.Application;
using MinhaEmpresa.CrudCliente.Domain;
using MinhaEmpresa.CrudCliente.Repository;

namespace MinhaEmpresa.CrudCliente.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddApiConfig();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<INotifier, Notifier>();

            services.RegisterRepository(this.Configuration.GetConnectionString("DefaultConnectionString"));
            
            services.RegisterApplication();

            services.AddOptions();

            services.AddMvc();

            services.AddAutoMapper(typeof(Startup).Assembly,
                typeof(Application.ConfigurationModule).Assembly);

            services.AddSwaggerGen();

            #region Serialização

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });

            #endregion
        }

      
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API DE CLIENTES");
            });
        }
    }
}
