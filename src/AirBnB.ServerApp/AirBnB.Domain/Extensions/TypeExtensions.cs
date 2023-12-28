using System.Collections;

namespace AirBnB.Domain.Extensions;

public static class TypeExtensions
{
    public static IList<Type> GenericCollections { get; } = new List<Type>
    {
        typeof(IEnumerable<>),
        typeof(ICollection<>),
        typeof(IList<>),
        typeof(IAsyncEnumerable<>),
        typeof(IEnumerable)
    };

    public static IList<Type> NonGenericCollections { get; } = new List<Type>
    {
        typeof(IEnumerable),
        typeof(ICollection),
        typeof(IList)
    };

    public static bool IsCollection(this Type type)
    {
        var interfaceTypes = type.IsInterface ? [type] : type.GetInterfaces();

        return interfaceTypes.Any(
            interfaceType => interfaceType.IsGenericType
                ? GenericCollections.Contains(interfaceType.GetGenericTypeDefinition())
                : NonGenericCollections.Contains(interfaceType)
        );
    }

    public static bool IsTask(this Type type)
    {
        return type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(Task<>) || type.GetGenericTypeDefinition() == typeof(ValueTask<>));
    }

    public static Type? GetGenericArgument(this Type type)
    {
        return type.GetGenericArguments().FirstOrDefault();
    }
}