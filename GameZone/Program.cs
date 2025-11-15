using GameZone;
using GameZone.Interfaces;
using GameZone.Repository;
using GameZone.Services.Interface;
using GameZone.Services.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var DefaultConnections = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.WebHost.UseUrls("http://0.0.0.0:80");
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(DefaultConnections));
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICategories, CategoriesRep>();
builder.Services.AddScoped<IDevices, DevicesRep>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IDevicesService, DevicesService>();
builder.Services.AddScoped<IGamesService, GameService>();
builder.Services.AddScoped<IGame, GamesRepo>();
builder.Services.AddScoped<IUploadFile, UploadFileService>();

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
