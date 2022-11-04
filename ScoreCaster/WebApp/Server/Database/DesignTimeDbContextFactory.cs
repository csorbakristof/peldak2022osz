using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebApp.Server.Database
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ScoreCasterDbContext>
    {
        public ScoreCasterDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ScoreCasterDbContext> optionBuilder =
                new DbContextOptionsBuilder<ScoreCasterDbContext>()
                .UseSqlite(@"Filename=Questions.db");

            return new ScoreCasterDbContext(optionBuilder.Options);
        }
    }
}
