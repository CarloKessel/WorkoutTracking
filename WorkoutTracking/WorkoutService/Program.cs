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
    options.AddPolicy("AllowFrontend", 
        policy =>
        {
            policy.AllowAnyHeader().AllowAnyMethod();
            policy.AllowAnyOrigin();
            //policy.WithOrigins(builder.Configuration.GetSection("Frontend")["FrontendUrl"]!);
        });
});

Console.WriteLine(builder.Configuration.GetSection("Frontend")["FrontendUrl"]);

builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>();

var app = builder.Build();
app.UseCors("AllowFrontend");

app.UseFastEndpoints()
   .UseSwaggerGen();
app.Run();