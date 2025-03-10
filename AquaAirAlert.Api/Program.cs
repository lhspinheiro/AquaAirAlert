using AquaAirAlert.Api.FIlters;
using AquaAirAlert.Application.UseCase.Delete;
using AquaAirAlert.Application.UseCase.InterfacesRefit;
using AquaAirAlert.Application.UseCase.WeatherRefit;
using AquaAirAlert.Communication.KeyModel;
using AquaAirAlert.Infrastructure;
using AquaAirAlert.Infrastructure.Data;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<IWeatherIntegration, WeatherIntegration>();

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFIlter)));

builder.Services.AddRefitClient<IWeatherIntegrationRefit>().ConfigureHttpClient(client =>
{
    client.BaseAddress = new Uri("https://api.openweathermap.org");
});

builder.Services.Configure<ApiKey>(builder.Configuration.GetSection("ApiKey"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();