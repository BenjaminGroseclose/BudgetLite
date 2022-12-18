using BudgetLite.Data;
using BudgetLite.Data.Models;
using BudgetLite.Data.Repositories;
using BudgetLite.Web.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices(options =>
{
    options.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
    options.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;
    options.SnackbarConfiguration.PreventDuplicates = false;
    options.SnackbarConfiguration.NewestOnTop = false;
    options.SnackbarConfiguration.ShowCloseIcon = true;
    options.SnackbarConfiguration.VisibleStateDuration = 10000;
    options.SnackbarConfiguration.HideTransitionDuration = 500;
    options.SnackbarConfiguration.ShowTransitionDuration = 500;
});

// Services

// Repositories
builder.Services.AddTransient<IRepository<Budget>, BudgetRepository>();
builder.Services.AddTransient<IRepository<BudgetPeriod>, BudgetPeriodRepository>();
builder.Services.AddTransient<IRepository<Transaction>, TransactionRepository>();


// Entity Framework & Identity
builder.Services.AddAuthenticationCore();
builder.Services.AddDbContextFactory<BudgetLiteContext>(opt =>
    opt.UseSqlite($"Data Source={nameof(BudgetLiteContext.BudgetLiteContextDb)}.db"));
builder.Services.AddDefaultIdentity<User>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 7;
})
    .AddRoles<IdentityRole<int>>()
    .AddEntityFrameworkStores<BudgetLiteContext>();

builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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