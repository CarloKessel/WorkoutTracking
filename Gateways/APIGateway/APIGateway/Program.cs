using APIGateway.Auth;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().AllowCredentials();
        policy.WithOrigins(builder.Configuration.GetSection("Frontend")["FrontendUrl"]!);
    });
});

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireReadWorkoutPermissions", policy =>
    {
        policy.Requirements.Add(new PermissionRequirement("read:workouts"));
    });

    options.AddPolicy("RequireWriteWorkoutPermissions", policy =>
    {
        policy.Requirements.Add(new PermissionRequirement("write:workouts"));
    });
});

builder.Services.AddSingleton<IAuthorizationHandler, PermissionHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapReverseProxy();
app.Run();