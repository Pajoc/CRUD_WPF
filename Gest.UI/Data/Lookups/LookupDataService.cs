using Gest.DataAccess;
using Gest.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gest.UI.Data.Lookups
{
    public class LookupDataService : IDepartmentLookupDataService
    {
        private IDataReaderAccess<Department> _dataAccess;

        public LookupDataService(IDataReaderAccess<Department> dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<LookupItem> GetDepartmentLookupAsync()
        {
            
            var res = _dataAccess.GetAll(new Department());

            return res.Select(d => new LookupItem
            {
                Id = d.Id,
                DisplayMember = d.Description
            });

        }
    }
}
