using System.Collections.Generic;
using Gest.Model;

namespace Gest.UI.Data.Lookups
{
    public interface IDepartmentLookupDataService
    {
        IEnumerable<LookupItem> GetDepartmentLookupAsync();
    }
}