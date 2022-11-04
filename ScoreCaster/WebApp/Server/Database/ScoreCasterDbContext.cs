using Core;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Server.Database
{
    public class ScoreCasterDbContext : DbContext
    {
        public DbSet<Question> Question { get; set; }
        public ScoreCasterDbContext(DbContextOptions<ScoreCasterDbContext> options)
                : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().HasData
                (
                // Warning: seed entity needs non-zero key value, cannot start with 0!
                new Question { ID = 1, MinResponseLength = 0, Text = "Question 0 from EF" },
                new Question { ID = 2, MinResponseLength = 0, Text = "Question 1 from EF" },
                new Question { ID = 3, MinResponseLength = 0, Text = "Question 2 from EF" }
                );
            modelBuilder.Entity<Response>().HasKey(r=>r.Id);
            modelBuilder.Entity<Question>().HasMany<Response>(q => q.Responses);
            modelBuilder.Entity<Response>().HasOne<Response>(r => r.Usefulness);
        }
    }
}

