using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gest.Model;

namespace Gest.UI.Data
{
    public interface IEmployeeDataService
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<bool> RemoveEmployeeAsync(Guid id);
    }
}