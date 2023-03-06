using Boxers;
using Boxers.Entities;
using Boxers.Middleware;
using Boxers.Services;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

//NLog config
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BoxerDbContext>();
builder.Services.AddScoped<BoxerSeeder>();
//builder.Services.AddAutoMapper(this.GetType().Assembly);

builder.Services.AddAutoMapper(typeof(BoxerMappingProfile).Assembly);
builder.Services.AddScoped<IBoxerService, BoxerService>();
builder.Services.AddScoped<IAchievementService, AchievementService>();
builder.Services.AddScoped<ErrorHandlingMiddleware>();
    

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<BoxerSeeder>();
seeder.Seed();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
