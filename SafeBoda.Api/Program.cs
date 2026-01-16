using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SafeBoda.Application;       // ITripRepository
using SafeBoda.Infrastructure;    // EfTripRepository, SafeBodaDbContext

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SafeBoda API", Version = "v1" });
});

// Memory cache
builder.Services.AddMemoryCache();

// EF Core InMemory
builder.Services.AddDbContext<SafeBodaDbContext>(options =>
    options.UseInMemoryDatabase("SafeBodaDb"));

// Repository
builder.Services.AddScoped<ITripRepository, EfTripRepository>();

var app = builder.Build();

// Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SafeBoda API v1");
    });
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
