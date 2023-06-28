using AccountOwnerServer.Extensions;
using AccountOwnerServer.GlobalErrorHandling.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;



/*
 *
 * Code-Maze tutorial
 * https://code-maze.com/net-core-web-development-part1/
 * 
 * https://code-maze.com/global-error-handling-aspnetcore/
 *
 */

var builder = WebApplication.CreateBuilder(args);

LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Add services to the container.

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();

builder.Services.ConfigureLoggerService();

builder.Services.ConfigureSQLiteContext(builder.Configuration);

///TODO: need to figure out a better way to build database from objects
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

//global error handling
app.ConfigureCustomExceptionMiddleware();
//end global error handling


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
