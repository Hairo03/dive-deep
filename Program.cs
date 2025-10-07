using dive_deep.Data;
using dive_deep.Models;
using dive_deep.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
using dive_deep.Services;

namespace dive_deep
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient("OpenMeteoMarine", (httpClient) =>
            {
                httpClient.BaseAddress = new Uri("https://marine-api.open-meteo.com/v1/");
            });
            builder.Services.AddHttpClient("OpenMeteoGeo", (httpClient) =>
            {
                httpClient.BaseAddress = new Uri("https://geocoding-api.open-meteo.com/v1/");
            });
            builder.Services.AddHttpClient("OpenMeteoWeather", (httpClient) =>
            {
                httpClient.BaseAddress = new Uri("https://api.open-meteo.com/v1/");
            });

            builder.Services.AddDbContext<DiveDeepContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); });

            builder.Services.AddScoped<IProductRepository, ProductRepo>();
            builder.Services.AddScoped<IRepository<Package>, PackageRepo>();
            builder.Services.AddDefaultIdentity<ApplicationUser>().AddEntityFrameworkStores<DiveDeepContext>();
            builder.Services.AddScoped<IRepository<CartBooking>, CartBookingRepo>();
            builder.Services.AddSingleton<IBookingItemRepository, InMemoryBookingItemRepo>();
            builder.Services.AddScoped<IWeatherService, WeatherService>();

            var defaultCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentCulture = defaultCulture;
            CultureInfo.DefaultThreadCurrentUICulture = defaultCulture;

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                try
                {
                    var db = scope.ServiceProvider.GetRequiredService<DiveDeepContext>();

                    // Optional: log pending migrations (helpful for debugging)
                    var pending = db.Database.GetPendingMigrations().ToList();
                    if (pending.Any())
                    {
                        logger.LogInformation("Applying {Count} pending migrations: {Migs}", pending.Count, string.Join(", ", pending));
                    }
                    else
                    {
                        logger.LogInformation("No pending migrations.");
                    }

                    // Apply any pending migrations and create DB if missing
                    db.Database.MigrateAsync();
                    logger.LogInformation("Database migrated/created successfully.");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Database migration failed on startup.");
                    // Decide: rethrow to stop the app, or continue and surface a friendly error page.
                    throw;
                }
            }

            app.MapRazorPages();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

    }
}
