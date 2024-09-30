using AudioInsight.Application.Categories.Handlers;
using AudioInsight.Application.Categories;
using AudioInsight.Infrastructure.Repositories;
using AudioInsight.DataContext.Repositories;
using AudioInsight.DataContext;
using AudioInsight.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using AudioInsight.Application;
using AudioInsight.Infrastructure.Queue;
using AudioInsight.Application.Consumers;

namespace AudioInsight.Worker.Extensions;

public static class ServiceExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<ICallRepository, CallRepository>();

        services.AddTransient<Dispatcher>();
    }

    public static void AddMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCategoryCommandHandler).Assembly));
        services.AddAutoMapper(typeof(CategoriesProfile));
    }

    public static void AddDbContext(this IServiceCollection services)
    {
        services.AddSingleton(sp =>
        {
            var options = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
            return options;
        });

        services.AddTransient<MongoDbContext>();
    }

    public static void AddAppSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoDbSettings>(configuration.GetSection(nameof(MongoDbSettings)));
        services.Configure<QueueConnectionSettings>(configuration.GetSection(nameof(QueueConnectionSettings)));
    }

    public static void AddQueueServices(this IServiceCollection services)
    {
        services.AddTransient<IMessageConsumerFactory, MessageConsumerFactory>();
        services.AddTransient<IMessageConsumer, AudioAnalysisCompletedConsumer>();
    }
}
