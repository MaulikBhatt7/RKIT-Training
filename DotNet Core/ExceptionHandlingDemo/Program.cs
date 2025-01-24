using ExceptionHandlingDemo.Middleware;
using ExceptionHandlingDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Register the exception service
builder.Services.AddSingleton<IExceptionService, ExceptionService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Add the custom exception middleware
app.UseMiddleware<CustomExceptionMiddleware>(); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.MapGet("/", (context) => throw new Exception("Test exception"));


app.UseAuthorization();

app.MapControllers();

app.Run();
