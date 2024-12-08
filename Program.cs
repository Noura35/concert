using concerts.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Register controllers with views (MVC pattern).
builder.Services.AddControllersWithViews();

// Register the DbContext for SQLite with the connection string from appsettings.json.
builder.Services.AddDbContext<FestivalContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("FestivalDb")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // Use HSTS in non-development environments for better security.
    app.UseHsts();
}

// Redirect HTTP to HTTPS.
app.UseHttpsRedirection();

// Serve static files (e.g., CSS, JS, images).
app.UseStaticFiles();

// Enable routing for the application.
app.UseRouting();

// Enable authorization (if applicable).
app.UseAuthorization();

// Map default controller routes (e.g., Home/Index).
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Run the application.
app.Run();