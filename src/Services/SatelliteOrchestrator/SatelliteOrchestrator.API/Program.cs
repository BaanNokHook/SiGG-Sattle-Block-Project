using SatelliteOrchestrator.API.Repositories;
using MassTransit;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetValue<string>("CacheSettings:ConnectionString");
});

builder.Services.AddScoped<ISatelliteOrchestratorRepository, SatelliteOrchestratorRepository>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMassTransit(config =>
        {
            config.UsingRabbitMq((ctx, cfg) => {
                cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
            });
        });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
