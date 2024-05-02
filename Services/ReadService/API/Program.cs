using Infrastructure.Extensions;
using FastEndpoints;
using FastEndpoints.Swagger;
using Application.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddFastEndpoints()
    .AddApplication()
    .AddInfrastructure(builder.Configuration, builder.Environment.IsDevelopment())
    .SwaggerDocument();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod();
        policy.WithOrigins(builder.Configuration.GetSection("Frontend")["FrontendUrl"]!);
    });
});

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseCors("AllowFrontend")
    .UseFastEndpoints()
    .UseSwaggerGen();

app.Run();