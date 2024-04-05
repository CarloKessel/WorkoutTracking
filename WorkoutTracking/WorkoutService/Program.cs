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
    options.AddPolicy("AllowFrontend", bld =>
    {
        bld.WithOrigins(builder.Configuration.GetSection("Frontend")["FrontendUrl"]!) // Adjust this to your frontend URL
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

Console.WriteLine(builder.Configuration.GetSection("Frontend")["FrontendUrl"]);

builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>();

var app = builder.Build();
app.UseCors("AllowFrontend");

app.UseFastEndpoints()
   .UseSwaggerGen();
app.Run();