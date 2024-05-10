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
    options.AddPolicy("AllowAPIGateway", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod();
        policy.WithOrigins(builder.Configuration.GetSection("APIGateway")["APIGatewayUrl"]!);
    });
});

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseCors("AllowAPIGateway")
    .UseFastEndpoints(c =>
    {
        c.Endpoints.RoutePrefix = "write-api";
    })
    .UseSwaggerGen();

app.Run();