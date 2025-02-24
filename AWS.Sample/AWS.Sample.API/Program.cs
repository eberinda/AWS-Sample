using AWS.Sample.API.Infrastructure;
using AWS.Sample.Application;
using AWS.Sample.Infrastructure;
using AWS.Sample.Infrastructure.Persistence;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddSerilogLogging(builder.Configuration);

builder.Host.UseSerilog();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseSerilogRequestLogging();

app.MapControllers();

if(args.Length > 0 && args[0] == "migrate")
{
    using var scope = app.Services.CreateScope();
    var migrator = scope.ServiceProvider.GetRequiredService<DatabaseMigrator>();
    
    migrator.Migrate();
}
else
{
    app.Run();
}
