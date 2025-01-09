using Blazor.Server.Components;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
builder.Host.UseSerilog((context, options) =>
    options.ReadFrom.Configuration(context.Configuration));

// Add services to the DI container
var services = builder.Services;

// Blazor and Razor components
services.AddControllers();
services.AddRazorPages();
services.AddRazorComponents()
    .AddInteractiveServerComponents();
services.AddServerSideBlazor();

services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromMinutes(720); // Cookie expiration time
    options.SlidingExpiration = true; // Reset expiration on user activity
});
services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(720); // Set session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.None; // Use HTTPS
    options.Cookie.IsEssential = true;
    options.Cookie.MaxAge = TimeSpan.FromMinutes(720); // Persist thse cookie
});
services.AddAntiforgery(options =>
{
    options.HeaderName = "XSRF-TOKEN";
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.None;
    options.Cookie.MaxAge = TimeSpan.FromMinutes(720); // Persist the cookie
});

// Register IHttpContextAccessor
services.AddHttpClient();
services.AddHttpContextAccessor();

// Build the app
var app = builder.Build();

// Middleware configuration
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error", true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseSession();
app.UseRouting();
app.UseAntiforgery();

app.MapControllers();
app.MapStaticAssets();
app.MapRazorPages();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
await app.RunAsync();