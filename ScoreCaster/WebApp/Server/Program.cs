using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using WebApp.Server.Database;
using WebApp.Server.Services;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<ScoreCasterDbContext>(
                options => options.UseSqlite(@"Filename=Questions.db"));

            builder.Services.AddSingleton<NeptunCodeValidator>();
            builder.Services.AddSingleton<IIdentityManager, NeptunBasedIdentityManager>();  // Defines implementation of interface
            // Note: services using the scoped DbContext should not be singletons...
            builder.Services.AddScoped<GeneralServices>();
            builder.Services.AddScoped<ReviewerServices>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
            app.UseRouting();

            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}