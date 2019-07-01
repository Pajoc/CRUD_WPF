using Gest.Model;
using Gest.UI.Data;
using Gest.UI.Data.Lookups;
using Gest.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Gest.UI.Tests.ViewModel
{
    public class SupplierViewModelTests
    {
        private EmployeeViewModel _supplierViewModel;

        public SupplierViewModelTests()
        {
            var mockSup = new SupplierDataProviderMock();
            var mackSupType = new SupplierLoockupMock();
            _supplierViewModel = new EmployeeViewModel(mockSup, mackSupType);
        }
        [Fact]
        public void ShouldLoadSuppliersView()
        {
            _supplierViewModel.Load();
            Assert.Equal(4, _supplierViewModel.Employees.Count());
        }

        [Fact]
        public void ShoulLoadSuppliersOnlyOnce()
        {
            _supplierViewModel.Load();
            _supplierViewModel.Load();
            Assert.Equal(4, _supplierViewModel.Employees.Count());
        }
    }


    public class SupplierDataProviderMock : IEmployeeDataService
    {
        public IEnumerable<Employee> GetAll()
        {
            yield return new Employee { Id = 1, Name = "Paulo Costa" };
            yield return new Employee { Id = 2, Name = "Leonor Costa" };
            yield return new Employee { Id = 3, Name = "Odete Costa" };
            yield return new Employee { Id = 4, Name = "Mário Costa" };
        }

    }

    public class SupplierLoockupMock : IDepartmentLookupDataService
    {
        public IEnumerable<LookupItem> GetDepartmentLookupAsync()
        {
            yield return new LookupItem { Id = 1, DisplayMember = "Catalog" };
            yield return new LookupItem { Id = 2, DisplayMember = "Custom" };
            yield return new LookupItem { Id = 3, DisplayMember = "Test" };
        }
    }
}
