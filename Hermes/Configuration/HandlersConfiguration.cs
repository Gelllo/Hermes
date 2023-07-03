using System.Reflection;
using Hermes.Application;
using Hermes.Infrastracture;
using Hermes.Infrastracture.Database;

namespace Hermes.Web.Configuration
{
    public static class HandlersConfiguration
    {
        public static IServiceCollection ConfigureHandlers(this IServiceCollection services)
        {
            services.Scan(selector =>
            {
                selector.FromAssemblyDependencies(Assembly.GetAssembly(typeof(DataContext)))
                    .AddClasses(filter =>
                    {
                        filter.AssignableTo(typeof(IQueryHandler<,>));
                    })
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
            });

            services.Scan(selector =>
            {
                selector.FromAssemblyDependencies(Assembly.GetAssembly(typeof(DataContext)))
                    .AddClasses(filter =>
                    {
                        filter.AssignableTo(typeof(Hermes.Application.ICommandHandler<,>));
                    })
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
            });

            return services;
        }
    }
}
