using Core;
using Core.Services;
using Microsoft.AspNetCore.ResponseCompression;

namespace WebApp
{
    public class Program
    {
        public class ServerSidePersistence
        {
            public List<Question> Questions = new();
            public IIdentityManager IdentityManager;
            public GeneralServices GeneralServices;
            public ReviewerServices ReviewerServices;
            public ServerSidePersistence()
            {
                this.IdentityManager = new NeptunBasedIdentityManager(new NeptunCodeValidator());
                this.GeneralServices = new(this.IdentityManager);
                this.ReviewerServices = new(this.Questions, this.IdentityManager);
            }
        }
        // Temprarily, store all data in server side memory in a static context.
        public static ServerSidePersistence ServerSideDataAndServices = new();

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

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