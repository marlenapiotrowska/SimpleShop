using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SimpleShop.Application.Abstractions;

namespace SimpleShop.Application.Extensions;

public static class HandlerRegistrationExtensions
{
    public static IServiceCollection RegisterHandlersFromAssemblyContaining(this IServiceCollection services, Type marker)
    {
        var assembly = marker.Assembly;

        RegisterCommandHandlers(services, assembly);
        RegisterEventHandlers(services, assembly);

        return services;
    }

    private static void RegisterCommandHandlers(IServiceCollection services, Assembly assembly)
    {
        var handlerTypes = assembly.GetTypes()
            .Where(t => t is { IsClass: true, IsAbstract: false }
                && t.IsAssignableTo(typeof(IHandler))
                && !t.IsAssignableTo(typeof(IEventHandler)))
            .ToList();

        foreach (var implementationType in handlerTypes)
        {
            var interfaceType = Array.Find(implementationType.GetInterfaces(), i => i != typeof(IHandler) && i.IsAssignableTo(typeof(IHandler)));

            if (interfaceType is not null)
                services.AddScoped(interfaceType, implementationType);
        }
    }

    private static void RegisterEventHandlers(IServiceCollection services, Assembly assembly)
    {
        var eventHandlerTypes = assembly.GetTypes()
            .Where(t => t is { IsClass: true, IsAbstract: false }
                && t.IsAssignableTo(typeof(IEventHandler))
                && !t.IsAssignableTo(typeof(IHandler)))
            .ToList();

        foreach (var implementationType in eventHandlerTypes)
        {
            var handlerInterfaces = implementationType.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEventHandler<>));

            foreach (var interfaceType in handlerInterfaces)
                services.AddScoped(interfaceType, implementationType);
        }
    }
}
