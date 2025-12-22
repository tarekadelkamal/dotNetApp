using GameZone;
using GameZone.Interfaces;
using GameZone.Repository;
using GameZone.Services.Interface;
using GameZone.Services.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var DefaultConnections = builder.Configuration.GetConnectionString("DefaultConnection");
 
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



using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();

    const int maxRetries = 10;
    var delay = TimeSpan.FromSeconds(5);

    for (int retry = 1; retry <= maxRetries; retry++)
    {
        try
        {
            db.Database.Migrate();
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Retry {retry}: SQL not ready yet...");
            if (retry == maxRetries)
                throw;

            Thread.Sleep(delay);
        }
    }
}


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
