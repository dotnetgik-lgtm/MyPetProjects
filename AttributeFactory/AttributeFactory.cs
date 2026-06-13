using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace AttributeFactory;

public class AttributeFactory<TProduct> where TProduct : class
{
    private readonly IServiceProvider _provider;
    private readonly Dictionary<string, Type> _registry;

    public AttributeFactory(IServiceProvider provider)
    {
        _provider = provider;
        _registry = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);

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
                var attr = t.GetCustomAttribute<ProductKeyAttribute>();
                if (attr is null) continue;

                var key = attr.Key;
                if (_registry.TryGetValue(key, out var existing))
                {
                    throw new InvalidOperationException($"Duplicate product key '{key}' found on types '{existing.FullName}' and '{t.FullName}'.");
                }

                _registry[key] = t;
            }
        }
    }

    public TProduct Create(string key)
    {
        if (!_registry.TryGetValue(key, out var type))
            throw new KeyNotFoundException($"No product registered for key '{key}'. Known keys: {string.Join(", ", _registry.Keys)}");

        return (TProduct)_provider.GetRequiredService(type);
    }

    public IReadOnlyCollection<string> RegisteredKeys => _registry.Keys.ToList().AsReadOnly();
}
