using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;

namespace AseProject.Core;

public record ServiceDependency(
    Type ServiceType,
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
    Type ImplementationType,
    ServiceLifetime Lifetime = ServiceLifetime.Transient)
{
    public static ServiceDependency Singleton<TInterface, TImplementation>() => new (typeof(TInterface), typeof(TImplementation), ServiceLifetime.Singleton);
    public static ServiceDependency Scoped<TInterface, TImplementation>() => new (typeof(TInterface), typeof(TImplementation), ServiceLifetime.Scoped);
    public static ServiceDependency Transient<TInterface, TImplementation>() => new (typeof(TInterface), typeof(TImplementation));
}

public interface IInstaller
{
    IReadOnlyCollection<ServiceDependency> GetDependencies();
}