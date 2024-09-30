using AudioInsight.DataContext;
using AudioInsight.DataContext.Repositories;
using AudioInsight.Infrastructure.Repositories;
using AudioInsight.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using AudioInsight.Application;
using System.Reflection;

namespace AudioInsight.API.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("AudioInsight.Application")));
        services.AddAutoMapper(Assembly.Load("AudioInsight.Application"));

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICallRepository, CallRepository>();

        services.AddSingleton<Dispatcher>();
    }

    public static void AddDbContext(this IServiceCollection services)
    {
        services.AddScoped<MongoDbContext>();
        services.AddSingleton(sp =>
        {
            var options = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
            return options;
        });
    }

    public static void AddApplicationSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoDbSettings>(configuration.GetSection(nameof(MongoDbSettings)));
        services.Configure<QueueConnectionSettings>(configuration.GetSection(nameof(QueueConnectionSettings)));
    }
}
