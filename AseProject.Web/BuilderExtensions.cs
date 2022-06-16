using AseProject.Core;

namespace AseProject.Web;

public static class BuilderExtensions
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        AddDescriptors(builder, new Infrastructure.Installer());
        AddDescriptors(builder, new Business.Installer());
    }

    private static void AddDescriptors(WebApplicationBuilder builder, IInstaller installer)
    {
        foreach (var definition in installer.GetDependencies())
        {
            builder.Services.Add(new ServiceDescriptor(definition.ServiceType, definition.ImplementationType, definition.Lifetime));
        }
    }
}