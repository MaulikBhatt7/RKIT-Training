using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure logging providers
builder.Logging.ClearProviders(); // Optional: Clears default providers
builder.Logging.AddConsole(); // Adds Console provider
builder.Logging.AddDebug(); // Adds Debug provider

// Configure Logging into console and file using Serilog.
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    //.WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Host.UseSerilog();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add a sample endpoint
app.MapGet("/hello", (ILogger<Program> logger) =>
{
    logger.LogInformation("Processing /hello endpoint");
    logger.LogDebug("Detailed debug information for /hello");
    return Results.Ok("Hello, Logging!");
});

app.UseAuthorization();

app.MapControllers();

app.Run();
