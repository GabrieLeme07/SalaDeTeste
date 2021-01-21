using CQRS.API.Application.Commands;
using CQRS.API.Application.Events;
using CQRS.API.Application.Queries;
using CQRS.Core.Mediator;
using CQRS.Domain.Interfaces;
using CQRS.Infra.Data;
using CQRS.Infra.Data.Repository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // API
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<IAspNetUser, AspNetUser>();

            // Commands
            services.AddScoped<IRequestHandler<AdicionarPedidoCommand, FluentValidation.Results.ValidationResult>, PedidoCommandHandler>();

            // Events
            services.AddScoped<INotificationHandler<PedidoRealizadoEvent>, PedidoEventHandler>();

            // Application
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IPedidoQueries, PedidoQueries>();

            // Data
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<PedidosContext>();
        }
    }
}
