using MediatR.NotificationPublishers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StravaClone.DataService.Data;
using StravaClone.DataService.Interfaces;
using StravaClone.Entities.Models;
using StravaClone.Entities.Options;
using StravaClone.Web.Profiles;
using StravaClone.DataService.Repository;
using StravaClone.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.RegisterMapsterConfiguration();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPhotoService, PhotoService>();
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection(CloudinarySettings.SectionName)); // allows me to have IOptions
builder.Services.Configure<IPInfoSettings>(builder.Configuration.GetSection(IPInfoSettings.SectionName)); // allows me to have IOptions>

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();




builder.Services.AddHttpClient<IIPInfoService, IPInfoService>();

builder.Services.AddOutputCache(options =>
{
    options.AddBasePolicy(builder =>
        builder.Expire(TimeSpan.FromSeconds(60)));
    options.AddPolicy("Expire20", builder =>
        builder.Expire(TimeSpan.FromSeconds(20)));
});


builder.Services.AddMediatR(config =>
    {
        config.RegisterServicesFromAssembly(typeof(Program).Assembly);
        config.NotificationPublisher = new TaskWhenAllPublisher();
    });

var app = builder.Build();

//if (args.Length == 1 && args[0].ToLower() == "seeddata")
//{
    Seed.SeedData(app);
    await Seed.SeedUsersAndRolesAsync(app);
//}

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
