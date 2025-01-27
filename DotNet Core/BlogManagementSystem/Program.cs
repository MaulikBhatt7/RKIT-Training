using BlogManagementSystem.BL;
using BlogManagementSystem.Middleware;
using BlogManagementSystem.Models;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddControllers(options =>
{
    // Add LogActionFilter globally to all actions
    options.Filters.Add<BlogManagementSystem.Filters.LogActionFilter>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure ORM Lite
builder.Services.AddSingleton<IDbConnectionFactory>(new OrmLiteConnectionFactory(
    builder.Configuration.GetConnectionString("BlogDB"), MySqlDialect.Provider));


// Configure Logging
builder.Services.AddLogging(config =>
{
    config.AddConsole();  // Console Logging
    config.AddDebug();    // Debug Logging
});




// Configure Response Model

builder.Services.AddTransient<Response>();

// Configure BLConverter

builder.Services.AddTransient<BLConverter>();


// Configure BLBlog
builder.Services.AddTransient<BLBlog>();



var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
