using Gest.UI.Data;
using Gest.UI.Data.Lookups;
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
            EmployeeDataService supplierDataService = new EmployeeDataService();
            LookupDataService lookupDataService = new LookupDataService();
            _supplierViewModel = new EmployeeViewModel(supplierDataService, lookupDataService);
            _supplierViewModel.Load();
            DataContext = _supplierViewModel;
        }

        private void BlueViewClicked(object sender, RoutedEventArgs e)
        {
            DataContext = new BlueViewModel();
        }
    }
}
