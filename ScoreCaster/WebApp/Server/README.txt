https://www.c-sharpcorner.com/article/entity-framework-core-in-docker-container-part-ii-sqlite/

Install nuget EntityFrameworkCore
Create ScoreCasterDbContext
Add connection string to appsettings.json
Create QuestionController to list the questions from DB.
Create DesignTimeDbContextFactory
Install nuget EntityFrameworkCore.Sqlite

For the command in the "package manager console" window
"Add-Migration InitialCreate -Project WebApp.Server"
install nuget "Microsoft.EntityFrameworkCore.Tools"

PM> update-database –verbose

