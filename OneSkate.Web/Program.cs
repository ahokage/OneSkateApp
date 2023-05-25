using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OneSkate.Web.Data;
using OneSkate.Web.Interfaces;
using OneSkate.Web.Models;
using OneSkate.Web.Services;
using System;
using static OneSkate.Web.Helpers.AutoMapper;
using static System.Formats.Asn1.AsnWriter;
using static System.Reflection.Metadata.BlobBuilder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IClubService, ClubService>();
builder.Services.AddScoped<IRacerService, RacerService>();
builder.Services.AddScoped<IVenueService, VenueService>();
builder.Services.AddScoped<IRaceService, RaceService>();
builder.Services.AddScoped<IResultService, ResultService>();

//builder.Services.AddHttpClient("OneSkate.API", client => client.BaseAddress = new Uri("https://localhost:44336/"));

//builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("OneSkate.API"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}
using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
if (!dbContext.Clubs.Any())
{
    var clubs = new List<Club>
    {
        new Club { Name = "Club 1"},
        new Club { Name = "Club 2"},
        new Club { Name = "Club 3"}
    };
    dbContext.Clubs.AddRange(clubs);
    dbContext.SaveChanges();
}
if (!dbContext.Racers.Any())
{
    var racers = new List<Racer>
    {
        new Racer{Name = "Racer 1",Age=20},
        new Racer{Name = "Racer 2",Age=21},
        new Racer{Name = "Racer 3",Age=22},
        new Racer{Name = "Racer 4",Age=23},
        new Racer{Name = "Racer 5",Age=24},
        new Racer{Name = "Racer 6",Age=25},
        new Racer{Name = "Racer 7",Age=26},
        new Racer{Name = "Racer 8",Age=27},
        new Racer{Name = "Racer 9",Age=28},
        new Racer{Name = "Racer 10",Age=29},
        new Racer{Name = "Racer 11",Age=30},
        new Racer{Name = "Racer 12",Age=31},
        new Racer{Name = "Racer 13",Age=32},
        new Racer{Name = "Racer 14",Age=33},
        new Racer{Name = "Racer 15",Age=34}
    };
    dbContext.Racers.AddRange(racers);
    dbContext.SaveChanges();
}
if (!dbContext.Venues.Any())
{
    var venues = new List<Venue>
    {
        new Venue{Name="Venue 1",Notes="Slope"},
        new Venue{Name="Venue 2",Notes="Slope"},
        new Venue{Name="Venue 3",Notes="Slope"}
    };
    dbContext.Venues.AddRange(venues);
    dbContext.SaveChanges();
}
app.Run();
