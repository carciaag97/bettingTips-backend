using iSoft.FLEETMANAGEMENT.Backend.Core.Extensions;
using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Config;
using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Middlewares;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.SignalR;
using iSoft.FLEETMANAGEMENT.Backend.Core.Utils;
using iSoft.FLEETMANAGEMENT.Backend.Core.Utils.Cache;


var builder = WebApplication.CreateBuilder(args);

AppConfig.Init(builder.Configuration);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });



// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});



builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.AddDbContext();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureAuthorization();
builder.Services.ConfigureSwagger();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseSwagger(c =>
{
    c.RouteTemplate = "api/swagger/{documentName}/swagger.json";
});

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/api/swagger/v1/swagger.json", "FleetManagement");
    c.RoutePrefix = "api/swagger";
    c.DocumentTitle = $"FleetManagement {app.Environment.EnvironmentName} - Swagger UI";
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
