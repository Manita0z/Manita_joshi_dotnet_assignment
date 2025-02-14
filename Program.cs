using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using manita_dotnet_assignment.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add database context with connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Identity with roles support
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add MVC controllers and views
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(options =>
{
    // Applying authorization for all Razor Pages in the "Admin" folder
    options.Conventions.AuthorizeFolder("/Admin");
});

// Add health check services (optional but useful)
builder.Services.AddHealthChecks();

var app = builder.Build();

// Apply migrations and seed data on startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();  // Apply migrations
    SeedData.Initialize(services, context);  // Seed database
}

// Global exception handling for non-development environments
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();  // Ensure HSTS is used for security in production
}

app.UseHttpsRedirection();  // Force HTTPS in production
app.UseStaticFiles();  // Serve static files such as images, CSS, JS

app.UseRouting();  // Enable routing for controllers and Razor Pages
app.UseAuthentication();  // Enable authentication
app.UseAuthorization();  // Enable authorization

// Define default controller route (Ensure OrdersController has OrdersView action)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Orders}/{action=OrdersView}/{id?}");

// Map Razor Pages for Identity pages
app.MapRazorPages();

app.Run();  // Start the application
