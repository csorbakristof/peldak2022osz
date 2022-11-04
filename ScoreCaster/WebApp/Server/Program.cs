using Core;
using Core.Services;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WebApp.Server.Database;

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
            public ScoreCasterDbContext ScoreCasterDbContext;
            public ServerSidePersistence()
            {
                this.IdentityManager = new NeptunBasedIdentityManager(new NeptunCodeValidator());
                this.GeneralServices = new(this.IdentityManager);
                this.ReviewerServices = new(this.Questions, this.IdentityManager);

                //DbContextOptionsBuilder<ScoreCasterDbContext> optionBuilder =
                //    new DbContextOptionsBuilder<ScoreCasterDbContext>().UseSqlite(@"Filename=Questions.db");

                //this.ScoreCasterDbContext = new ScoreCasterDbContext(optionBuilder.Options);

                // Add a default question to test with...
                //this.Questions.Add(new Question() { ID=0, MinResponseLength=0, Text="Question 1 text" });
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

            builder.Services.AddDbContext<ScoreCasterDbContext>(
                options => options.UseSqlite(@"Filename=Questions.db"));

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