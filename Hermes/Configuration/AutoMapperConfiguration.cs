using System.Reflection;
using Hermes.Application.Mappings;

namespace Hermes.Web.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        { 
            services.AddAutoMapper(Assembly.GetAssembly(typeof(MailRequestsMappings)));

            return services;
        }
    }
}
