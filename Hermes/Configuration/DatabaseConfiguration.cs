using Hermes.Application;
using Hermes.Application.Services;
using Hermes.Infrastracture.Database;
using Hermes.Infrastracture.Database.Dispatchers;
using Hermes.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Hermes.Web.Configuration
{
    public static class DatabaseConfiguration
    {
        public static WebApplicationBuilder ConfigureDatabase(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<DataContext>(x =>
                x.UseLazyLoadingProxies()
                    .UseSqlServer(builder.Configuration.GetConnectionString("HermesConnection")));
            builder.Services.AddTransient<IMailService, MailService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            builder.Services.AddScoped<IQueryDispatcher, QueryDispatcher>();

            return builder;
        }
    }
}
