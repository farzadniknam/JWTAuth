using JWTAuth.Common.Helper;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System.Data;

namespace JWTAuth.Data.Repositories
{
    public class UnitOfWorkFilter : IAsyncActionFilter
    {
        public IDbTransaction transaction { get; }
        public AppSettings _appSettings { get; set; }

        public UnitOfWorkFilter(IOptions<AppSettings> options, IDbTransaction transaction, IMemoryCache memoryCache)
        {
            this.transaction = transaction;
            this._appSettings = options.Value;
        }

        public IRepo<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new Repo<TEntity>(this);
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var connection = transaction.Connection;
            if (connection.State != ConnectionState.Open)
                throw new NotSupportedException("The provided connection was not open!");

            var executedContext = await next.Invoke();
            if (executedContext.Exception == null)
            {
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }
        }
    }
}
