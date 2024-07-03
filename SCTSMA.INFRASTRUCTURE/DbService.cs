using Npgsql;
using SCTSMA.APPLICATION;
using System.Data;
using Dapper;
using SCTSMA.CONFIG;
using SCTSMA.UTILS.Interface;
using SCTSMA.UTILS;
using System.Threading.Tasks;

namespace SCTSMA.INFRASTRUCTURE
{
    public class DbService : IDbService
    {
        private readonly IDbConnection _db;

        public DbService()
        {
            _db = new NpgsqlConnection(Config.ConnectionString);
        }

        public async Task<IResult<int>> EditData(string command, object parms, IDbTransaction transaction = null)
        {
            try
            {
                int result = await _db.ExecuteAsync(command, parms, transaction);

                if (result > 0)
                {
                    return await Result<int>.SuccessAsync(result);
                }
                else
                {
                    return await Result<int>.FailureAsync("Connection failure");
                }
            }
            catch (Exception ex)
            {
                return await Result<int>.FailureAsync(ex.Message);
            }
        }

        public async Task<IResult<int>> EditDataWithId(string command, object parms, IDbTransaction transaction = null)
        {
            try
            {
                int dataId = await _db.ExecuteScalarAsync<int>(command, parms, transaction);
                return await Result<int>.SuccessAsync(dataId);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailureAsync(ex.Message);
            }
        }


        public async Task<IResult<List<T>>> GetAll<T>(string command, object parms, IDbTransaction transaction = null)
        {
            try
            {
                List<T> result = (await _db.QueryAsync<T>(command, parms, transaction)).ToList();
                return await Result<List<T>>.SuccessAsync(result);
            }
            catch (Exception ex)
            {
                return await Result<List<T>>.FailureAsync(ex.Message);
            }
        }

        public async Task<IResult<T>> GetAsync<T>(string command, object parms, IDbTransaction transaction = null)
        {
            try
            {
                T result = (await _db.QueryAsync<T>(command, parms, transaction).ConfigureAwait(false)).FirstOrDefault();
                return await Result<T>.SuccessAsync(result);
            }
            catch (Exception ex)
            {
                return await Result<T>.FailureAsync(ex.Message);
            }
        }

        public async Task<IDbTransaction> BeginTransaction()
        {
            if (_db.State != ConnectionState.Open)
            {
                await ((NpgsqlConnection)_db).OpenAsync();
            }
            return _db.BeginTransaction();
        }

        public async Task CommitTransaction(IDbTransaction transaction)
        {
            await Task.Run(() => transaction.Commit());
        }

        public async Task RollbackTransaction(IDbTransaction transaction)
        {
            await Task.Run(() => transaction.Rollback());
        }
    }
}
