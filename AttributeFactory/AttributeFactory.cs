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

        _registry = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => typeof(TProduct).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
            .Select(t => (type: t, attr: t.GetCustomAttribute<ProductKeyAttribute>()))
            .Where(x => x.attr is not null)
            .ToDictionary(x => x.attr!.Key, x => x.type);
    }

    public TProduct Create(string key)
    {
        if (!_registry.TryGetValue(key, out var type))
            throw new KeyNotFoundException($"No product registered for key '{key}'. Known keys: {string.Join(", ", _registry.Keys)}");

        return (TProduct)_provider.GetRequiredService(type);
    }

    public IEnumerable<string> RegisteredKeys => _registry.Keys;
}
