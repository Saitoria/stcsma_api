using SCTSMA.UTILS.Interface;
using System.Data;

namespace SCTSMA.APPLICATION
{
    public interface IDbService
    {
        Task<IResult<T>> GetAsync<T>(string command, object parms, IDbTransaction transaction = null);
        Task<IResult<List<T>>> GetAll<T>(string command, object parms, IDbTransaction transaction = null);
        Task<IResult<int>> EditData(string command, object parms, IDbTransaction transaction = null);
        Task<IResult<int>> EditDataWithId(string command, object parms, IDbTransaction transaction = null);
        Task<IDbTransaction> BeginTransaction();
        Task CommitTransaction(IDbTransaction transaction);
        Task RollbackTransaction(IDbTransaction transaction);
    }
}
