using AudioInsight.Worker;
using AudioInsight.Worker.Extensions;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<Worker>();
builder.Services.AddServices();

builder.Services.AddMediatR();
builder.Services.AddDbContext();

builder.Services.AddAppSettings(builder.Configuration);
builder.Services.AddQueueServices();

var host = builder.Build();
host.Run();
