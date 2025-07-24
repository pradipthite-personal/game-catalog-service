using GameCatalogService.Domain.Interfaces;
using GameCatalogService.Infra.Data;
using GameCatalogService.Infra;
using Microsoft.EntityFrameworkCore;
using GameCatalogService.API.Middleware;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.ApiKey,
        Name = "x-api-key",
        In = ParameterLocation.Header,
        Description = "Enter the API key to access this API",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                },
                In = ParameterLocation.Header,
            },
            new string[] {}
        }
    });
});

// Add DbContext
var connectionString = builder.Configuration.GetConnectionString("GameHubDb");
builder.Services.AddDbContext<GameHubDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add Repository Dependencies
builder.Services.AddScoped<IGameRepository, GameRepository>();

var app = builder.Build();

// Enable API Key Middleware
//app.UseMiddleware<ApiKeyMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
