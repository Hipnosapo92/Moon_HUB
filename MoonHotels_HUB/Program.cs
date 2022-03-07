using MoonHotels_HUB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

Startup startup = new Startup(builder.Configuration);
startup.Configure(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
