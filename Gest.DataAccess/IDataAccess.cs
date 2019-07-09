using System;
using System.Threading.Tasks;

namespace Gest.DataAccess
{
    public interface IDataAccess<T>: IDataReaderAccess<T>
    {
        Task<bool> RemoveAsync(T entity, Guid guid);
    }
}