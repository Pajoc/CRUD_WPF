using Gest.Model;
using Gest.UI.Data;
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
        private SupplierViewModel _supplierViewModel;

        public SupplierViewModelTests()
        {
            var mockSup = new SupplierDataProviderMock();
            _supplierViewModel = new SupplierViewModel(mockSup);
        }
        [Fact]
        public void ShouldLoadSuppliersView()
        {
            _supplierViewModel.Load();
            Assert.Equal(4, _supplierViewModel.Suppliers.Count());
        }

        [Fact]
        public void ShoulLoadSuppliersOnlyOnce()
        {
            _supplierViewModel.Load();
            _supplierViewModel.Load();
            Assert.Equal(4, _supplierViewModel.Suppliers.Count());
        }
    }


    public class SupplierDataProviderMock : ISupplierDataService
    {
        public IEnumerable<Supplier> GetAll()
        {
            yield return new Supplier { Id = 1, Name = "Paulo Costa" };
            yield return new Supplier { Id = 2, Name = "Leonor Costa" };
            yield return new Supplier { Id = 3, Name = "Odete Costa" };
            yield return new Supplier { Id = 4, Name = "Mário Costa" };
        }

    }
}
