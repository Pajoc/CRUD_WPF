using Gest.Model;
using Gest.UI.Data;
using Gest.UI.Data.Lookups;
using Gest.UI.Event;
using Gest.UI.View.Services;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Gest.UI.ViewModel
{
    public class EmployeeViewModel : ViewModelBase
    {
        private IEmployeeDataService _employeeDataService;
        private IDepartmentLookupDataService _employeeTypeLookupDataService;
        private Employee _selectedEmployee;
        protected readonly IMessageDialogService MessageDialogService;

        public EmployeeViewModel(IEmployeeDataService employeeDataService,
            IDepartmentLookupDataService employeeTypeLookupDataService, IMessageDialogService messageDialogService)
        {
            MessageDialogService = messageDialogService;
            Employees = new ObservableCollection<Employee>();
            Departments = new ObservableCollection<LookupItem>();

            _employeeDataService = employeeDataService;
            _employeeTypeLookupDataService = employeeTypeLookupDataService;

            DeleteCommand =  new DelegateCommand(OnDeleteExecuteAsync);
        }

        private async void OnDeleteExecuteAsync()
        {
            if (_selectedEmployee != null)
            {
                var result = await MessageDialogService.ShowOkCancelDialogAsync($"Do you really want to delete this supplier {_selectedEmployee.Name}?", "Question");
                if (result == MessageDialogResult.OK)
                {
                    await _employeeDataService.RemoveEmployeeAsync(_selectedEmployee.Id);
                    await LoadAsync();
                }
            }
        }

        private async Task OnClickSuppliersAsync()
        {
            await LoadAsync();
        }

        public async Task LoadAsync()
        {
            var employees = await _employeeDataService.GetAllAsync();

            Employees.Clear();

            foreach (var employee in employees)
            {
                Employees.Add(employee);
            }

            await LoadDepartmentLookupAsync();
        }

        private async Task LoadDepartmentLookupAsync()
        {
            Departments.Clear();
            Departments.Add(new NullLookupItem { DisplayMember = " - " });
            var lookup = await _employeeTypeLookupDataService.GetDepartmentLookupAsync();
            foreach (var lookupItem in lookup)
            {
                Departments.Add(lookupItem);
            }
        }

        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<LookupItem> Departments { get; }

        public ICommand DeleteCommand { get; private set; }


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
