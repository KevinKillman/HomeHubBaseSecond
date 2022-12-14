using BlazorStrap;
using DbContexts.Nfl_Db;
using DevExpress.Blazor;
using HomeHub.Areas.Identity;
using HomeHub.Pages;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Smart.Blazor;
using SnippetDb;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
string nflDefaultConnectionString = builder.Configuration["ConnectionStrings:NFLDefault"];
string identityConnectionString = builder.Configuration["ConnectionStrings:Identity"];
string snippetConnectionString = builder.Configuration["ConnectionStrings:SnippetDb"];

builder.Services.AddDbContextFactory<SnippetDbContext>(options =>
{
  options.UseSqlServer(snippetConnectionString, assembly =>
    assembly.MigrationsAssembly(typeof(SnippetDbContext).Assembly.FullName));
});

// Add services to the container.
//builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
//    options.UseSqlServer(identityConnectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<SnippetDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDevExpressBlazor(configure => configure.BootstrapVersion = BootstrapVersion.v5);
builder.Services.AddBlazorStrap();
builder.Services.AddSmart();

builder.Services.AddScoped<INFLContext, nfl_2018_dbContext>();
builder.Services.AddDbContextFactory<nfl_2018_dbContext>(opt =>
{
  opt.UseNpgsql(nflDefaultConnectionString);
});

builder.Services.AddScoped<NflProjectPageState, NflProjectPageState>();
builder.Services.AddScoped<StocksPageState, StocksPageState>();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.WebHost.UseWebRoot("wwwroot");
builder.WebHost.UseStaticWebAssets();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if ( !app.Environment.IsDevelopment() )
{
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
