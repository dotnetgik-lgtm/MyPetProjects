using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace AttributeFactory;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAttributeFactory<TProduct>(
        this IServiceCollection services,
        ServiceLifetime lifetime = ServiceLifetime.Transient)
        where TProduct : class
    {
        var implementations = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => typeof(TProduct).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
            .Where(t => t.GetCustomAttribute<ProductKeyAttribute>() is not null);

        foreach (var type in implementations)
            services.Add(new ServiceDescriptor(type, type, lifetime));

        services.AddSingleton<AttributeFactory<TProduct>>();
        return services;
    }
}
