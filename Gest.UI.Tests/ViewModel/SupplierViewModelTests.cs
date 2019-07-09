using Gest.Model;
using Gest.UI.Data;
using Gest.UI.Data.Lookups;
using Gest.UI.View.Services;
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
            var dialogMock = new DialogMock();
            _supplierViewModel = new EmployeeViewModel(mockSup, mackSupType, dialogMock);
        }
        [Fact]
        public void ShouldLoadSuppliersView()
        {
            _supplierViewModel.LoadAsync();
            Assert.Equal(4, _supplierViewModel.Employees.Count());
        }

        [Fact]
        public void ShoulLoadSuppliersOnlyOnce()
        {
            _supplierViewModel.LoadAsync();
            _supplierViewModel.LoadAsync();
            Assert.Equal(4, _supplierViewModel.Employees.Count());
        }
    }


    public class SupplierDataProviderMock : IEmployeeDataService
    {
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {

            var it1 = new Employee { Id = new Guid(), Name = "Paulo Costa" };
            var it2 = new Employee { Id = new Guid(), Name = "Leonor Costa" };
            var it3 = new Employee { Id = new Guid(), Name = "Odete Costa" };
            var list = new List<Employee>();
            list.Add(it1);
            list.Add(it2);
            list.Add(it3);
            return list;
        }

        public Task<bool> RemoveEmployeeAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }

    public class SupplierLoockupMock : IDepartmentLookupDataService
    {
        public async Task<IEnumerable<LookupItem>> GetDepartmentLookupAsync()
        {
           
            var it1 = new LookupItem { Id = new Guid(), DisplayMember = "Catalog" };
            var it2 = new LookupItem { Id = new Guid(), DisplayMember = "Custom" };
            var it3 = new LookupItem { Id = new Guid(), DisplayMember = "Test" };
            var list = new List<LookupItem>();
            list.Add(it1);
            list.Add(it2);
            list.Add(it3);

            
            return list;
        }
    }


    public class DialogMock : IMessageDialogService
    {
        public Task ShowInfoDialogAsync(string text)
        {
            throw new NotImplementedException();
        }

        public Task<MessageDialogResult> ShowOkCancelDialogAsync(string text, string title)
        {
            throw new NotImplementedException();
        }
    }
}
