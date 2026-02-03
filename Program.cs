using BlazingPizza;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllers(); // API endpoints
builder.Services.AddScoped<OrderState>();

// Blazor Server HttpClient (relative paths)
builder.Services.AddHttpClient(); 

// SQLite DB
builder.Services.AddSqlite<PizzaStoreContext>("Data Source=pizza.db");

var app = builder.Build();

// Error handling
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

// Static files & routing
app.UseStaticFiles();
app.UseRouting();

// Map pages, Blazor hub, controllers, fallback
app.MapRazorPages();
app.MapBlazorHub();
app.MapControllers();
app.MapFallbackToPage("/_Host");

// Seed database (always runs SeedData, even if DB exists)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PizzaStoreContext>();
    db.Database.EnsureCreated();  // Make sure DB exists
    SeedData.Initialize(db);      // Seed if empty
}

app.Run();