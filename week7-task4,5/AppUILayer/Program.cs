using DataAccessLayer.DbContext;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();

// Register DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repository
builder.Services.AddScoped<IContactRepository, ContactRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

// Root URL redirect (automatic opening)
app.MapGet("/", context =>
{
    context.Response.Redirect("/Contact/ShowContacts");
    return Task.CompletedTask;
});

// Attribute routing
app.MapControllers();

app.Run();