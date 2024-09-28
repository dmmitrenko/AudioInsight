using AudioInsight.Application.Categories;
using AudioInsight.Application.Categories.Handlers;
using AudioInsight.DataContext;
using AudioInsight.DataContext.Repositories;
using AudioInsight.Infrastructure.Repositories;
using AudioInsight.Infrastructure.Settings;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCategoryCommandHandler).Assembly));
builder.Services.AddAutoMapper(typeof(CategoryProfile));

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection(nameof(MongoDbSettings)));

builder.Services.AddSingleton(sp =>
{
    var options = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    return options;
});

builder.Services.AddScoped<MongoDbContext>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
