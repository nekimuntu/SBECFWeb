using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SuperBowlWeb.Data;
using AutoMapper;
using SuperBowlWeb.Models;
using SuperBowlWeb.Controllers;
using Microsoft.AspNetCore.Identity;
using SuperBowlWeb.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersWithViews();
builder.Services.AddIdentityServices(builder.Configuration);
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<SuperBowlWebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SuperBowlWebContext") ?? throw new InvalidOperationException("Connection string 'SuperBowlWebContext' not found.")));
//Je rajoute ca pour faire une API
builder.Services.AddEndpointsApiExplorer();
//Swagger pour un compte rendu des API 
//builder.Services.AddSwa();
builder.Services.AddControllers(opt => {
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));
}
);
//configuration de CORS 
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CORSpolicySBB", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
    });
});

builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors("CORSpolicySBB");
app.UseHttpsRedirection();

//TODO: une fois identity configurer UseDEefaultFiles et UseStaticFiles sont a deplacer en dessous de UseAuthorization et UseAuthentication
//UseDefaultFiles va chercher dans le dossier wwwroot s il y a un fichier appele index !!!
app.UseDefaultFiles();
//UseStaticFiles va servir les fichier static dans wwwroot 
app.UseStaticFiles();
app.MapRazorPages();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var userManager = services.GetRequiredService<UserManager<Utilisateur>>();
    var context = services.GetRequiredService<SuperBowlWebContext>();
    await context.Database.MigrateAsync();
    await Seed.SeedData(context, userManager);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "Problem occured while trying to acces the Database");
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
