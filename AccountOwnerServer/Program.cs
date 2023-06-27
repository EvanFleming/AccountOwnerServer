using AccountOwnerServer.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;

using Microsoft.EntityFrameworkCore;
using Entities;
using AccountOwnerServer.DBContext;

var builder = WebApplication.CreateBuilder(args);

//LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
// Add services to the container.

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();

builder.Services.ConfigureLoggerService();

builder.Services.ConfigureSQLiteContext(builder.Configuration);

//builder.Services.AddDbContext<DBInteractor>();

builder.Services.ConfigureRepositoryWrapper();

//add automapper
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();   

app.UseForwardedHeaders(new ForwardedHeadersOptions 
{ 
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
