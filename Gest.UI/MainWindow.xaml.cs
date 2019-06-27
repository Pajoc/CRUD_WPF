using Gest.UI.Data;
using Gest.UI.ViewModel;
using System;
using System.Windows;

namespace Gest.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SupplierViewModel _supplierViewModel;

        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SuppliersViewClicked(object sender, RoutedEventArgs e)
        {
            SupplierDataService supplierDataService = new SupplierDataService();
            _supplierViewModel = new SupplierViewModel(supplierDataService);
            _supplierViewModel.Load();
            DataContext = _supplierViewModel;
        }

        private void BlueViewClicked(object sender, RoutedEventArgs e)
        {
            DataContext = new BlueViewModel();
        }
    }
}
