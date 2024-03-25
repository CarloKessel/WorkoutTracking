using FastEndpoints;
using FastEndpoints.Swagger;

var bld = WebApplication.CreateBuilder(args);
bld.Services
   .AddFastEndpoints()
   .SwaggerDocument();

bld.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", builder =>
    {
        builder.WithOrigins("http://localhost:8080") // Adjust this to your frontend URL
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = bld.Build();
app.UseCors("AllowFrontend");

app.UseFastEndpoints()
   .UseSwaggerGen();
app.Run();