using System.Configuration;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Hermes.Infrastracture.Database;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Hermes.Application;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using Hermes.Infrastracture.Database.Dispatchers;
using Hermes.Web.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

ConfigurationManager configuration = builder.Configuration;

builder.ConfigureSerilog();

builder.ConfigureDatabase();

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();

builder.Services.ConfigureAutoMapper();

builder.Services.ConfigureHandlers();

builder.Services.AddHttpClient();

builder.Services.ConfigureSecurity(configuration);

var app = builder.Build();

app.UseFastEndpoints();
app.UseCors("CorsPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerGen();
    app.UseSwaggerUi3();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
