using JWTAuth.Common.Helper;
using JWTAuth.Data.Repositories.GeneralRepositories;
using JWTAuth.Extensions;
using JWTAuth.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RepoDb;

namespace JWTAuth.Helpers
{
    public class ConfigHelper
    {
        public static void ConfigureService(WebApplicationBuilder builder)
        {
            var serviceProvider = builder.Services.AddOptions().Configure<AppSettings>(builder.Configuration.GetSection("AppSettings")).BuildServiceProvider();

            // Set the value in AppSettings
            var appSettings = serviceProvider.GetRequiredService<IOptions<AppSettings>>().Value;

            // Add your DbContext and other services here
            builder.Services.AddDbContext<AuthorizeContexts>(options =>
                            options.UseNpgsql(appSettings.ConnectionString));

            builder.Services.AddScoped<IConnectionStringProvider, ConnectionStringProvider>();

            serviceProvider.Dispose();

            PostgreSqlBootstrap.Initialize();
            builder.Services.AddScoped<ISurveyRepo, SurveyRepo>();
            builder.Services.UseOneTransactionPerHttpCall(appSettings);

        }
    }
}
