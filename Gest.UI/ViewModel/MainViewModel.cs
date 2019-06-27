using Gest.Model;
using Gest.UI.Data;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Gest.UI.ViewModel
{
    public class MainViewModel: ViewModelBase
    {
        //private ISupplierDataService _supplierDataService;
        //private Supplier _selectedSupplier;

        //public MainViewModel(ISupplierDataService supplierDataService )
        //{
        //    Suppliers = new ObservableCollection<Supplier>();
        //    _supplierDataService = supplierDataService;
        //    ShowSuppliersViewCommand = new DelegateCommand(OnClickSuppliers);
        //}

        //private void OnClickSuppliers()
        //{
        //    var x = 1;
        //}

        //public void Load()
        //{
        //    var suppliers = _supplierDataService.GetAll();

        //    Suppliers.Clear();

        //    foreach (var supplier in suppliers)
        //    {
        //        Suppliers.Add(supplier);
        //    }
        //}

        //public ObservableCollection<Supplier> Suppliers { get; set; }

        //public ICommand ShowSuppliersViewCommand { get; }

        //public Supplier SelectedSupplier
        //{
        //    get { return _selectedSupplier; }
        //    set {
        //        _selectedSupplier = value;
        //        OnPropertyChanged();
        //    }
        //}

                
    }
}
