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
            var guid = new Guid();
            var guid2 = new Guid();
            var guid3 = new Guid();
            var guid4 = new Guid();

            yield return new Employee { Id = guid, Name = "Paulo Costa" };
            yield return new Employee { Id = guid2, Name = "Leonor Costa" };
            yield return new Employee { Id = guid3, Name = "Odete Costa" };
            yield return new Employee { Id = guid4, Name = "Mário Costa" };
        }

    }

    public class SupplierLoockupMock : IDepartmentLookupDataService
    {
        public IEnumerable<LookupItem> GetDepartmentLookupAsync()
        {
            var guid = new Guid();
            var guid2 = new Guid();
            var guid3 = new Guid();
            yield return new LookupItem { Id = guid, DisplayMember = "Catalog" };
            yield return new LookupItem { Id = guid2, DisplayMember = "Custom" };
            yield return new LookupItem { Id = guid3, DisplayMember = "Test" };
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
