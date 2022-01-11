using System.Collections.Generic;
using System.Threading.Tasks;

namespace Noteboard.DataAccess.Azure.Storage
{
    public interface ITableStorageManager<T>
    {
        IList<T> Retrieve(string noteboardId);
        Task<T> InsertOrMergeAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
