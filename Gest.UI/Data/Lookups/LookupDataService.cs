using Gest.Model;
using System.Collections.Generic;
using System.Linq;

namespace Gest.UI.Data.Lookups
{
    public class LookupDataService : IDepartmentLookupDataService
    {
        public IEnumerable<LookupItem> GetDepartmentLookupAsync()
        {
            yield return new LookupItem {  Id = 1, DisplayMember = "Accounting" };
            yield return new LookupItem { Id = 2, DisplayMember = "IT" };
            yield return new LookupItem { Id = 3, DisplayMember = "Production" };

        }
    }
}
