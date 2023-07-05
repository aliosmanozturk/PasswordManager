using Autofac;
using Microsoft.AspNetCore.Authentication.Cookies;
using PasswordManager.Database.DependencyResolvers.Autofac;
using PasswordManager.Database.Repository.CategoryRepository;
using PasswordManager.Database.Repository.PasswordsRepository;
using PasswordManager.Database.Repository.UserRepository;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterType<EfUserDal>().As<IUserDal>();
    builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
    builder.RegisterType<EfPasswordsDal>().As<IPasswordsDal>();
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddAuthentication()
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Unauthorized/";
        options.AccessDeniedPath = "/Account/Forbidden/";
    });
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
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
