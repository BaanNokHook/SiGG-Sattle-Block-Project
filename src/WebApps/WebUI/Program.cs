using WebUI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddHttpClient<IDataSatelliteService, DataSatelliteService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]));
builder.Services.AddHttpClient<ISatelliteOrchestratorService, SatelliteOrchestratorService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]));
builder.Services.AddHttpClient<ISatelliteOrchestratorControllerService, SatelliteOrchestratorControllerService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});


app.Run();


