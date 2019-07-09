using System.Collections.Generic;
using System.Threading.Tasks;
using Gest.Model;

namespace Gest.UI.Data.Lookups
{
    public interface IDepartmentLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetDepartmentLookupAsync();
    }
}