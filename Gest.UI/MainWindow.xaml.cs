using Gest.DataAccess;
using Gest.Model;
using Gest.UI.Data;
using Gest.UI.Data.Lookups;
using Gest.UI.View.Services;
using Gest.UI.ViewModel;
using MahApps.Metro.Controls;
using System;
using System.Windows;

namespace Gest.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private EmployeeViewModel _supplierViewModel;

        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EmployeeViewClicked(object sender, RoutedEventArgs e)
        {

            //builder.RegisterType<MessageDialogService>().As<IMessageDialogService>();
            MessageDialogService dialog = new MessageDialogService();

            WebServiceDataAccess<Employee> wsDRA = new WebServiceDataAccess<Employee>();
            EmployeeDataService employeeDataService = new EmployeeDataService(wsDRA);

            WebServiceDataAccess<Department> webServiceDataAccess = new WebServiceDataAccess<Department>();

            LookupDataService<Department> lookupDataService = new LookupDataService<Department>(webServiceDataAccess);
            _supplierViewModel = new EmployeeViewModel(employeeDataService, lookupDataService, dialog);
            _supplierViewModel.Load();
            DataContext = _supplierViewModel;
        }

        private void BlueViewClicked(object sender, RoutedEventArgs e)
        {
            DataContext = new BlueViewModel();
        }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (frmMainFrame.CanGoBack)
            {
                frmMainFrame.GoBack();
            }
        }
    }
}
