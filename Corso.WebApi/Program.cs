using Corso.WebApi.Extensions;
using MiddlewareExceptionHandler.ExceptionHandling;
using Serilog;
using AutoMapperService = Corso.Service.Helpers.InjectableHelpers.AutoMapperHelper;
using AutoMapperWebApi = Corso.WebApi.Helpers.InjectableHelpers.AutoMapperHelper;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddAutoMapper(typeof(AutoMapperService));
builder.Services.AddAutoMapper(typeof(AutoMapperWebApi));
builder.Services.AddApplicationServices(configuration);
builder.Services.AddCustomService();
builder.Services.AddIdentityServices(configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerDocumentation();

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    await ApplicationServiceExtensions.InitializeDataAsync(app);
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers()
        .RequireAuthorization("TokenRequired");

app.Run();
