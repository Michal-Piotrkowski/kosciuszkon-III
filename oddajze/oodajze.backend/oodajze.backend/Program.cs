

using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using oodajze.backend.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=appdatabase.db"));
builder.Services.AddTransient<MockSeeder>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDevClient",
        builder => builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());
});
builder.Services.AddAuthorization();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<MockSeeder>();
    await seeder.SeedAsync();
}

app.Use(async (context, next) =>
{
    var claims = new[]
    {
        new Claim(ClaimTypes.NameIdentifier, "1"),
        new Claim(ClaimTypes.Email, "mockuser@example.com"),
        new Claim(ClaimTypes.Name, "Mock User"),
    };
    var identity = new ClaimsIdentity(claims, "mock");
    context.User = new ClaimsPrincipal(identity);

    await next();
});
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngularDevClient");

app.UseHttpsRedirection();



app.UseRouting();
app.MapRazorPages();
app.UseAuthorization();
app.MapControllers();
app.Run();

