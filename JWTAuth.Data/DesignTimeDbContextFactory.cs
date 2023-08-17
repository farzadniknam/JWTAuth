using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JWTAuth.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<KabanSurveyContext>
    {
        public KabanSurveyContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../JWTAuth.Data/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<KabanSurveyContext>();
            var connectionString = configuration.GetConnectionString("SurveyConnectionString");
            builder.UseNpgsql(connectionString);
            return new KabanSurveyContext(builder.Options);
        }
    }
}
