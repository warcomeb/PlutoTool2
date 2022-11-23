using Microsoft.EntityFrameworkCore;
using PlutoTool.Database;

var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddRazorPages();
builder.Services.AddDbContext<PlutoDbContext>(
    opt => opt.UseSqlite("Data source=PlutoToolDB.db"));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
//builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
