using JWTAuth.Common.Helper;
using JWTAuth.Data.Repositories;
using JWTAuth.Services;
using Npgsql;
using System.Data;

namespace JWTAuth.Helpers
{
    public static class ServiceCollectionExtensions
    {
        public static void UseOneTransactionPerHttpCall(this IServiceCollection serviceCollection, AppSettings _appSettings, IsolationLevel level = IsolationLevel.ReadUncommitted)
        {

            serviceCollection.AddScoped<IDbTransaction>(serviceProvider =>
            {
                var connectionStringProvider = serviceProvider.GetService<IConnectionStringProvider>();
                var connection = new NpgsqlConnection(_appSettings.ConnectionString);

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                return connection.BeginTransaction(level);
            });

            serviceCollection.AddScoped(typeof(UnitOfWorkFilter), typeof(UnitOfWorkFilter));

            serviceCollection.AddMvc(setup =>
            {
                setup.Filters.AddService<UnitOfWorkFilter>(1);
            });
        }
    }
}
