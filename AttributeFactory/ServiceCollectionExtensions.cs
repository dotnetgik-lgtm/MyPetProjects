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
        var implementations = new List<Type>();
        var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.IsDynamic);

        foreach (var assembly in assemblies)
        {
            Type[] types;
            try
            {
                types = assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException ex)
            {
                types = ex.Types.Where(t => t is not null).ToArray()!;
            }

            foreach (var t in types)
            {
                if (t is null) continue;
                if (!typeof(TProduct).IsAssignableFrom(t) || !t.IsClass || t.IsAbstract) continue;
                if (t.GetCustomAttribute<ProductKeyAttribute>() is null) continue;
                implementations.Add(t);
            }
        }

        foreach (var type in implementations)
        {
            services.Add(new ServiceDescriptor(type, type, lifetime));
            services.Add(new ServiceDescriptor(typeof(TProduct), type, lifetime));
        }

        services.AddSingleton<AttributeFactory<TProduct>>();
        return services;
    }
}
