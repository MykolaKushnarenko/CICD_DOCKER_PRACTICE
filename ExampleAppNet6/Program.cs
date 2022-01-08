using ExampleAppNet6.Models;
using Microsoft.EntityFrameworkCore;

var config = new ConfigurationBuilder()
    .AddCommandLine(args)
    .AddEnvironmentVariables()
    .Build();

if ((config["INITDB"] ?? "false") == "true")
{
    System.Console.WriteLine("Preparing Database...");
    SeedData.EnsurePopulated(new ProductDbContext());
    System.Console.WriteLine("Database Preparation Complete");
}
else
{
    System.Console.WriteLine("Starting ASP.NET...");

    var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
    builder.Services.AddControllersWithViews();

    builder.Services.AddDbContext<ProductDbContext>(options =>
        options.UseMySql(MySqlEfConfigurationHelper.ConstructConnectionString(builder.Configuration),
            MySqlEfConfigurationHelper.MySqlServerVersion));

    builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
    builder.Services.AddTransient<IRepository, ProductRepository>();

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
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}