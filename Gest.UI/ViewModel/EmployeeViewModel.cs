using Gest.Model;
using Gest.UI.Data;
using Gest.UI.Data.Lookups;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Gest.UI.ViewModel
{
    public class EmployeeViewModel: ViewModelBase
    {
        private IEmployeeDataService _supplierDataService;
        private IDepartmentLookupDataService _supplierTypeLookupDataService;
        private Employee _selectedEmployee;

        public EmployeeViewModel(IEmployeeDataService supplierDataService, IDepartmentLookupDataService supplierTypeLookupDataService)
        {
            Employees = new ObservableCollection<Employee>();
            Departments = new ObservableCollection<LookupItem>();
            ShowSuppliersViewCommand = new DelegateCommand(OnClickSuppliers);
            _supplierDataService = supplierDataService;
            _supplierTypeLookupDataService = supplierTypeLookupDataService;
        }


        private void OnClickSuppliers()
        {
            Load();
        }

        public void Load()
        {
            var suppliers = _supplierDataService.GetAll();

            Employees.Clear();

            foreach (var supplier in suppliers)
            {
                Employees.Add(supplier);
            }

            LoadDepartmentLookup();
        }

        private void LoadDepartmentLookup()
        {
            Departments.Clear();
            Departments.Add(new NullLookupItem { DisplayMember = " - " });
            var lookup =  _supplierTypeLookupDataService.GetDepartmentLookupAsync();
            foreach (var lookupItem in lookup)
            {
                Departments.Add(lookupItem);
            }
        }

        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<LookupItem> Departments { get; }

        public ICommand ShowSuppliersViewCommand { get; }


        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged();
            }
        }

    }
}
