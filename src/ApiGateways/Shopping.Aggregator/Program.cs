using Shopping.Aggregator.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<IDataSatelliteService, DataSatelliteService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:DataSatelliteUrl"]));

builder.Services.AddHttpClient<ISatelliteOrchestratorService, SatelliteOrchestratorService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:SatelliteOrchestratorUrl"]));

builder.Services.AddHttpClient<ISatelliteOrchestratorControllerService, SatelliteOrchestratorControllerService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:SatelliteOrchestratorControlleringUrl"]));
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
