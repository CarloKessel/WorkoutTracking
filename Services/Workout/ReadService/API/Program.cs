using Application.Extensions;
using FastEndpoints;
using FastEndpoints.Swagger;
using API.AuthMiddelware;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddInfrastructure(builder.Configuration, builder.Environment.IsDevelopment())
    .AddApplication()
    .AddFastEndpoints()
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

app.UseCors("AllowAPIGateway");
app.UseAuthentication();
app.UseAuthorization();
app.UseApiGatewayMiddleware();
app.UseFastEndpoints(c =>
{
    c.Endpoints.RoutePrefix = "read-api";
});
app.UseSwaggerGen();

app.Run();