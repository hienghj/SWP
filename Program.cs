using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SWP_Project.Areas.Identity.Data; // Make sure to include the namespaces for your Identity models.
using SWP_Project.Data; // Namespace for your DbContext.
using SWP_Project.Repositories; // Namespace for your repository classes.

var builder = WebApplication.CreateBuilder(args);

// Add MVC services
builder.Services.AddControllersWithViews();

// Get connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DBContextConnection")
    ?? throw new InvalidOperationException("Connection string 'DBContextConnection' not found.");

// Configure DbContext with the connection string
builder.Services.AddDbContext<DBContext>(options =>
    options.UseSqlServer(connectionString));

// Configure Identity
builder.Services.AddDefaultIdentity<User>(options =>
{
    // Authentication options
    options.SignIn.RequireConfirmedAccount = false; // Set to true to require account confirmation via email.
    options.SignIn.RequireConfirmedEmail = false; // Set to true to require email confirmation.

    // Password options
    options.Password.RequireDigit = true; // Require at least one digit.
    options.Password.RequireLowercase = true; // Require at least one lowercase letter.
    options.Password.RequireNonAlphanumeric = true; // Require at least one non-alphanumeric character.
    options.Password.RequireUppercase = true; // Require at least one uppercase letter.
    options.Password.RequiredLength = 6; // Minimum password length is 6 characters.

    // Lockout options
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Lockout time is 5 minutes.
    options.Lockout.MaxFailedAccessAttempts = 5; // Maximum failed login attempts before lockout.
    options.Lockout.AllowedForNewUsers = true; // Allow lockout for new users.
})
.AddEntityFrameworkStores<DBContext>(); // Use the DbContext for Identity

var app = builder.Build();

// Configure middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Use error handling page for production
    app.UseHsts(); // Enable HSTS for better security
}

app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS
app.UseStaticFiles(); // Serve static files (CSS, JS, images, etc.)

app.UseRouting(); // Enable routing middleware

app.UseAuthentication(); // Enable authentication middleware
app.UseAuthorization(); // Enable authorization middleware

// Configure routing for controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Default route configuration

app.MapRazorPages(); // Enable Razor Pages routing

app.Run(); // Start the application
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "admin",
        pattern: "{controller=Admin}/{action=Index}/{id?}");
});
