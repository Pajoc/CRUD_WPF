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
        private IEmployeeDataService _employeeDataService;
        private IDepartmentLookupDataService _employeeTypeLookupDataService;
        private Employee _selectedEmployee;

        public EmployeeViewModel(IEmployeeDataService employeeDataService, IDepartmentLookupDataService employeeTypeLookupDataService)
        {
            Employees = new ObservableCollection<Employee>();
            Departments = new ObservableCollection<LookupItem>();
            _employeeDataService = employeeDataService;
            _employeeTypeLookupDataService = employeeTypeLookupDataService;
        }


        private void OnClickSuppliers()
        {
            Load();
        }

        public void Load()
        {
            var employees = _employeeDataService.GetAll();

            Employees.Clear();

            foreach (var employee in employees)
            {
                Employees.Add(employee);
            }

            LoadDepartmentLookup();
        }

        private void LoadDepartmentLookup()
        {
            Departments.Clear();
            Departments.Add(new NullLookupItem { DisplayMember = " - " });
            var lookup =  _employeeTypeLookupDataService.GetDepartmentLookupAsync();
            foreach (var lookupItem in lookup)
            {
                Departments.Add(lookupItem);
            }
        }

        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<LookupItem> Departments { get; }


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
