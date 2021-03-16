using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MinhaEmpresa.CrudCliente.Application.Notifications;
using MinhaEmpresa.CrudCliente.Application.PipelineBehaviours;
using FluentValidation;

namespace MinhaEmpresa.CrudCliente.Application
{
    public static class ConfigurationModule
    {
        public static void RegisterApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(typeof(ConfigurationModule).Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationRequestBehavior<,>));

            services.AddScoped<IDomainNotificationContext, DomainNotificationContext>();
        }
    }
}
