using FastEndpoints;
using FastEndpoints.Swagger;
using WorkoutService.DAL;
using WorkoutService.Extensions;
using WorkoutService.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services
   .AddFastEndpoints()
   .AddMartenConfiguration(builder.Configuration, builder.Environment.IsDevelopment())
   .SwaggerDocument();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", builder =>
    {
        builder.WithOrigins("http://localhost:8080") // Adjust this to your frontend URL
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>();


var app = builder.Build();
app.UseCors("AllowFrontend");

app.UseFastEndpoints()
   .UseSwaggerGen();
app.Run();