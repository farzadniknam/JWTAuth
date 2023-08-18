
using JWTAuth.Common.Helper;
using Microsoft.Extensions.Options;
using Npgsql;
using RepoDb;
using System.Data;

namespace JWTAuth.Data.Repositories
{
    public class Repo<T> : BaseRepository<T, NpgsqlConnection>, IRepo<T> where T : class
    {
        #region [Instances]

        private AppSettings _appSettings;
        private UnitOfWorkFilter UnitOfWorkFilter { get; set; }
        private KabanSurveyContext _dbContext { get; set; } 
        private Guid LanguageId => new Guid("57b9faea-972b-4ba2-bfee-00a6695b440c");
        private readonly IDbConnection _conn;
        private readonly IDbTransaction _trans;

        #endregion

        /// <summary>
        /// Constructor get instance of context and repositories
        /// </summary>
        public Repo(UnitOfWorkFilter UnitOfWorkFilter) : base(UnitOfWorkFilter._appSettings.ConnectionString) 
        {
            this.UnitOfWorkFilter = UnitOfWorkFilter;
            this._appSettings = UnitOfWorkFilter._appSettings;
            this._conn = UnitOfWorkFilter.transaction.Connection;
            this._trans = UnitOfWorkFilter.transaction;
        }

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _conn.QueryAllAsync<T>();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }


        /// <summary>
        /// Get 
        /// </summary>
        /// <returns></returns>
        public async Task<T> GetAsync(int Id)
        {
            try
            {
                var retValue = await _conn.QueryAsync<T>(Id);
                return retValue?.FirstOrDefault();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}


















//using KabanSurveyCommon.Helper;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Options;
//using Npgsql;
//using RepoDb;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace KabanSurveyData.Repositories
//{
//    public class Repo<TEntity> : BaseRepository<TEntity, NpgsqlConnection>, IRepo<TEntity>
//    where TEntity : class
//    {
//        private IUnitOfWork _unitOfWork;

//        public Repo(IOptions<AppSettings> options, IUnitOfWork unitOfWork)
//            : base(options.Value.ConnectionString) 
//        {
//            _unitOfWork = unitOfWork;
//        }

//        public void Attach(IUnitOfWork unitOfWork) =>
//            _unitOfWork = unitOfWork;

//        public TResult Save<TResult>(TEntity entity) =>
//            Insert<TResult>(entity, transaction: _unitOfWork.Transaction);

//        public int SaveAll(IEnumerable<TEntity> entities) =>
//            InsertAll(entities, transaction: _unitOfWork.Transaction);

//        public int Delete(object id) =>
//            Delete(id, transaction: _unitOfWork.Transaction);

//        public TResult Merge<TResult>(TEntity entity) =>
//            Merge<TResult>(entity, transaction: _unitOfWork.Transaction);

//        public TEntity Query(object id) =>
//            Query(id, transaction: _unitOfWork.Transaction)?.FirstOrDefault();

//        public int Update(TEntity entity) =>
//            Update(entity, transaction: _unitOfWork.Transaction);
//    }
//}
