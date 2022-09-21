using BudgetLite.Data;
using BudgetLite.Data.Models;
using BudgetLite.Services;
using BudgetLite.Services.Interfaces;
using BudgetLite.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();

// Services
builder.Services.AddTransient<IUserService, UserService>();

// Entity Framework & Identity
builder.Services.AddDbContextFactory<BudgetLteContext>(opt =>
    opt.UseSqlite($"Data Source={nameof(BudgetLteContext.BudgetLteContextDb)}.db"));
builder.Services.AddDefaultIdentity<User>()
    .AddRoles<IdentityRole<int>>()
    .AddEntityFrameworkStores<BudgetLteContext>();

builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

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