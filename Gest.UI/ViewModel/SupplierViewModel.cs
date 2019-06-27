using Gest.Model;
using Gest.UI.Data;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Gest.UI.ViewModel
{
    public class SupplierViewModel: ViewModelBase
    {
        private ISupplierDataService _supplierDataService;
        private Supplier _selectedSupplier;

        public SupplierViewModel(ISupplierDataService supplierDataService)
        {
            Suppliers = new ObservableCollection<Supplier>();
            ShowSuppliersViewCommand = new DelegateCommand(OnClickSuppliers);
            _supplierDataService = supplierDataService;
        }


        private void OnClickSuppliers()
        {
            Load();
        }

        public void Load()
        {
            var suppliers = _supplierDataService.GetAll();

            Suppliers.Clear();

            foreach (var supplier in suppliers)
            {
                Suppliers.Add(supplier);
            }
        }

        public ObservableCollection<Supplier> Suppliers { get; set; }

        public ICommand ShowSuppliersViewCommand { get; }


        public Supplier SelectedSupplier
        {
            get { return _selectedSupplier; }
            set
            {
                _selectedSupplier = value;
                OnPropertyChanged();
            }
        }

    }
}
