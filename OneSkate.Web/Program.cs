using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OneSkate.Web.Data;
using OneSkate.Web.Interfaces;
using OneSkate.Web.Services;
using static OneSkate.Web.Helpers.AutoMapper;

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

app.Run();
