using Gest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gest.DataAccess
{
    public interface IDataReaderAccess<T>
    {
        IEnumerable<T> GetAll(T entity);
    }
}
