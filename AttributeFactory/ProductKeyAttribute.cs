namespace AttributeFactory;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class ProductKeyAttribute : Attribute
{
    public string Key { get; }
    public ProductKeyAttribute(string key) => Key = key;
}
