using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using projeto_asp_net_cor;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddIdentityCore<IdentityUser>(options => { });

builder.Services.AddScoped<IUserStore<IdentityUser>,
    UserOnlyStore<IdentityUser, IdentityDbContext>>();

builder.Services.AddAuthentication("cookies")
    .AddCookie("cookies", options => options.LoginPath = "/Home/Login");

var connectionStrings = @"Data source=RMX\\SQLEXPRESS; Initial Catalog=identityCurso;Integrated security=true;";
var migrationAssembly =typeof(Program).GetTypeInfo().Assembly.GetName().Name;

builder.Services.AddDbContext<IdentityDbContext>(opt => opt .UseSqlServer(connectionStrings, sql =>
    sql.MigrationsAssembly(migrationAssembly)));

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAuthentication();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
