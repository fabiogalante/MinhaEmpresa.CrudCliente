using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MinhaEmpresa.CrudCliente.Domain.Cliente.Repository;
using MinhaEmpresa.CrudCliente.Repository.Context;
using MinhaEmpresa.CrudCliente.Repository.Repository;

namespace MinhaEmpresa.CrudCliente.Repository
{
    public static class ConfigurationModule
    {
        public static void RegisterRepository(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<ContextApp>(c =>
            {
                c.UseSqlServer(connectionString);
            });
            
            services.AddScoped(typeof(UnitOfWork<>));

            services.AddScoped<IClienteRepository, ClienteRepository>();

        }
    }
}
